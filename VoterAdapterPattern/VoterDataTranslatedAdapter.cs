using GTranslate.Translators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace International_Voting_Systems.VoterAdapterPattern
{
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
