using System;

namespace DataAccessLibrary.Models
{
    public class CompanyModel
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public Boolean IsDeleted { get; set; }
        public Boolean HasActivePlan { get; set; }

    }
}
