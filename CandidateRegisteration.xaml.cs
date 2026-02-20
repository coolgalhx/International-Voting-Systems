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
       
        public CandidateRegisteration()
        {
            InitializeComponent();
            subject = new CandObserverPattern.Subject();

            EmailService es2 = new EmailService();
            subject.Attatch(es2);
        }
        


        private void Btnregistercandidate_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtCandidateID.Text, out int id))
            {
                MessageBox.Show("Please enter valid ID");
                return;
            }


            if (!DateOnly.TryParse(txtCandidateDOB.Text, out DateOnly dob))
            {
                MessageBox.Show("Please enter valid Date of Birth");
                return;
            }



            var newCandidate = new Candidate()
            {
                CandidateID = id,
                CandidateFullName = txtCandidateFullName.Text,
                CandidateEmail = txtCandidateEmail.Text,
                CandidateAddress = txtCandidateAddress.Text,
                CandidateDOB = dob,
                CandidateCity = txtCandidateCity.Text,
                CandidateNationalInsuranceNumber = txtCandidateNI.Text,
                CandidateConstituency = txtCandidateConstituency.Text



            };


            
             CandidateController controller = new CandidateController(subject);

            if (controller.ValidateCandiateInput(newCandidate) )
            {
                string result = controller.RegisterCand(newCandidate);
                MessageBox.Show(result);
            }
            
           
            

            


        }

    }
    
}
