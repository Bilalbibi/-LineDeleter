using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using LineDeleter.Models;
using MetroFramework.Controls;
using MetroFramework.Forms;
using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using OfficeOpenXml;
using scrapingTemplateV51.Models;
using Action = System.Action;
using Application = System.Windows.Forms.Application;
using CheckBox = System.Windows.Forms.CheckBox;
using TextBox = System.Windows.Forms.TextBox;

namespace LineDeleter
{
    public partial class MainForm : MetroForm
    {
        public bool LogToUi = true;
        public bool LogToFile = true;
        public bool _fileIsEmpty;
        private readonly string _path = System.Windows.Forms.Application.StartupPath;
        private Dictionary<string, string> _config;

        private List<string> _keywords;

        private int _maxLinesPerSheet;
        public MainForm()
        {
            InitializeComponent();
        }


        private async void MainWork()
        {
            var inputFiles = Directory.GetFiles(inputI.Text, "*").Select(fn => new FileInfo(fn)).
                OrderBy(f => f.Name).ToList();
            if (inputFiles.Count == 0)
            {
                MessageBox.Show(@"There are no populated documents in the input folder");
                return;
            }
            await FixCorreptedFiles(inputFiles);
            await Task.Run(() => StartProcessing(inputFiles));
            if (openCsvAfterI.Checked)
                Process.Start(outputI.Text);
            Invoke(new Action(() => startB.Enabled = true));
            Invoke(new Action(() => loadInputB.Enabled = true));
            Invoke(new Action(() => openInputB.Enabled = true));
            Invoke(new Action(() => OpenInputStringB.Enabled = true));
            Invoke(new Action(() => SelectInputStringB.Enabled = true));
            Invoke(new Action(() => OutPutFolderB.Enabled = true));
            foreach (var file in inputFiles)
            {
                if (file.Name.Contains("~$"))
                {
                    File.Delete(file.FullName);
                }
            }
        }

        private async Task FixCorreptedFiles(List<FileInfo> files)
        {
            foreach (var file in files)
            {
                ExcelPackage package;
                if (file.Name.EndsWith(".xlsx"))
                {
                    package = GetExcelPackage(file.FullName, true);
                }
                else
                {
                    ConvertXLS_XLSX(file.FullName);
                    package = GetExcelPackage(file.FullName, true);
                }

                ExcelWorksheets workSheets;
                try
                {
                    workSheets = package.Workbook.Worksheets;
                }
                catch (Exception)
                {
                    try
                    {

                        package.Dispose();
                        var app = new Microsoft.Office.Interop.Excel.Application { DisplayAlerts = false };
                        var wb = app.Workbooks.Open(file.FullName);
                        wb.SaveAs(file.FullName, XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, false, false, XlSaveAsAccessMode.xlNoChange, XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing);
                        wb.Close();
                        app.Quit();
                        package = new ExcelPackage(new FileInfo(file.FullName));
                        workSheets = package.Workbook.Worksheets;
                    }
                    catch (Exception ex)
                    {
                        throw new ApplicationException($"Can not Convert file {file.FullName.Substring(file.FullName.LastIndexOf('\\') + 1)} It appears the Input file is formatted in a format that is different from its .extension");
                    }

                }
            }
        }
        private ExcelPackage GetExcelPackage(string fileName, bool forHeaders)
        {
            ExcelPackage package;
            do
            {
                
                var checkIfFileOpen = IsFileOpen(fileName);
                if (!checkIfFileOpen)
                {
                    break;
                }
                Invoke(new Action(() => MessageBox.Show($@"Please close this file ""{fileName}"" for processing it")));
            } while (true);
            if (fileName.Contains("~$"))
            {
                fileName = fileName.Replace("~$", "");
            }
            FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            //file.Dispose();
            const int MAX_BUFFER = 1048576; //1MB 
            int read = 0;
            byte[] buffer = new byte[MAX_BUFFER];
            int bytesRead;
            BufferedStream bs = new BufferedStream(file);
            if (forHeaders)
            {
                try
                {
                    while ((bytesRead = bs.Read(buffer, 0, MAX_BUFFER)) != 0)
                    {
                        read = read + bytesRead;
                    }
                }
                catch (Exception)
                {

                    while ((bytesRead = bs.Read(buffer, 0, MAX_BUFFER)) != 0)
                    {
                        read = read + bytesRead;
                    }
                }
            }
            package = new ExcelPackage(bs);
            return package;
        }
        bool IsFileOpen(string filePath)
        {
            var isOpen = false;
            try
            {
                using (var fs = File.OpenWrite(filePath))
                {

                }
            }
            catch (IOException)
            {
                isOpen = true;
            }
            if (filePath.Contains("~$"))
            {
                do
                {
                    try
                    {
                        var pkg = new ExcelPackage(new FileInfo(filePath.Replace("~$", "")));
                        pkg.Save();
                        break;
                    }
                    catch (Exception)
                    {
                        Invoke(new Action(() => MessageBox.Show($@"Please close this file ""{filePath.Replace("~$", "")}"" for processing it")));
                    } 
                } while (true);
            }
            return isOpen;
        }
        public static string ConvertXLS_XLSX(string fileName)
        {
            var file = new FileInfo(fileName);
            var app = new Microsoft.Office.Interop.Excel.Application();
            var xlsFile = file.FullName;
            var wb = app.Workbooks.Open(xlsFile);
            var xlsxFile = xlsFile + "x";
            wb.SaveAs(xlsxFile, XlFileFormat.xlOpenXMLWorkbook);
            wb.Close();
            return xlsxFile;
        }
        private void StartProcessing(List<FileInfo> inputFiles)
        {
            var fileNbr = 1;
            foreach (var inputFile in inputFiles)
            {
                try
                {
                    if (inputFile.FullName.EndsWith(".csv"))
                    {
                        CsvHandler(inputFile);
                    }
                    else
                    {
                        if (inputFile.FullName.EndsWith(".xlsx") || inputFile.FullName.EndsWith(".xls"))
                        {
                            if (protectI.Checked)
                            {
                                ExcelHandlerProtectHeader(inputFile);
                            }
                            if (!protectI.Checked)
                            {
                                ExcelHandlerAsync(inputFile);
                            }
                        }

                    }
                }
                catch (Exception e)
                {
                    ErrorLog(e.ToString());
                    Display($"Error {e.Message}");
                }
                Invoke(new Action(() => Display($@"we are working on {inputFile.FullName} file")));
                Invoke(new Action(() => SetProgress((fileNbr * 100 / inputFiles.Count))));
                fileNbr++;
            }


            Display("Work done");
        }

