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
//using static International_Voting_Systems.MainDBContext;
using GTranslate.Translators;
using System.Threading.Tasks.Dataflow;
using static International_Voting_Systems.VoterAdapterPattern;
using MailKit.Net.Smtp;
using MimeKit;

namespace International_Voting_Systems
{
    /// <summary>
    /// Interaction logic for VoterRegisteration.xaml
    /// </summary>
    public partial class VoterRegisteration : Window
    {
        private Subject subject;
        private readonly ITranslationService _translator;
       

        public VoterRegisteration()
        {
            InitializeComponent();
            subject = new Subject();

            //_translator = new TranslatorAdapter(new GTranslateAdaptee());

            
            EmailService es=new EmailService();
            subject.Attach(es);


            


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

        private async void Translate_Click(object sender, RoutedEventArgs e)
        {
            //https://github.com/d4n3436/GTranslate

            var adaptee = new VoterDatainEnAdaptee();
            var adapter = new VoterDataTranslatedAdapter(adaptee);
            await adapter.TranslateToFrench(lblname);
        }
    }
}
