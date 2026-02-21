using Microsoft.EntityFrameworkCore.Storage;
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
        private readonly MVAFacade _mvafacade = new MVAFacade()
;
        public ManageVoterAccounts()
        {
            InitializeComponent();
            LoadAllVoters();
        }
        public void LoadAllVoters()
        {
            

            var voters = _mvafacade.ListAllVoters();
            VoterAccounts = new ObservableCollection<Voter>(voters);
            datagridvoters.ItemsSource = VoterAccounts;

        }

        public void Btnreject_Click(object sender, RoutedEventArgs e)
        {
            if (datagridvoters.SelectedItem is Voter selectedvoteraccount)
            {
              
                  _mvafacade.RejectVoter(selectedvoteraccount.VoterID);
                VoterAccounts.Remove(selectedvoteraccount);
            }

        }

        private void BtnClearTable_Click_1(object sender, RoutedEventArgs e)
        {
            

            _mvafacade.ClearOldData(0);
            LoadAllVoters();
  
        }
        private void datagridvoters_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

            // datagridvoters.CommitEdit(DataGridEditingUnit.Row, true);

            //if (e.Row.Item is Voter selectedvoter)
            //{
            //    _mvafacade.UpdateVoter(selectedvoter);
            //    //string columnName= e.Column.SortMemberPath;

            //    //if (columnName == "IsApproved" && selectedvoter.IsApproved)
            //    //{
            //    //    _mvafacade.UpdateVoter(selectedvoter);
            //    //}
            //    //if (columnName == "IsSuspended" && selectedvoter.IsSuspended)
            //    //{
            //    //    _mvafacade.SuspendVoter(selectedvoter.VoterID);
            //    //}




            //}

            if (e.Row.Item is Voter selectedvoter)
            {
                // Wait until checkbox/text value is fully updated
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    _mvafacade.UpdateVoter(selectedvoter);
                }), System.Windows.Threading.DispatcherPriority.Background);
            }




        }

        
    }
    
    


}