        private void RemoveEmptyLinesMain()
        {
            var inputFiles = Directory.GetFiles(inputI.Text, "*").Select(fn => new FileInfo(fn)).
                OrderBy(f => f.Name).ToList();
            var fileNbr = 1;
            foreach (var inputFile in inputFiles)
            {
                try
                {
                    if (inputFile.FullName.EndsWith(".csv"))
                    {
                        RemoveEmptyLinesFromCsv(inputFile);
                    }
                    else
                    {
                        if (inputFile.FullName.EndsWith(".xlsx") || inputFile.FullName.EndsWith(".xls"))
                        {
                            DeleteEmptyLinesFromExcel(inputFile);
                        }

                    }
                }
                catch (Exception e)
                {
                    ErrorLog(e.ToString());
                    Display($"Error {e.Message}");
                }
                Invoke(new Action(() => Display($@"we are removing empty rows from {inputFile.Name} file")));
                Invoke(new Action(() => SetProgress((fileNbr * 100 / inputFiles.Count))));
                fileNbr++;
            }
        }

        private void CsvHandler(FileInfo file)
        {
            do
            {
                
                var checkIfFileOpen = IsFileOpen(file.FullName);
                if (!checkIfFileOpen)
                {
                    break;
                }
                Invoke(new Action(() => MessageBox.Show($@"Please close this file ""{file.FullName}"" for processing it")));
            } while (true);
            var lines = File.ReadAllLines(file.FullName).ToList();
            var outputLines = new List<string>();
            if (lines.Count == 0 && !_fileIsEmpty)
            {
                _fileIsEmpty = true;
                Invoke(new Action(() => Display(@"Warning: One or more Input documents contain NO Data Rows")));
                return;
            }
            var removedRows = 0;
            foreach (var line in lines)
            {
                var found = false;
                foreach (var keyword in _keywords)
                {
                    if (line.Trim().ToLower().Contains(keyword))
                    {
                        found = true;
                        removedRows++;
                        break;
                    }

                    if (!CapitalizationIsSacredI.Checked)
                    {
                        if ((wholeCellOnlyI.Checked && line.Trim().ToLower().Equals(keyword.ToLower())) || (!wholeCellOnlyI.Checked && line.Trim().ToLower().Contains(keyword.ToLower())))
                        {
                            found = true;
                            removedRows++;
                            break;
                        }
                    }
                    else
                    {
                        if ((wholeCellOnlyI.Checked && line.Trim().Equals(keyword)) || (!wholeCellOnlyI.Checked && line.Trim().Contains(keyword)))
                        {
                            found = true;
                            removedRows++;
                            break;
                        }
                    }
                }
                if ((!found && doContainsI.Checked) || (doNotI.Checked && found))
                {

                    if (RemoveEmptyRows.Checked)
                    {
                        if (!string.IsNullOrEmpty(line))
                        {
                            outputLines.Add(line);
                        }
                    }
                    outputLines.Add(line);
                }
            }

            if (lines.Count - 1 == removedRows || lines.Count == removedRows)
            {

                Invoke(new Action(() => MessageBox.Show($@"NOTE: Running this script will result in the removal of ALL lines in this file ""{file.FullName}""")));
                return;
            }


            if (removedRows == 0)
            {
                Invoke(new Action(() => MessageBox.Show($@"WARNING: Running the program with the options selected would NOT delete any rows from at least one of the input documents selected")));
                return;
            }

            var outputFileName = $"{outputI.Text}/{file.Name.Replace(".csv", "LDD.csv")}";
            File.WriteAllLines(outputFileName, outputLines);

        }

