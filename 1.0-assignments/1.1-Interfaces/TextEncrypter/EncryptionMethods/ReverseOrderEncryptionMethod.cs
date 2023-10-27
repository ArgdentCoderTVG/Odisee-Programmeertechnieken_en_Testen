using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEncrypter.EncryptionMethods
{
    public class ReverseOrderEncryptionMethod : EncryptionMethodBase
    {
        //[»] Constant variable members |-----------|*|-----------|
        public const string ENCRYPTION_METHOD_NAME = "Reverse order encryption method";

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
            int[] arrInvertedCodesASCII = InvertorderCodesASCII(arrOriginalCodesASCII);

            // Convert ASCII values back to characters
            char[] arrInvertedChars = arrInvertedCodesASCII.Select(selectedCodeASCII => (char)selectedCodeASCII).ToArray();

            // Returning the result
            return arrInvertedChars;
        };

        //[»] Constructor |-----------|*|-----------|

        public ReverseOrderEncryptionMethod() : base(ENCRYPTION_METHOD_NAME)
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

        private int[] InvertorderCodesASCII(int[] codesASCII)
        {
            // Simply reverse the characters
            int[] arrInvertedOrderCodesASCII = codesASCII.Reverse().ToArray();

            // Return the result
            return arrInvertedOrderCodesASCII;
        }
    }
}
