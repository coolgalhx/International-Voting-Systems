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
using International_Voting_Systems;


namespace International_Voting_Systems.Testing
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        [TestMethod]

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Unit Test 1: Approve voter

            //ARRANGE
            var facade = new MVAFacade();

            var voter = new Voter
            {
                Name = "Test",
                Email = "Hibaq1040@gmail.com",
                Gender = "Male",
                DOB = new DateTime(2000, 1, 1),
                ContactNumber = 07123456789,
                PostCode = "S1 2AB",
                City = "Sheffield",
                Country = "UK"
            };
            using (var db = new MainDatabaseContext())
            {
                db.Voters.Add(voter);
                db.SaveChanges();
            }


            // ACT
            facade.ApproveVoter(voter.VoterID);

            // ASSERT
            using (var db = new MainDatabaseContext())
            {
                var updated = db.Voters.Find(voter.VoterID);

                if (updated.IsApproved)
                {
                    MessageBox.Show("Test Passed: Approve voter method works");
                }

                else
                {
                    MessageBox.Show("FAIL");
                }
                   
            }
        }
    }
}
