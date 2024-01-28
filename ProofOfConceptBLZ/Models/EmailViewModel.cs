using System.ComponentModel.DataAnnotations;

namespace ProofOfConceptBLZ.Data
{
    public class EmailViewModel
    { 
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string EmailAddress { get; set; }

    }
}
