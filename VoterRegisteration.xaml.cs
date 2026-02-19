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
using GTranslate.Translators;
using System.Threading.Tasks.Dataflow;
using International_Voting_Systems.VoterRegObserver;
using MailKit.Net.Smtp;
using MimeKit;
using International_Voting_Systems.VoterAdapterPattern;
using International_Voting_Systems.UsabilityStatePattern;
using System.Speech.Synthesis;



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
        bool IsSpeaking = false;
        SpeechSynthesizer speaker = new SpeechSynthesizer();


        public VoterRegisteration()
        {
            InitializeComponent();
            subject = new Subject();

            //_translator = new TranslatorAdapter(new GTranslateAdaptee());

            
            EmailService es=new EmailService();
            subject.Attach(es);


            _themeContext = new ThemeContext(new DarkToLight());


        }
        private double zoom = 1.0;

        private void Window_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
                zoom += 0.1;
            else if (zoom > 0.5)
                zoom -= 0.1;

            zoomTransform.ScaleX = zoom;
            zoomTransform.ScaleY = zoom;
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
 
            
        }

        private async void Translate_Click(object sender, RoutedEventArgs e)
        {
            //https://github.com/d4n3436/GTranslate

            var adaptee = new VoterDatainEnAdaptee();
            var adapter = new VoterDataTranslatedAdapter(adaptee);
            await adapter.TranslateToFrench(lblname, lblage,lblcity,lblcontactnumber,lblemail,lblpostcode,lblgender
               ,lblvoterid,lblcountry,lbldob);
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

        private  async void BtnTexttoSpeechn_Click(object sender, RoutedEventArgs e)
        {

            if (IsSpeaking)  
            {
                speaker.SpeakAsyncCancelAll();
                ResetLabelColours();
                IsSpeaking = false;
                return;
            }

            IsSpeaking = true;

            var labels = new Label[]
            {
                 lblname,
                 lblemail,
                 lblvoterid,
                 lblgender,
                 lblage,
                 lblcontactnumber,
                 lblcity,
                 lblpostcode,
                 lblcountry,
                 lbldob
            };

            foreach (var lbl in labels)
            {
                if (!IsSpeaking) break;

               
                lbl.Foreground = Brushes.BlueViolet;
                lbl.FontWeight = FontWeights.Bold;

                if (lbl.Content is string text)
                {
                    await Task.Run(() => speaker.Speak(text));
                    
                }

                lbl.Foreground = Brushes.Black;
                lbl.FontWeight = FontWeights.Normal;
            }
            IsSpeaking = false;
        }


        private void ResetLabelColours()
        {
            var labels = new Label[]
            {
               lblname, lblage, lblcity, lblcontactnumber,
               lblemail, lblpostcode, lblgender, lblvoterid,lblcountry, lbldob
            };

            foreach (var lbl in labels)
            {
                lbl.Foreground = Brushes.Black;
                lbl.FontWeight = FontWeights.Bold;
            }
        }
    }
}
