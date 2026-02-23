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

namespace International_Voting_Systems.Testing
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }
        [TestMethod]
        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{    
        //    //Unit test 1: observer added

        //    //ARRANGE
        //    Subject subject = new Subject();
        //    ObserverTestforCand observer = new ObserverTestforCand();
        //    subject.Attatch(observer);

        //    CandidateController controller = new CandidateController(subject);

        //    Candidate candidate = new Candidate
        //    {
        //        CandidateFullName = "Jane Doe",
        //        CandidateEmail="Hibaq1040@gmail.com",
        //        CandidateCity="test",
        //        //CandidateID = 2,
        //        CandidateAddress = "45 Park Road",
        //        CandidateConstituency = "Manchester",
        //        CandidateDOB = new DateOnly(1995, 5, 5),
        //        CandidateNationalInsuranceNumber = "CD987654E"
        //    };

        //    // Act
        //    controller.RegisterCand(candidate);

        //    // Assert
        //    if (observer.Notified)
        //    {

        //        if (observer.ReceivedCandidate != null &&
        //            observer.ReceivedCandidate.CandidateFullName == candidate.CandidateFullName)
        //        {
        //            MessageBox.Show("Test Passed: Observer attached and notified with correct candidate.");
        //        }

        //    }

        //}

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Subject subject = new Subject();

            var attached = new ObserverTestforCand();
            var detached = new ObserverTestforCand();

            subject.Attatch(attached);
            subject.Attatch(detached);

            subject.Detach(detached); // remove before action

            var controller = new CandidateController(subject);

            var candidate = new Candidate
            {
                CandidateID = 1002, // include if required by DB
                CandidateFullName = "Test",
                CandidateEmail = "test@test.com",
                CandidateCity = "test",
                CandidateAddress = "45 Park Road",
                CandidateConstituency = "Manchester",
                CandidateDOB = new DateOnly(1995, 5, 5),
                CandidateNationalInsuranceNumber = "CD987654E"
            };

            controller.RegisterCand(candidate);

            if (attached.Notified && !detached.Notified)
            {
                MessageBox.Show("Test Passed: Attached notified, detached NOT notified.");
            }
            else
            {
                MessageBox.Show("Test failed");
            }
                
            
        }
    }
}
