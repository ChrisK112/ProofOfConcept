using Microsoft.Identity.Client;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace ProofOfConceptBLZ.Models
{
    public class DataRowViewModel
    {
        public int DataRowIndex { get; set; }

        public List<string> DataCellValues { get; set; }
        
    }
}
