using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEncrypter.EncryptionMethods
{
    internal class EncryptionMethodMixer
    {
        static public string EncodeMixedEncryptionMethods(string input, List<IEncryptionMethod> methods)
        {
            string encoded = String.Empty;
            for (int i = 0; i < methods.Count; i++)
            {
                string outputTemporary = methods[i].Encode((encoded == String.Empty) ? input : encoded);
                encoded = outputTemporary;
            }
            return encoded;
        }

        static public string DecodeMixedEncryptionMethods(string input, List<IEncryptionMethod> methods)
        {
            string decoded = String.Empty;
            for (int i = 0; i < methods.Count; i++)
            {
                string outputTemporary = methods[i].Decode((decoded == String.Empty) ? input : decoded);
                decoded = outputTemporary;
            }
            return decoded;
        }
    }
}
