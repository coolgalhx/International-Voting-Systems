using International_Voting_Systems.CandObserverPattern;
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

            EmailService es2=new EmailService();
             subject.Attatch(es2);
        }

        private void Btnregistercandidate_Click(object sender, RoutedEventArgs e)
        {
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

            subject.RegisterCandidate(newCandidate);


            MessageBox.Show("New Candidate Added!");
        }


    }
}
