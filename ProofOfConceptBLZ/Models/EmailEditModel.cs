using System.ComponentModel.DataAnnotations;

namespace ProofOfConceptBLZ.Data
{
    public class EmailEditModel
    { 
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string EmailAddress { get; set; }
        public string EmailPassword { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }

    }
}
