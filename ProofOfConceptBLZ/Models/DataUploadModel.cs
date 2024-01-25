using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProofOfConceptBLZ.Models
{
    public class DataUploadModel
    {

        [Required]
        public string ?EmailColumnName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(255)]
        public string DataFileName { get; set; }
        
    }
}
