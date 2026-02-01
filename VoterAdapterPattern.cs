using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTranslate.Translators;


namespace International_Voting_Systems
{
    internal class VoterAdapterPattern
    {
        // The Target defines the domain-specific interface used by the client code.
        public interface ITarget
        {
            Task<string> TranslateAsync(string text, string toLang);
        }

        // The GTranslateAdaptee contains some useful behavior, but its interface is
        // incompatible with the existing client code. The GTranslateAdaptee needs some
        // adaptation before the client code can use it.
        public class GTranslateAdaptee
        {
            private readonly AggregateTranslator _translator = new();

            public async Task<string> TranslateAsync(string text, string toLanguage)
            {
                var result = await _translator.TranslateAsync(text, "en", toLanguage);
                return result.Translation;
            }
        }

        // The Adapter makes the GTranslateAdaptee's interface compatible with the Target's
        // interface.
        public class TranslatorAdapter : ITarget
        {
            private readonly GTranslateAdaptee _adaptee;

            public TranslatorAdapter(GTranslateAdaptee adaptee)
            {
                _adaptee = adaptee;
            }

            public Task<string> TranslateAsync(string text, string toLang)
            {
                return _adaptee.TranslateAsync(text, toLang);
            }
        }
    }
}
