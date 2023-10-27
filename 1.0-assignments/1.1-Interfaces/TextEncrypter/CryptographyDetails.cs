using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEncrypter
{
    public struct CryptographyDetails
    {
        // General Details
        public string InputString{ get; set; }
        public string OutputString { get; set; }

        // Specific Details
        public char[] UncodedIputCharacters { get; set; }
        public char[] CodedOutputCharacters { get; set; }
        public bool[] CharacterCasingScheme { get; set; }
        

        public CryptographyDetails(string inputString) 
            : this()
        {
            InputString = inputString;
            UncodedIputCharacters = Array.Empty<char>();
            CodedOutputCharacters = Array.Empty<char>();
            CharacterCasingScheme = Array.Empty<bool>();
            OutputString = String.Empty;
        }
    }
}
