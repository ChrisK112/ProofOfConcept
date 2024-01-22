using System.ComponentModel.DataAnnotations;

namespace ProofOfConceptBLZ.Models
{
    public class CampaignDataImportModel
    {
        public int CampignDataId { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(255)]
        public string CampaignDataName { get; set; }
    
        public string? FileName { get; set; }

    }
}
