/************************************************************************************************/
//
//         Usage: AESLib.Encrypt(CipherMode(CTR, CBC, ...), BlockSize(128 or 256), 
//                                BytesToBeEncryptedAsByteArray, KeyAsByteArray)
//
//                AESLib.Decrypt(CipherMode(CTR, CBC, ...), BlockSize(128 or 256), 
//                                BytesToBeDecryptedAsByteArray, KeyAsByteArray)
//
/************************************************************************************************/


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

class AESLib
{
    public static byte[] Encrypt(CipherMode cphMode, int blockSize, byte[] input, byte[] key)
    {
        if (input.Length != blockSize) return null;

        byte[] output = null;

        using (MemoryStream ms = new MemoryStream())
        {
            using (RijndaelManaged aes = new RijndaelManaged())
            {
                aes.Mode = cphMode;
                aes.BlockSize = blockSize;
                aes.KeySize = blockSize;
                aes.Padding = PaddingMode.PKCS7;
                aes.IV = key;

                aes.Key = key;

                using (CryptoStream cryptoStream = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cryptoStream.Write(input, 0, input.Length);
                    cryptoStream.Close();
                }

                output = ms.ToArray();

            }
        }

        return output;
    }

    public static byte[] Decrypt(CipherMode cphMode, int blockSize, byte[] input, byte[] key)
    {
        if (input.Length != blockSize) return null;

        byte[] output = null;

        using (MemoryStream ms = new MemoryStream())
        {
            using (RijndaelManaged aes = new RijndaelManaged())
            {
                aes.Mode = cphMode;
                aes.BlockSize = blockSize;
                aes.KeySize = blockSize;
                aes.Padding = PaddingMode.PKCS7;
                aes.IV = key;

                aes.Key = key;

                using (var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(input, 0, input.Length);
                    cs.Close();
                }

                output = ms.ToArray();

            }
        }

        return output;
    }
}
