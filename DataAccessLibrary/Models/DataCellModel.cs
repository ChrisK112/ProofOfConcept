namespace DataAccessLibrary.Models
{
    public class DataCellModel
    {
        public int Id { get; set; }
        public int DataTableId { get; set; }
        public int DataRowId { get; set; }
        public int DataColumnId { get; set; }
        public int CompanyId { get; set; }
        public string ?CellValue { get; set; }

    }
}
