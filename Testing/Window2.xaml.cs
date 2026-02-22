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
using Microsoft.EntityFrameworkCore;


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
            ////Unit Test 1: Approve, Suspend and Reject voter, only need to change method line 59 and 66

            ////ARRANGE
            //var facade = new MVAFacade();

            //int voterId;


            //var voter = new Voter
            //{
            //    Name = "Test",
            //    //VoterID= 1,
            //    Email = "Hibaq1040@gmail.com",
            //    Gender = "Male",
            //    DOB = new DateTime(2000, 1, 1),
            //    ContactNumber = 07123456789,
            //    PostCode = "S1 2AB",
            //    City = "Sheffield",
            //    Country = "UK"
            //};
            //using (var db = new MainDatabaseContext())
            //{
            //    db.Database.EnsureCreated();
            //    db.Voters.Add(voter);
            //    db.SaveChanges();
            //    voterId = voter.VoterID;
            //}


            //// ACT
            //facade.ListAllVoters();

            //// ASSERT
            //using (var db = new MainDatabaseContext())
            //{
            //    //var updated = db.Voters.Find(voter.VoterID);

            //    //if (updated.IsApproved)
            //    //{
            //    //    MessageBox.Show("Test Passed: Suspend voter method works");
            //    //}

            //    //else
            //    //{
            //    //    MessageBox.Show("FAIL");
            //    //}

            //    var exists = db.Voters.Any(v => v.VoterID == voterId);
            //    // Assert.IsFalse(exists, "Voter should have been removed by RejectVoter");

            //    if (!exists)
            //    {
            //        MessageBox.Show("Test Passed: RejectVoter removed voter");
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Integration test 1: testing if facade is actually connected to db

            //var facade = new MVAFacade();

            //var voters = facade.ListAllVoters();

            //MessageBox.Show($"Number of voters in database: {voters.Count}");

            using (var db = new MainDatabaseContext())
            {
                bool successfulConnection = db.Database.CanConnect();

                if (successfulConnection)
                {
                    MessageBox.Show("Successful Connection");
                }
                else
                {
                    MessageBox.Show("Test Failed");
                }
            }




        }


    }

    
} 

        


