using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEncrypter.EncryptionMethods
{
    internal class EnigmaRotorEncryptionMethod : EncryptionMethodBase
    {
        //[»] Constant variable members |-----------|*|-----------|
        public const string ENCRYPTION_METHOD_NAME = "Enigma Rotor encryption method";

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
            int[] arrInvertedCodesASCII = UseEnigma(arrOriginalCodesASCII);

            // Convert ASCII values back to characters
            char[] arrInvertedChars = arrInvertedCodesASCII.Select(selectedCodeASCII => (char)selectedCodeASCII).ToArray();

            // Returning the result
            return arrInvertedChars;
        };

        //[»] Constructor |-----------|*|-----------|

        public EnigmaRotorEncryptionMethod() : base(ENCRYPTION_METHOD_NAME)
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

        private int[] UseEnigma(int[] codesASCII)
        {
            // Setup enigma
            
            // Localise property values (verbosity++)
            byte lowercaseStartRange = UsedAlphabetRangesASCII.lowercase.startRange;
            byte lowercaseEndRange = UsedAlphabetRangesASCII.uppercase.endRange;
            byte uppercaseStartRange = UsedAlphabetRangesASCII.lowercase.startRange;
            byte uppercaseEndRange = UsedAlphabetRangesASCII.uppercase.endRange;

            // Define alphabethical lower-/uppercase ASCII codes
            int[] rotorsSourceLowercase = Enumerable.Range(lowercaseStartRange, (lowercaseEndRange - lowercaseStartRange + 1)).ToArray();
            int[] rotorsSourceUppercase = Enumerable.Range(uppercaseStartRange, (uppercaseEndRange - uppercaseStartRange + 1)).ToArray();

            // Create rotors, copied and Fisher-Yates-shuffled from source arrays
            List<int[]> rotors = new List<int[]>();
            for (int i = 0; i < 6; i++)
            {
                int[] selectedRotorSource = (i % 2 == 0) ? ref rotorsSourceLowercase : ref rotorsSourceUppercase;
                FisherYatesShuffle(ref selectedRotorSource);
                rotors.Add(selectedRotorSource.ToArray());
            }

            // Define alphabethical lower-/uppercase ASCII codes
            int[] reflectorsSourceLowercase = Enumerable.Range(lowercaseStartRange, (lowercaseEndRange - lowercaseStartRange + 1)).ToArray();
            int[] reflectorsSourceUppercase = Enumerable.Range(uppercaseStartRange, (uppercaseEndRange - uppercaseStartRange + 1)).ToArray();

            // Create reflectors (pair of ASCII codes), copied and Fisher-Yates-shuffled from source arrays
            List<int[]> reflectors = new List<int[]>();
            for (int i = 0; i < 1; i++)
            {
                int[] selectedRotorSource = (i % 2 == 0) ? ref rotorsSourceLowercase : ref rotorsSourceUppercase;
                FisherYatesShuffle(ref selectedRotorSource);
                reflectors.Add(new int[]{ selectedRotorSource[0], selectedRotorSource[1] });
            }

            // Use enigma
            
            // Define backing variables
            int currentRotation = 0;
            int currentRotorSet = 1;
            int[] outputCodesASCII = codesASCII.ToArray();

            // Iterate over all ASCII codes representing characters
            foreach (int codeASCII in codesASCII)
            {
                // Defining backing variables
                int currentSignalValue = 0;
                
                // Iterate over all rotors, then (re)write the value of each rotor position
                foreach (int[] rotor in rotors)
                {
                    currentSignalValue = rotor[currentRotation];
                }
                
                // Determine the ASCII code casing (inside upper/lower range?)
                bool isLowercase = (reflectors[currentRotorSet][1] >= lowercaseStartRange) && (reflectors[currentRotorSet][1] >= lowercaseEndRange);

                // Select the corresponding start-/ and end ranges (upper/lower case)
                var startRange = (isLowercase) ? lowercaseStartRange : uppercaseStartRange;
                var endRange = (isLowercase) ? lowercaseEndRange : uppercaseEndRange;

                // Determine whether the ASCII codes are f.e. 8-4 (circular length calculation beyond end range)
                bool isSecondCodeBeyondEndRange = reflectors[currentRotorSet][0] < reflectors[currentRotorSet][1];

                // Define the amount of positions moved alphabetically to realise mapping
                int positionsToBeMoved = 0;
                if (isSecondCodeBeyondEndRange!) {
                    int spaceBetweenFirstCodeAndEndRange = endRange - reflectors[currentRotorSet][0];
                    int spaceBetweenStartRangeAndSecondCode = reflectors[currentRotorSet][1] - startRange;
                    positionsToBeMoved = spaceBetweenFirstCodeAndEndRange + spaceBetweenStartRangeAndSecondCode;
                }
                else
                {
                    positionsToBeMoved = reflectors[currentRotorSet][1] + reflectors[currentRotorSet][0];
                }

                //Move the ASCII code through the alphabet
                int movedCodeASCII = 0;
                bool isToBeMovedBeyondEndRange = ((codeASCII + positionsToBeMoved) > (endRange - codeASCII));
                if (isToBeMovedBeyondEndRange!)
                {
                    int positionsToBeMovedFromStartRange = positionsToBeMoved - (endRange - codeASCII);
                    movedCodeASCII = startRange + positionsToBeMovedFromStartRange;
                }
                else
                {
                    movedCodeASCII = codeASCII + positionsToBeMoved;
                }

                // TODO: Mismatch (i think) between flow codeASCII > currentSignalValue > ... > movedCodeASCII
                // TODO: SRP -> Single Responsability Protocol (too many stuff in one method)
                // TODO: Signal/ASCII moved through rotors, mapped using reflector, but remains to be returned -backwards- through rotors
                // TODO: Backing variables possibly redundant using for-loop instead of foreach
                // TODO: 1 reflector per set of 6 rotors -> appropriate data structure (tuple?)
                // TODO: 1 reflector per set of 6 rotors -> no magic values, const instead
                // TODO: test or research fisher-yates possibility for duplicates
                // TODO: Use of extra lowercase/uppercase layer of cryptography got lost during implementation

                // time's up.
            }


        }

        private void FisherYatesShuffle(ref int[] array)
        {
           // TODO: increase verbosity
            Random random = new Random();
            int arrLength = array.Length;

            while (arrLength > 1)
            {
                arrLength--;
                int nextRandom = random.Next(arrLength + 1);
                int temporarySave = array[nextRandom];
                array[nextRandom] = array[arrLength];
                array[arrLength] = temporarySave;
            }
        }

    }
}
