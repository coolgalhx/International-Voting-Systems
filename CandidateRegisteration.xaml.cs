using International_Voting_Systems.CandObserverPattern;
using International_Voting_Systems.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;



namespace International_Voting_Systems
{
    /// <summary>
    /// Interaction logic for CandidateRegisteration.xaml
    /// </summary>
    public partial class CandidateRegisteration : Window


    {
        private CandObserverPattern.Subject subject;
        // private CandidateController controller;
        public CandidateRegisteration()
        {
            InitializeComponent();
            subject = new CandObserverPattern.Subject();

            EmailService es2 = new EmailService();
            subject.Attatch(es2);
        }
        private bool ValidateCandidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtCandidateFullName.Text))
            {
                MessageBox.Show("Candidate name cannot be empty.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCandidateID.Text))
            {
                MessageBox.Show("Please input a unique number for your ID.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCandidateAddress.Text))
            {
                MessageBox.Show("Address cannot be left empty.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCandidateConstituency.Text))
            {
                MessageBox.Show("Please enter a Constituency");
                return false;
            }

            if (!DateTime.TryParse(txtCandidateDOB.Text, out DateTime dob))
            {
                MessageBox.Show("Invalid date of birth. Please use the format DD/MM/YYYY.");
                return false;
            }

            if (dob > DateTime.Now)
            {
                MessageBox.Show("Date of Birth cannot be in the future");
                return false;

            }
            int calculatedage = DateTime.Now.Year - dob.Year;
            if (calculatedage < 18)
            {
                MessageBox.Show("You must be 18 or over to vote");
                return false;
            }

            if (string.IsNullOrEmpty(txtCandidateNI.Text))
            {
                MessageBox.Show("Please enter your National Insurance number/Country equivalent ");
                return false;
            }


            return true;
        }


        private void Btnregistercandidate_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateCandidateInput())
                return;
            

            var newCandidate = new Candidate()
            {
                CandidateID = Convert.ToInt32(txtCandidateID.Text),
                CandidateFullName = txtCandidateFullName.Text,
                CandidateEmail = txtCandidateEmail.Text,
                CandidateAddress = txtCandidateAddress.Text,
                CandidateDOB = DateOnly.Parse(txtCandidateDOB.Text),
                CandidateCity = txtCandidateCity.Text,
                CandidateNationalInsuranceNumber = txtCandidateNI.Text,
                CandidateConstituency = txtCandidateConstituency.Text



            };

            // subject.RegisterCandidate(newCandidate);
            CandidateController controller = new CandidateController(subject);

            string result = controller.RegisterCand(newCandidate);


            //MessageBox.Show();
        }

    }
    
}
