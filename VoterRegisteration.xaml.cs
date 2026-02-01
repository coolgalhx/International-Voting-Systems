using Azure;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
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
using static International_Voting_Systems.VoteRegisterationObserver;
using static International_Voting_Systems.MainDBConext;

namespace International_Voting_Systems
{
    /// <summary>
    /// Interaction logic for VoterRegisteration.xaml
    /// </summary>
    public partial class VoterRegisteration : Window
    {   
        private Subject subject;
        public VoterRegisteration()
        {
            InitializeComponent();
            subject=new Subject(); 
           
        }


        private void btnregistervoter_Click(object sender, RoutedEventArgs e)
        {
            
                var newVoter = new Voter()
                {

                    VoterID = Convert.ToInt32(txtvoterid.Text),
                    Name = txtname.Text,
                    Email = txtemail.Text,
                    Age = Convert.ToInt32(txtage.Text),
                    Gender = txtgender.Text,
                    DOB = Convert.ToDateTime(txtdob.Text),
                    ContactNumber = Convert.ToDouble(txtcontactnumber.Text),

                };

            subject.RegisterVoter(newVoter);


            MessageBox.Show("New Voter Added!");

            
        }
    }
    
}
