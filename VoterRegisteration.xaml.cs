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
//using static International_Voting_Systems.VoteRegisterationObserver;
//using static International_Voting_Systems.MainDBContext;
using GTranslate.Translators;
using System.Threading.Tasks.Dataflow;
//using static International_Voting_Systems.VoterAdapterPattern.ITranslationService;
using International_Voting_Systems.VoterRegObserver;
using MailKit.Net.Smtp;
using MimeKit;
using International_Voting_Systems.VoterAdapterPattern;
using International_Voting_Systems.UsabilityStatePattern;


namespace International_Voting_Systems
{
    /// <summary>
    /// Interaction logic for VoterRegisteration.xaml
    /// </summary>
    /// 

   
    public partial class VoterRegisteration : Window
    {
        private Subject subject;
        private readonly ITranslationService _translator;
        private ThemeContext _themeContext;
       

        public VoterRegisteration()
        {
            InitializeComponent();
            subject = new Subject();

            //_translator = new TranslatorAdapter(new GTranslateAdaptee());

            
            EmailService es=new EmailService();
            subject.Attach(es);


            _themeContext = new ThemeContext(new DarkToLight());


        }
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            // Apply theme safely here
            _themeContext.Request1(this);
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
                City=txtcity.Text,
                Country=txtcountry.Text,
                PostCode=txtpostcode.Text,

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
        private void LoadTheme(string themePath)
        {
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(
                new ResourceDictionary()
                {
                    Source = new Uri(themePath, UriKind.Relative)
                });
        }

        private void ThemeCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            _themeContext.TransitionTo(new DarkToLight());
            _themeContext.Request1(this);

            LoadTheme("Themes/Light.xaml");


        }
        private void ThemeCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            _themeContext.TransitionTo(new LightToDark());
            _themeContext.Request1(this);

            LoadTheme("Themes/Dark.xaml");
        }

    }
}
