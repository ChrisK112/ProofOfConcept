using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProofOfConceptBLZ.Models
{
    public class NewEmailModel
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string AddedUserId { get; set; }
        public DateTime AddedDateTime { get; set; }
        public Boolean IsDeleted { get; set; }

        [Required]
        [StringLength(320, ErrorMessage = "Too long for an email address!")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [PasswordPropertyText]
        public string EmailPassword { get; set; }

        [Required]
        [StringLength(320, ErrorMessage = "Too long!")]
        [MinLength(1, ErrorMessage = "Too short!")]
        public string DisplayName { get; set; }

        [Required]
        public string Host { get; set; }

        [Required]
        public int Port { get; set; }


    }
}
