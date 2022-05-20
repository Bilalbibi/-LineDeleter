using OfficeOpenXml.Style;

namespace LineDeleter.Models
{
    public class CellProp
    {
        public object Value { get; set; }
        public ExcelStyle ExcelStyle { get; set; }
        public string RGB { get; set; }
    }
}
