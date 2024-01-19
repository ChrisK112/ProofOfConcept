using System.ComponentModel.DataAnnotations;

namespace ProofOfConceptBLZ.Models
{
    public class DisplayPersonModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "Too long!")]
        [MinLength(1, ErrorMessage = "Too short")]
        public string Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Too long!")]
        [MinLength(1, ErrorMessage = "Too short")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
    }
}
