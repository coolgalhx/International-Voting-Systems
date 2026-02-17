using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace International_Voting_Systems
{
    public class Code
    {
        [Key]
        public int CodeID { get; set; }

        [ForeignKey("VoterID")]
        public int VoterID { get; set; }
        public virtual Voter Voter { get; set; }
        public int OTP { get; set; }
        public DateTime ExpiryTime { get; set; }

        public bool IsUsed { get; set; } = false;
    }
}

