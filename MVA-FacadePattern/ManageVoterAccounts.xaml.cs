using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ManageVoterAccounts.xaml
    /// </summary>
    public partial class ManageVoterAccounts : Window
    {
        public ObservableCollection<Voter> VoterAccounts { get; set; }

        public ManageVoterAccounts()
        {
            InitializeComponent();
            LoadAllVoters();
        }
        public void LoadAllVoters()
        {
            //using (var db = new MainDatabaseContext())
            //{
            //    db.Database.EnsureCreated();
            //    var voterAccountsList = db.Voters.ToList();

            //    if (voterAccountsList != null)
            //    {
            //        VoterAccounts = new ObservableCollection<Voter>(voterAccountsList);
            //    }
            //    else
            //    {
            //        //if no data datagrid shows as empty
            //        VoterAccounts = new ObservableCollection<Voter>();
            //    }
            //    datagridvoters.ItemsSource = VoterAccounts;
            //}

            var MVAFacade = new MVAFacade();
            var voters = MVAFacade.ListAllVoters();
            VoterAccounts = new ObservableCollection<Voter>(voters);
            datagridvoters.ItemsSource = VoterAccounts;

        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            if (datagridvoters.SelectedItem is Voter selectedvoteraccount)
            {
                var MVAFacade = new MVAFacade();
                MVAFacade.RejectVoter(selectedvoteraccount.VoterID);
                VoterAccounts.Remove(selectedvoteraccount);
            }

        }
    }
    
    


}
