using Microsoft.Identity.Client;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace ProofOfConceptBLZ.Models
{
    public class DataCellViewModel
    {
        public int DataRowIndex { get; set; }

        public string DataCellValue { get; set; }
        
    }
}
