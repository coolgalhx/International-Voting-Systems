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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            IAuthenticator auth = new EmailAuthenticator();
            bool success = await auth.AuthenticateAsync(_voterid.ToString(), txtinputcode.Text);
        }
    }
}
