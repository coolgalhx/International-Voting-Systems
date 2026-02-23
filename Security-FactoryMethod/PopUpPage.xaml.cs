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
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace International_Voting_Systems.Security
{
    /// <summary>
    /// Interaction logic for PopUpPage.xaml
    /// </summary>
    public partial class PopUpPage : Window
    {

        private int _voterid;
        public PopUpPage(int voterid)
        {
            InitializeComponent();
            _voterid = voterid;
        }

        private async void BtnGenerateOTP_Click(object sender, RoutedEventArgs e)
        {
            //IAuthenticator auth = new EmailAuthenticator();
           // bool success = await auth.AuthenticateAsync(_voterid.ToString(), txtinputcode.Text);
           var factory=new EmailAuthenticationFactory();
            IAuthenticator auth = factory.FactoryMethod();

            bool success = await auth.AuthenticateAsync(_voterid.ToString(), txtinputcode.Text);
        }

        
    }
}
