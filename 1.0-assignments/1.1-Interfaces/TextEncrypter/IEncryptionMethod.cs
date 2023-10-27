namespace TextEncrypter
{
    internal interface IEncryptionMethod
    {
        //[»] Constant variable members
        static (byte startLowercase, byte endLowercase) ASCII_ROMAN_ALPHABET_LOWERCASE_RANGE => (97, 122);
        static (byte startUppercase, byte endUppercase) ASCII_ROMAN_ALPHABET_UPPERCASE_RANGE => (65, 90);

        //[»] Property members
        string Name { get; }
        abstract Func<string, string> Encode { get; }
        abstract Func<string, string> Decode { get; }

        // Tuple of 2 named tuples (tuple voor immutables, struct voor mutables)
        ((byte startRange, byte endRange) lowercase, (byte startRange, byte endRange) uppercase) UsedAlphabetRangesASCII { get; }

        //[»] Primary method members
        string EncodeString(string uncodedInputString);
        string DecodeString(string encodedInputString);

        bool[] ExtractCasingScheme(char[] arrInputCharacters);
        void ApplyCasingScheme(CryptographyDetails cryptographyDetails);
        
        //[»] Secondary method members
    }
}