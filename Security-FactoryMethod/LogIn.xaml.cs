using International_Voting_Systems.Security;
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
    /// Interaction logic for LogIn.xaml
    /// </summary>
    /// 

    public partial class LogIn : Window
    {
        public LogIn()
        {
            InitializeComponent();

        }

        private async void btncheckcredentials_Click(object sender, RoutedEventArgs e)
        {
            

            if (!int.TryParse(txtvoteridlogin.Text, out int voterid))
            {
                MessageBox.Show("Please enter your VoterID");
                return;
            }

            LogInFacade loginFacade = new LogInFacade();
            bool isAuthorized = loginFacade.LogIn(voterid);

            if (!isAuthorized)
            {
               
            }
            else
            {
                IAuthenticator auth = new CredentialAuthenticator();
                bool success = await auth.AuthenticateAsync(txtvoteridlogin.Text);
            }
            
           


            
        }
    } 
}
