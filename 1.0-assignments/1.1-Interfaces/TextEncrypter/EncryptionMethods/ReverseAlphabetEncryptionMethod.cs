using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TextEncrypter.EncryptionMethods
{
    public class ReverseAlphabetEncryptionMethod : EncryptionMethodBase
    {
        //[»] Constant variable members |-----------|*|-----------|
        public const string ENCRYPTION_METHOD_NAME = "Reverse alphabet encryption method";

        //[»] Private backing variable members |-----------|*|-----------|

        //[»] Property members |-----------|*|-----------|

        // Open to potential extension
        public override Func<string, string> Encode => uncodedInputString =>
        {
            // Run the implied cryptography method
            char[] arrEncodedCharacters = RunTwoWayCryptography(uncodedInputString.ToCharArray());

            // ... (algorithm happends to be reversible -> accidental code duplicate)

            // Return the stringified characters
            return new string(arrEncodedCharacters);
        };

        // Open to potential extension
        public override Func<string, string> Decode => encodedInputString =>
        {
            // Run the implied cryptography method
            char[] arrDecodedCharacters = RunTwoWayCryptography(encodedInputString.ToCharArray());

            // ... (algorithm happends to be reversible -> accidental code duplicate)

            // Return the stringified characters
            return new string(arrDecodedCharacters);
        };

        private Func<char[], char[]> RunTwoWayCryptography => arrCharacters =>
        {
            // Convert characters to ASCII values
            int[] arrOriginalCodesASCII = arrCharacters.Select(selectedChar => (int)selectedChar).ToArray<int>();

            // Invert the ASCII values
            int[] arrInvertedCodesASCII = InvertAlphabetCodesASCII(arrOriginalCodesASCII);

            // Convert ASCII values back to characters
            char[] arrInvertedChars = arrInvertedCodesASCII.Select(selectedCodeASCII => (char)selectedCodeASCII).ToArray();

            // Returning the result
            return arrInvertedChars;
        };

        //[»] Constructor |-----------|*|-----------|

        public ReverseAlphabetEncryptionMethod() : base(ENCRYPTION_METHOD_NAME) 
        {
            
        }

        //[»] Primary method members |-----------|*|-----------|

        // Open to potential extension
        public override string EncodeString(string uncodedInputString)
        {
            // ... (process flow happens to be simple -> currently one-liner)
            return Encode(uncodedInputString);
        }

        // Open to potential extension
        public override string DecodeString(string encodedInputString)
        {
            // ... (process flow happens to be simple -> currently one-liner)
            return Decode(encodedInputString);
        }

        //[»] Secondary method members |-----------|*|-----------|

        private int[] InvertAlphabetCodesASCII(int[] codesASCII)
        {
            // Define the inversion formula => reversedNumber = beginRange + (endRange - number)
            Func<(int startRange, int endRange, int codeASCII), int> orderInversionFormula = (tupleForumaleArgs) =>
            {
                return tupleForumaleArgs.startRange + (tupleForumaleArgs.endRange - tupleForumaleArgs.codeASCII);
            };

            // Implement the inversion formula
            int[] arrInvertedAlphabetCodesASCII = codesASCII.Select(selectedCodeASCII => {
                
                // Localise property values (verbosity++)
                byte lowercaseStartRange = UsedAlphabetRangesASCII.lowercase.startRange;
                byte lowercaseEndRange = UsedAlphabetRangesASCII.uppercase.endRange;
                byte uppercaseStartRange = UsedAlphabetRangesASCII.lowercase.startRange;
                byte uppercaseEndRange = UsedAlphabetRangesASCII.uppercase.endRange;

                // Determine the ASCII code casing (inside upper/lower range?)
                bool isLowercase = (selectedCodeASCII >= lowercaseStartRange) && (selectedCodeASCII >= lowercaseEndRange);

                // Select the corresponding start-/ and end ranges (upper/lower case)
                var startRange = (isLowercase) ? lowercaseStartRange : uppercaseStartRange;
                var endRange = (isLowercase) ? lowercaseEndRange : uppercaseEndRange;
                
                // Return the formula result
                return orderInversionFormula((startRange, endRange, selectedCodeASCII));
            }
            ).ToArray();

            // Return the result
            return arrInvertedAlphabetCodesASCII;
        }
    }
}
