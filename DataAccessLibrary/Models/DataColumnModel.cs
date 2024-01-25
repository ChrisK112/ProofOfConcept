namespace DataAccessLibrary.Models
{
    public class DataColumnModel
    {
        public int Id { get; set; }
        public int DataColumnIndex { get; set; }
        public int DataTableId { get; set; }
        public int CompanyId { get; set; }
        public string ColumnHeader { get; set; }
        public Boolean IsEmailColumn { get; set; }


    }
}
