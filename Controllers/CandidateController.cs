using International_Voting_Systems.CandObserverPattern;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace International_Voting_Systems.Controllers
{
    class CandidateController
    {
        private Subject subject;

        public bool ValidateCandiateInput(Candidate candidate)
        {
            if (string.IsNullOrWhiteSpace(candidate.CandidateFullName))
            {
                MessageBox.Show("Candidate name cannot be empty.");
                return false;
            }
            if ((candidate.CandidateID<=0))
            {
                MessageBox.Show("Please input a unique number for your ID.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(candidate.CandidateAddress))
            {
                MessageBox.Show("Address cannot be left empty.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(candidate.CandidateConstituency))
            {
                MessageBox.Show("Please enter a Constituency");
                return false;
            }

            if (candidate.CandidateDOB > DateOnly.FromDateTime(DateTime.Now))
            {
                MessageBox.Show("Date of Birth cannot be in the future");
                return false;
            }

            
            int age = DateTime.Now.Year - candidate.CandidateDOB.Year;
            if (candidate.CandidateDOB > DateOnly.FromDateTime(DateTime.Now.AddYears(-age))) age--;

            if (age < 18)
            {
                MessageBox.Show("You must be 18 or over to vote");
                return false;
            }

            if (string.IsNullOrEmpty(candidate.CandidateNationalInsuranceNumber))
            {
                MessageBox.Show("Please enter your National Insurance number/Country equivalent ");
                return false;
            }


            return true;
        }

        public CandidateController(Subject subject)
        {
            this.subject = subject;
        }
        public string RegisterCand(Candidate candidate)
        {
            


            subject.RegisterCandidate(candidate); 

            return "Candidate registered successfully";
        }

    }
}
