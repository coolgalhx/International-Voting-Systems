using International_Voting_Systems.VoterRegObserver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Internal;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        [TestMethod]
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            //ARRANGE
            var subject = new Subject();
            var testObserver = new ObserverTest();

             subject.Attach(testObserver);


            // /Manual TEST 1: attach works

            //// ACT
            // subject.Notify();


            // //ASSERT
            // if (testObserver.Notified)
            // {
            //     MessageBox.Show("Test Pass: Observer attached");
            // }
            // else
            // {
            //     MessageBox.Show("Test Fail: Observer not attached");
            // }




            //Manual test 2: testing if the observer is notified

            //testObserver.Notified = false;
            //var voter = new Voter
            //{
            //    Name = "Test",
            //    Email = "Hibaq1040@gmail.com",
            //    Gender = "Male",
            //    DOB = new DateTime(2000, 1, 1),
            //    ContactNumber = 07123456789,
            //    PostCode = "S1 2AB",
            //    City = "Sheffield",
            //    Country = "UK"
            //};

            ////ACT 
            //subject.RegisterVoter(voter);


            ////ASSERT
            //if (testObserver.Notified)
            //{
            //    MessageBox.Show("Test Pass: Observer notified");
            //}
            //else
            //{
            //    MessageBox.Show(" Test Failed: Observer not notified");
            //}

            //Integration test 3: testing if the voter data is saved and observer is notified

            //testObserver.Notified = false;
            //var voter = new Voter
            //{
            //    Name = "Test",
            //    Email = "Hibaq1040@gmail.com",
            //    Gender = "Male",
            //    DOB = new DateTime(2000, 1, 1),
            //    ContactNumber = 07123456789,
            //    PostCode = "S1 2AB",
            //    City = "Sheffield",
            //    Country = "UK"
            //};
            //subject.RegisterVoter(voter);

            //if (testObserver.Notified)
            //{
            //    MessageBox.Show("Intergration Test Pass: Voter details saved and Observer notified");
            //}
            //else
            //{
            //    MessageBox.Show(" Test Failed");
            //}


            //Integration test 4: multiple voters added


            //testObserver.Notified = false;
            //var voter = new Voter
            //{
            //    Name = "Test",
            //    Email = "Hibaq1040@gmail.com",
            //    Gender = "Male",
            //    DOB = new DateTime(2000, 1, 1),
            //    ContactNumber = 07123456789,
            //    PostCode = "S1 2AB",
            //    City = "Sheffield",
            //    Country = "UK"
            //};


            //var voter2 = new Voter
            //{
            //    Name = "Test",
            //    Email = "Hibaq1040@gmail.com",
            //    Gender = "Male",
            //    DOB = new DateTime(2000, 1, 1),
            //    ContactNumber = 07123456789,
            //    PostCode = "S1 2AB",
            //    City = "Sheffield",
            //    Country = "UK"
            //};

            //ACT
            //subject.RegisterVoter(voter);
            //subject.RegisterVoter(voter2);


            //ASSERT
            //if (testObserver.Notified)
            //{
            //    MessageBox.Show("Multiple Voters added successfully");
            //}
            //else
            //{
            //    MessageBox.Show(" Test Failed");
            //}













        }
    }
}
