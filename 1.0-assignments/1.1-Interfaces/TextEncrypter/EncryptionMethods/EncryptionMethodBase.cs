using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEncrypter.EncryptionMethods
{
    public abstract class EncryptionMethodBase : IEncryptionMethod
    {
        //[»] Constant variable members |-----------|*|-----------|

        // Open to potential alphabets
        public static (byte startLowercase, byte endLowercase) ASCII_ROMAN_ALPHABET_LOWERCASE_RANGE => (97, 122);
        public static (byte startUppercase, byte endUppercase) ASCII_ROMAN_ALPHABET_UPPERCASE_RANGE => (65, 90);

        //[»] Private backing variable members |-----------|*|-----------|

        //[»] Property members |-----------|*|-----------|

        public string Name { get; private set; }

        public abstract Func<string, string> Encode { get; }

        public abstract Func<string, string> Decode { get; }

        // Tuple of 2 named tuples (tuple voor immutables, struct voor mutables)
        public ((byte startRange, byte endRange) lowercase, (byte startRange, byte endRange) uppercase) UsedAlphabetRangesASCII { get; private set; }

        //[»] Constructor |-----------|*|-----------|

        public EncryptionMethodBase(string ENCRYPTION_METHOD_NAME)
        {
            Name = ENCRYPTION_METHOD_NAME;
            UsedAlphabetRangesASCII = (ASCII_ROMAN_ALPHABET_LOWERCASE_RANGE, ASCII_ROMAN_ALPHABET_UPPERCASE_RANGE);
        }

        //[»] Primary method members |-----------|*|-----------|

        public abstract string EncodeString(string uncodedInputString);

        public abstract string DecodeString(string encodedInputString);

        public virtual bool[] ExtractCasingScheme(char[] arrInputCharacters)
        {
            // Destructure each character into "is it uppercase?" booleans
            bool[] arrIsCharacterUppercase = arrInputCharacters.Select(selectedChar => char.IsUpper(selectedChar)).ToArray();

            // Returning the result
            return arrIsCharacterUppercase;
        }

        public virtual void ApplyCasingScheme(CryptographyDetails cryptographyDetails)
        {
            // Iterate over all input characters
            for (int i = 0; i < cryptographyDetails.UncodedIputCharacters.Length; i++)
            {
                // Define the input character
                char uncasedCharacter = cryptographyDetails.UncodedIputCharacters[i];

                // Define, and decide, the output aptly cased character
                char caseAppliedCharacter = cryptographyDetails.CharacterCasingScheme[i] ? char.ToUpper(uncasedCharacter) : char.ToLower(uncasedCharacter);

                // Save the resulting character
                cryptographyDetails.CodedOutputCharacters[i] = caseAppliedCharacter;
            }
        }

        //[»] Secondary method members |-----------|*|-----------|
    }
}
