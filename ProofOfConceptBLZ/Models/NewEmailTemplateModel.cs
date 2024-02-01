using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProofOfConceptBLZ.Models
{
    public class NewEmailTemplateModel
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string AddedUserId { get; set; }
        public DateTime AddedDateTime { get; set; }
        public Boolean IsDeleted { get; set; }

        [Required]
        [StringLength(320, ErrorMessage = "Too long!")]
        [MinLength(1, ErrorMessage = "Too short!")]
        public string EmailTemplateName { get; set; }



    }
}
