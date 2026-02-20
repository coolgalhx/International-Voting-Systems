using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace International_Voting_Systems
{
    public class Candidate
    {
        public int CandidateID { get; set; }
        public string CandidateFullName { get; set; }
        public string CandidateEmail { get; set; }
        public string CandidateAddress { get; set; }
        public DateOnly CandidateDOB { get; set; }
        public string CandidateCity { get; set; }
        public string CandidateNationalInsuranceNumber { get; set; }

        public string CandidateConstituency { get; set; }


        //public string ValidateCandidateInput()
        //{
        //    if (string.IsNullOrWhiteSpace(CandidateFullName))
        //    {
        //        return "Candidate name cannot be empty.";
        //    }

        //    if (CandidateID <= 0)
        //    {
        //        return "Please input a valid unique number for your ID.";
        //    }

        //    if (string.IsNullOrWhiteSpace(CandidateAddress))
        //    {
        //        return "Address cannot be left empty.";
        //    }

        //    if (string.IsNullOrWhiteSpace(CandidateConstituency))
        //    {
        //        return "Please enter a Constituency.";
        //    }

        //    // DOB validation
        //    if (CandidateDOB > DateOnly.FromDateTime(DateTime.Now))
        //    {
        //        return "Date of Birth cannot be in the future.";
        //    }

        //    int calculatedAge = DateTime.Now.Year - CandidateDOB.Year;

        //    if (calculatedAge < 18)
        //    {
        //        return "Candidate must be 18 or over.";
        //    }

        //    if (string.IsNullOrWhiteSpace(CandidateNationalInsuranceNumber))
        //    {
        //        return "Please enter your National Insurance number.";
        //    }

        //    return "OK"; 
        //}
    }
}
