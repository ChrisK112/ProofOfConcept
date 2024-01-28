using Microsoft.Identity.Client;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace ProofOfConceptBLZ.Models
{
    public class DataFileBrowseModel
    {

        public string DataTableName { get; set; }

        public int DataTableId { get; set; }

        public int NumberOfRecords { get; set; }
        
    }
}
