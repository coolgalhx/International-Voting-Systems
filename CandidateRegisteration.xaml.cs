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
        private CandidateRegistrationObserver.Subject subject;
        public CandidateRegisteration()
        {
            InitializeComponent();
            subject = new CandidateRegistrationObserver.Subject();
        }

        private void Btnregistercandidate_Click(object sender, RoutedEventArgs e)
        {
            var newCandidate = new Candidate();
            {

                //textboxes

            };

            subject.RegisterCandidate(newCandidate);


            MessageBox.Show("New Candidate Added!");
        }


    }
}
