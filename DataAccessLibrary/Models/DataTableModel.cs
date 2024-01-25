using System;

namespace DataAccessLibrary.Models
{
    public class DataTableModel
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string UploadUser { get; set; }
        public DateTime UploadDateTime { get; set; }
        public string DataTableName { get; set; }
        public int NumberOfRecords { get; set; }
        public Boolean IsDeleted { get; set; }

    }
}
