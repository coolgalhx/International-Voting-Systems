using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace International_Voting_Systems
{
    public class IDTable
    {
        [Key]
        public int ID { get; set; }

        
        [ForeignKey("Voter")]
        public int VoterID { get; set; }
        public virtual Voter Voter { get; set; }

        
        [ForeignKey("Candidate")]
        public int CandidateID { get; set; }
        public virtual Candidate Candidate { get; set; }

        
        [ForeignKey("Code")]
        public int CodeID { get; set; }
        public virtual Code Code { get; set; }
    }
}
