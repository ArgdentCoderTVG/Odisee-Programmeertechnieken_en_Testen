using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEncrypter.EncryptionMethods
{
    internal class ShiftOrderOneUpEncryptionMethod : EncryptionMethodBase
    {
        //[»] Constant variable members |-----------|*|-----------|
        public const string ENCRYPTION_METHOD_NAME = "Shift order one up encryption method";

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
            int[] arrInvertedCodesASCII = ShiftOneUpCodesASCII(arrOriginalCodesASCII);

            // Convert ASCII values back to characters
            char[] arrInvertedChars = arrInvertedCodesASCII.Select(selectedCodeASCII => (char)selectedCodeASCII).ToArray();

            // Returning the result
            return arrInvertedChars;
        };

        //[»] Constructor |-----------|*|-----------|

        public ShiftOrderOneUpEncryptionMethod() : base(ENCRYPTION_METHOD_NAME)
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

        private int[] ShiftOneUpCodesASCII(int[] codesASCII)
        {
            // Extract the last element (becomes the first one)
            int lastCodeASCII = codesASCII.Last();

            // Shift all characters one up, then fill in the first character
            int[] shiftedOneUpcodesASCII = new int[codesASCII.Length];
            for (int i = 0; i < codesASCII.Length; i++)
            {
                if (i == codesASCII.Length - 1) { shiftedOneUpcodesASCII[0] = lastCodeASCII; }
                else { shiftedOneUpcodesASCII[i + 1] = codesASCII[i]; }
            }

            // Return the result
            return shiftedOneUpcodesASCII;
        }
    }
}
