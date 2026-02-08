using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using GTranslate;
using GTranslate.Translators;
using System.Windows.Controls;


namespace International_Voting_Systems
{
    public class VoterAdapterPattern
    {

        public interface ITranslationService
        {
            Task TranslateToFrench(params Label[] labels);
        }

        // The VoterDatainEnAdaptee contains some useful behavior, but its interface is
        // incompatible with the existing client code. The VoterDatainEnAdaptee needs some
        // adaptation before the client code can use it.
        public class VoterDatainEnAdaptee
        {
            public string ShowVoterData()
            {
                return "Specific request.";
            }
        }

        // The VoterDataTranslatedAdapter makes the VoterDatainEnAdaptee's interface compatible with the Target's
        // interface.
        public class VoterDataTranslatedAdapter : ITranslationService
        {
            private readonly VoterDatainEnAdaptee _adaptee;
            private readonly GoogleTranslator _translator = new GoogleTranslator();



            public VoterDataTranslatedAdapter(VoterDatainEnAdaptee adaptee)
            {
                this._adaptee = adaptee;
            }

            public async Task TranslateToFrench(params Label[] labels)
            {
                var translator = new GoogleTranslator();

                

                foreach (var lbl in labels)
                {
                    if (lbl.Content is string text)
                    {

                        var result = await _translator.TranslateAsync(text, "fr");
                        lbl.Content = result.Translation;
                    }

                }


            }
        }
    }
}