        private void RemoveEmptyLinesFromCsv(FileInfo file)
        {
            do
            {
                var checkIfFileOpen = IsFileOpen(file.FullName);
                if (!checkIfFileOpen)
                {
                    break;
                }
                Invoke(new Action(() => MessageBox.Show($@"Please close this file ""{file.FullName}"" for processing it")));
            } while (true);
            var lines = File.ReadAllLines(file.FullName).ToList();
            for (var i = lines.Count - 1; i >= 0; i--)
            {
                var line = lines[i];
                if (line.Trim().Equals(""))
                {
                    lines.RemoveAt(i);
                    continue;
                }
                var c = line.Split(',');
                bool empty = true;
                foreach (var s in c)
                {
                    if (!s.Trim().Equals(""))
                    {
                        empty = false;
                        break;
                    }
                }

                if (empty)
                {
                    lines.RemoveAt(i);
                }
            }

            var outputFileName = $"{outputI.Text}/{file.Name.Replace(".csv", "LDD.csv")}";
            File.WriteAllLines(outputFileName, lines);
            //File.WriteAllLines(outputFileName, outputLines);

        }

        private void ExcelHandlerProtectHeader(FileInfo file)
        {
            Invoke(new Action(() => Display($@"Working on ""{file.Name}"" file")));
            do
            {
                var checkIfFileOpen = IsFileOpen(file.FullName);
                if (!checkIfFileOpen)
                {
                    break;
                }
                Invoke(new Action(() => MessageBox.Show($@"Please close this file ""{file.FullName}"" for processing it")));
            } while (true);
            var newPath = file.FullName;
            if (file.Name.Contains("~$"))
            {
                newPath = file.FullName.Replace("~$", "");
            }
            ExcelPackage package = new ExcelPackage(new FileInfo(newPath));
            var sheets = package.Workbook.Worksheets;
            if ((sheets == null || sheets.Count == 0) && !_fileIsEmpty)
            {
                _fileIsEmpty = true;
                Invoke(new Action(() => MessageBox.Show(@"Warning: One or more Input documents contain NO Data Rows")));
                return;
            }
            var data = new List<List<CellProp>>();
            List<string> sheetNames = new List<string>();
            var removedRows = 0;
            if (sheets != null)
                foreach (var excelWorksheet in sheets)
                {
                    if (excelWorksheet.Dimension != null)
                    {
                        sheetNames.Add(excelWorksheet.Name);
                        var sh = new List<List<CellProp>>();
                        for (int i = 1; i <= excelWorksheet.Dimension.Rows; i++)
                        {
                            //Display($"Working on {excelWorksheet.Name} line {i} / {excelWorksheet.Dimension.Rows} ");
                            bool found = false;
                            for (int j = 1; j <= excelWorksheet.Dimension.Columns; j++)
                            {
                                if (excelWorksheet.Cells[i, j].Value == null) continue;
                                foreach (var keyword in _keywords)
                                {
                                    if (!CapitalizationIsSacredI.Checked)
                                    {
                                        if ((wholeCellOnlyI.Checked && excelWorksheet.Cells[i, j].Value.ToString()
                                            .Trim().ToLower().Equals(keyword.ToLower())) || (!wholeCellOnlyI.Checked &&
                                            excelWorksheet.Cells[i, j].Value.ToString().Trim().ToLower()
                                                .Contains(keyword.ToLower())))
                                        {
                                            found = true;
                                            removedRows++;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        if ((wholeCellOnlyI.Checked && excelWorksheet.Cells[i, j].Value.ToString()
                                            .Trim().Equals(keyword)) || (!wholeCellOnlyI.Checked &&
                                                                         excelWorksheet.Cells[i, j].Value.ToString()
                                                                             .Trim().Contains(keyword)))
                                        {
                                            found = true;
                                            removedRows++;
                                            break;
                                        }
                                    }
                                }

                                if (found) break;
                            }

                            if ((i == 1 && protectI.Checked) || (!found && doContainsI.Checked) ||
                                (doNotI.Checked && found))
                            {
                                var row = new List<CellProp>();
                                for (int j = 1; j <= excelWorksheet.Dimension.Columns; j++)
                                {

                                    row.Add(new CellProp { Value = excelWorksheet.Cells[i, j].Value, ExcelStyle = excelWorksheet.Cells[i, j].Style });
                                }

                                if (RemoveEmptyRows.Checked)
                                {
                                    var checkIfListNull = row.Any(x => x != null);

                                    if (checkIfListNull)
                                    {
                                        sh.Add(row);
                                    }
                                }
                                else
                                {
                                    sh.Add(row);
                                }
                            }
                        }

                        if (sh.Count > 1)
                            data.AddRange(sh);
                    }
                }

            if (data.Count == 0)
            {
                Invoke(new Action(() => MessageBox.Show($@"NOTE: Running this script will result in the removal of ALL lines in this file ""{file.FullName}""")));
                return;
            }
            if (removedRows == 0)
            {
                Invoke(new Action(() => MessageBox.Show(@"WARNING: Running the program with the options selected would NOT delete any rows from at least one of the input documents selected")));
                return;
            }
            //Directory.CreateDirectory($"{_path}/output");
            var outputFileName = $"{outputI.Text}/{file.Name.Replace(".xlsx", "LDD.xlsx")}";
            if (File.Exists(outputFileName))
                File.Delete(outputFileName);
            double sheetsNumbers = data.Count / _maxLinesPerSheet;
            ExcelPackage output = new ExcelPackage(new FileInfo(outputFileName));
            var dd = data[0];
            //var r = 0;
            //var line = 1;
            for (int i = 0; i < sheetsNumbers; i++)
            {
                var sheet = output.Workbook.Worksheets.Add($"Sheet{i + 1}");
                var lines = data.Take(_maxLinesPerSheet).ToList();
                for (int j = 0; j < lines.Count; j++)
                {
                    for (int k = 0; k < lines[j].Count; k++)
                    {
                        sheet.Cells[j + 1, k + 1].Value = lines[j][k].Value;
                        if (MatchFormatting.Checked)
                        {
                            if (!string.IsNullOrEmpty(lines[j][k].ExcelStyle.Fill.BackgroundColor.Rgb))
                            {
                                AddFormatting(sheet.Cells[j + 1, k + 1], lines[j][k]);
                            }
                        }
                    }
                }
                data.RemoveRange(0, _maxLinesPerSheet);
            }
            if (data.Count > 1)
            {
                sheetsNumbers++;
                var sheet = output.Workbook.Worksheets.Add($"Sheet{sheetsNumbers}");
                for (int j = 0; j < data.Count; j++)
                {
                    for (int k = 0; k < data[j].Count; k++)
                    {
                        sheet.Cells[j + 1, k + 1].Value = data[j][k].Value;
                        if (MatchFormatting.Checked)
                        {
                            if (!string.IsNullOrEmpty(data[j][k].ExcelStyle.Fill.BackgroundColor.Rgb))
                            {
                                AddFormatting(sheet.Cells[j + 1, k + 1], data[j][k]);
                            }
                        }
                    }
                }
            }
            output.Save();
        }

        private void AddFormatting(ExcelRange excelRange, CellProp cellProp)
        {
            excelRange.Style.Fill.PatternType = cellProp.ExcelStyle.Fill.PatternType;
            excelRange.Style.Fill.BackgroundColor
                .SetColor(ColorTranslator.FromHtml("#" + cellProp
                    .ExcelStyle.Fill.BackgroundColor.Rgb));
            excelRange.Style.Fill.BackgroundColor.Tint = 0;
        }

        private void DeleteEmptyLinesFromExcel(FileInfo file)
        {
            do
            {
                var checkIfFileOpen = IsFileOpen(file.FullName);
                if (!checkIfFileOpen)
                {

                    break;
                }
                Invoke(new Action(() => MessageBox.Show($@"Please close this file ""{file.FullName}"" for processing it")));
            } while (true);
            ExcelPackage package = new ExcelPackage(new FileInfo(file.FullName));
            var sheets = package.Workbook.Worksheets;
            foreach (var excelWorksheet in sheets)
            {
                Display($"Working on {excelWorksheet.Name}");
                new List<List<object>>();
                for (int i = excelWorksheet.Dimension.Rows - 1; i >= 1; i--)
                {
                    //Display($"Working on {excelWorksheet.Name} line {i} / {excelWorksheet.Dimension.Rows} ");
                    var found = true;
                    for (int j = 1; j <= excelWorksheet.Dimension.Columns; j++)
                    {
                        if (excelWorksheet.Cells[i, j].Value != null && !string.IsNullOrEmpty(excelWorksheet.Cells[i, j].Value.ToString()))
                        {
                            found = false;
                            break;
                        }
                    }
                    if (found)
                        excelWorksheet.DeleteRow(i);
                }
            }

            //Directory.CreateDirectory($"{_path}/output");

            var outputFileName = $"{outputI.Text}/{file.Name.Replace(".xlsx", "LDD.xlsx")}";
            if (File.Exists(outputFileName))
                File.Delete(outputFileName);
            package.SaveAs(new FileInfo(outputFileName));
        }

        private void ExcelHandlerAsync(FileInfo file)
        {
            Invoke(new Action(() => Display($@"Working on ""{file.Name}"" file")));
            do
            {
                var checkIfFileOpen = IsFileOpen(file.FullName);
                if (!checkIfFileOpen)
                {
                    break;
                }
                Invoke(new Action(() => MessageBox.Show($@"Please close this file ""{file.FullName}"" for processing it")));
            } while (true);
            var newPath = file.FullName;
            if (file.Name.Contains("~$"))
            {
                newPath = file.FullName.Replace("~$", "");
            }
            var package = new ExcelPackage(new FileInfo(newPath));
            var sheets = package.Workbook.Worksheets;
            if ((sheets == null || sheets.Count == 0) && !_fileIsEmpty)
            {
                _fileIsEmpty = true;
                Invoke(new Action(() => Display(@"Warning: One or more Input documents contain NO Data Rows")));
                return;
            }
            var data = new List<List<CellProp>>();
            var removedRows = 0;
            foreach (var excelWorksheet in sheets)
            {
                if (excelWorksheet.Dimension != null)
                {
                    for (int i = 1; i <= excelWorksheet.Dimension.Rows; i++)
                    {
                        bool found = false;
                        for (int j = 1; j <= excelWorksheet.Dimension.Columns; j++)
                        {
                            if (excelWorksheet.Cells[i, j].Value == null) continue;
                            foreach (var keyword in _keywords)
                            {
                                if (!CapitalizationIsSacredI.Checked)
                                {
                                    if ((wholeCellOnlyI.Checked && excelWorksheet.Cells[i, j].Value.ToString().Trim().ToLower().Equals(keyword.ToLower())) || (!wholeCellOnlyI.Checked && excelWorksheet.Cells[i, j].Value.ToString().Trim().ToLower().Contains(keyword.ToLower())))
                                    {
                                        found = true;
                                        removedRows++;
                                        break;
                                    }
                                }
                                else
                                {
                                    if ((wholeCellOnlyI.Checked && excelWorksheet.Cells[i, j].Value.ToString().Trim().Equals(keyword)) || (!wholeCellOnlyI.Checked && excelWorksheet.Cells[i, j].Value.ToString().Trim().Contains(keyword)))
                                    {
                                        found = true;
                                        removedRows++;
                                        break;
                                    }
                                }
                            }
                            if (found)
                                break;
                        }

                        if ((!found && doContainsI.Checked) || (doNotI.Checked && found))
                        {
                            var row = new List<CellProp>();
                            for (int j = 1; j <= excelWorksheet.Dimension.Columns; j++)
                            {
                                row.Add(new CellProp { Value = excelWorksheet.Cells[i, j].Value, ExcelStyle = excelWorksheet.Cells[i, j].Style });
                            }
                            if (RemoveEmptyRows.Checked)
                            {
                                var checkIfListNull = row.Any(x => x != null);

                                if (checkIfListNull)
                                {
                                    data.Add(row);
                                }
                            }
                            else
                            {
                                data.Add(row);
                            }
                        }
                    }
                }
            }
            if (data.Count == 0)
            {
                Invoke(new Action(() => MessageBox.Show($@"NOTE: Running this script will result in the removal of ALL lines in this file ""{file.FullName}""")));
                return;
            }
            if (removedRows == 0)
            {
                Invoke(new Action(() => MessageBox.Show($@"no input values match between  this file ""{file.FullName}"" and input strings")));
                return;
            }
            //Directory.CreateDirectory($"{_path}/output");
            var outputFileName = $"{outputI.Text}/{file.Name.Replace(".xlsx", "LDD.xlsx")}";
            if (File.Exists(outputFileName))
                File.Delete(outputFileName);
            ExcelPackage output = new ExcelPackage(new FileInfo(outputFileName));
            double sheetsNumbers = data.Count / _maxLinesPerSheet;

            for (int i = 0; i < sheetsNumbers; i++)
            {
                var sheet = output.Workbook.Worksheets.Add($"Sheet{i + 1}");
                var lines = data.Take(_maxLinesPerSheet).ToList();
                for (int j = 0; j < lines.Count; j++)
                {
                    for (int k = 0; k < lines[j].Count; k++)
                    {
                        sheet.Cells[j + 1, k + 1].Value = lines[j][k].Value;
                        if (MatchFormatting.Checked)
                        {
                            if (!string.IsNullOrEmpty(lines[j][k].ExcelStyle.Fill.BackgroundColor.Rgb))
                            {
                                AddFormatting(sheet.Cells[j + 1, k + 1], lines[j][k]);
                            }
                        }
                    }
                }
                data.RemoveRange(0, _maxLinesPerSheet);
            }
            if (data.Count > 1)
            {
                sheetsNumbers++;
                var sheet = output.Workbook.Worksheets.Add($"Sheet{sheetsNumbers}");
                for (int j = 0; j < data.Count; j++)
                {
                    for (int k = 0; k < data[j].Count; k++)
                    {
                        sheet.Cells[j + 1, k + 1].Value = data[j][k].Value;
                        if (MatchFormatting.Checked)
                        {
                            if (!string.IsNullOrEmpty(data[j][k].ExcelStyle.Fill.BackgroundColor.Rgb))
                            {
                                AddFormatting(sheet.Cells[j + 1, k + 1], data[j][k]);
                            }
                        }
                    }
                }
            }

            output.Save();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Directory.CreateDirectory("data");
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            ServicePointManager.DefaultConnectionLimit = 65000;
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            inputI.Text = _path + @"\input.xlsx";
            LoadConfig();
        }

        void InitControls(Control parent)
        {
            try
            {
                foreach (Control x in parent.Controls)
                {
                    try
                    {
                        if (x.Name.EndsWith("I"))
                        {
                            switch (x)
                            {
                                case MetroCheckBox _:
                                case CheckBox _:
                                    ((CheckBox)x).Checked = bool.Parse(_config[((CheckBox)x).Name]);
                                    break;
                                case RadioButton radioButton:
                                    radioButton.Checked = bool.Parse(_config[radioButton.Name]);
                                    break;
                                case TextBox _:
                                case RichTextBox _:
                                case MetroTextBox _:
                                    x.Text = _config[x.Name];
                                    break;
                                case NumericUpDown numericUpDown:
                                    numericUpDown.Value = int.Parse(_config[numericUpDown.Name]);
                                    break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }

                    InitControls(x);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void SaveControls(Control parent)
        {

            try
            {
                foreach (Control x in parent.Controls)
                {
                    #region Add key value to disctionarry

                    if (x.Name.EndsWith("I"))
                    {
                        switch (x)
                        {
                            case MetroRadioButton _:
                                _config.Add(x.Name, ((MetroRadioButton)x).Checked + "");
                                break;
                            case MetroCheckBox _:
                            // case MetroRadioButton _:
                            case RadioButton _:
                            case CheckBox _:
                                _config.Add(x.Name, ((CheckBox)x).Checked + "");
                                break;

                            case TextBox _:
                            case RichTextBox _:
                            case MetroTextBox _:
                                _config.Add(x.Name, x.Text);
                                break;
                            case NumericUpDown _:
                                _config.Add(x.Name, ((NumericUpDown)x).Value + "");
                                break;
                            default:
                                Console.WriteLine(@"could not find a type for " + x.Name);
                                break;
                        }
                    }
                    #endregion
                    SaveControls(x);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private void SaveConfig()
        {
            _config = new Dictionary<string, string>();
            SaveControls(this);
            try
            {
                File.WriteAllText("config.txt", JsonConvert.SerializeObject(_config, Formatting.Indented));
            }
            catch (Exception e)
            {
                ErrorLog(e.ToString());
            }
        }
        private void LoadConfig()
        {
            try
            {
                _config = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText("config.txt"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return;
            }
            InitControls(this);
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.ToString(), @"Unhandled Thread Exception");
        }
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show((e.ExceptionObject as Exception)?.ToString(), @"Unhandled UI Exception");
        }
        #region UIFunctions
        public delegate void WriteToLogD(string s, Color c);
        public void WriteToLog(string s, Color c)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new WriteToLogD(WriteToLog), s, c);
                    return;
                }
                if (LogToUi)
                {
                    if (DebugT.Lines.Length > 5000)
                    {
                        DebugT.Text = "";
                    }
                    DebugT.SelectionStart = DebugT.Text.Length;
                    DebugT.SelectionColor = c;
                    DebugT.AppendText(DateTime.Now.ToString(Utility.SimpleDateFormat) + " : " + s + Environment.NewLine);
                }
                Console.WriteLine(DateTime.Now.ToString(Utility.SimpleDateFormat) + @" : " + s);
                if (LogToFile)
                {
                    File.AppendAllText(_path + "/data/log.txt", DateTime.Now.ToString(Utility.SimpleDateFormat) + @" : " + s + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void NormalLog(string s)
        {
            WriteToLog(s, Color.Black);
        }
        public void ErrorLog(string s)
        {
            WriteToLog(s, Color.Red);
        }
        public void SuccessLog(string s)
        {
            WriteToLog(s, Color.Green);
        }
        public void CommandLog(string s)
        {
            WriteToLog(s, Color.Blue);
        }

        public delegate void SetProgressD(int x);
        public void SetProgress(int x)
        {
            if (InvokeRequired)
            {
                Invoke(new SetProgressD(SetProgress), x);
                return;
            }
            if ((x <= 100))
            {
                ProgressB.Value = x;
            }
        }
        public delegate void DisplayD(string s);
        public void Display(string s)
        {
            if (InvokeRequired)
            {
                Invoke(new DisplayD(Display), s);
                return;
            }
            displayT.Text = s;
        }

        #endregion
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveConfig();
        }
        private void loadInputB_Click_1(object sender, EventArgs e)
        {

            FolderBrowserDialog o = new FolderBrowserDialog { SelectedPath = _path };
            if (o.ShowDialog() == DialogResult.OK)
            {
                inputI.Text = o.SelectedPath;
            }
        }
        private void openInputB_Click_1(object sender, EventArgs e)
        {
            try
            {
                Process.Start(inputI.Text);
            }
            catch (Exception ex)
            {
                ErrorLog(ex.ToString());
            }
        }

        private async void startB_Click_1(object sender, EventArgs e)
        {
            Display("Bot Started");
            _keywords = new List<string>();

            var toContinue = CheckInputs();
            if (!toContinue)
            {
                return;
            }
            do
            {
                var checkIfFileOpen = IsFileOpen(inputStringsI.Text);
                if (!checkIfFileOpen)
                {
                    break;
                }
                Invoke(new Action(() => MessageBox.Show($@"Please close this file ""{inputStringsI.Text}"" for processing it")));
            } while (true);
            var package = new ExcelPackage(new FileInfo(inputStringsI.Text));
            var sheet = package.Workbook.Worksheets.First();
            var rows = sheet?.Dimension?.End.Row;
            if (rows == null || rows == 1)
            {
                MessageBox.Show(@"PLEASE NOTE: The INPUT STRINGS FILE You selected Does not contain any valid values");
                if (RemoveEmptyRows.Checked)
                {
                    await Task.Factory.StartNew(() =>
                     {
                         RemoveEmptyLinesMain();
                         return 0;
                     });
                    Display(@"Removing empty lines done");
                }
                else
                {
                    if (Directory.Exists(inputI.Text))
                    {
                        string[] files = Directory.GetFiles(inputI.Text);

                        // Copy the files and overwrite destination files if they already exist.
                        foreach (string s in files)
                        {
                            // Use static Path methods to extract only the file name from the path.
                            var fileName = Path.GetFileName(s);
                            var destFile = Path.Combine(outputI.Text, fileName);
                            File.Copy(s, destFile, true);
                        }
                    }
                }
                return;
            }
            for (int i = 2; i <= sheet.Dimension.End.Row; i++)
            {
                var s = sheet.Cells[i, 1].Value;
                if (s == null) continue;
                if (string.IsNullOrEmpty(s.ToString().Trim())) continue;
                _keywords.Add(s.ToString().Trim());
            }
            package.Dispose();


            try
            {
                _maxLinesPerSheet = int.Parse(maxLines.Text);
            }
            catch (Exception)
            {
                ErrorLog(@"Please enter a digit characters in ""Max lines per sheet"" field");
                return;
            }

            var inputStringPath =
                inputStringsI.Text.Substring(0, inputStringsI.Text.LastIndexOf("\\", StringComparison.Ordinal));
            if (inputStringPath == inputI.Text || inputStringPath == outputI.Text)
            {
                MessageBox.Show(@"You Can Not Select an input strings file located in the INPUT or OUTPUT folder");
                return;
            }
            startB.Enabled = false;
            loadInputB.Enabled = false;
            openInputB.Enabled = false;
            OpenInputStringB.Enabled = false;
            SelectInputStringB.Enabled = false;
            OutPutFolderB.Enabled = false;
            await Task.Factory.StartNew(() =>
            {
                MainWork();
                return 0;
            });
            _fileIsEmpty = false;
        }


        private bool CheckInputs()
        {
            if (!Directory.Exists(inputI.Text))
            {
                MessageBox.Show(@"Can not find the input folder selected");
                return false;
            }
            if (!Directory.Exists(outputI.Text))
            {
                MessageBox.Show(@"Can not find the Output folder selected");
                return false;
            }
            if (!File.Exists(inputStringsI.Text))
            {
                MessageBox.Show(@"Can not find the Input Strings file selected");
                return false;
            }

            if (inputI.Text == outputI.Text)
            {
                MessageBox.Show(@"You Can Not Select The Same Folder To Be Both The Input And Output Folder");
                return false;
            }

            return true;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog { Filter = @"xlsx|*.xlsx", InitialDirectory = _path };
            if (o.ShowDialog() == DialogResult.OK)
            {
                inputStringsI.Text = o.FileName;
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(inputStringsI.Text);
            }
            catch (Exception ex)
            {
                ErrorLog(ex.ToString());
            }
        }

        private void RemoveEmptyRowsButton_Click(object sender, EventArgs e)
        {
            LogToUi = logToUII.Checked;
            LogToFile = logToFileI.Checked;

            if (!File.Exists(inputI.Text))
            {
                Display("Sorry Input data not found");
                return;
            }

            Task.Factory.StartNew<int>(() =>
            {
                RemoveEmptyLinesMain();
                return 0;
            });
            if (openCsvAfterI.Checked)
                Process.Start(outputI.Text);

        }

        private void loadOutputB_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog o = new FolderBrowserDialog();
            if (o.ShowDialog() == DialogResult.OK)
            {
                outputI.Text = o.SelectedPath;
            }
        }
    }
}
