// Class:       Encryption
// Author:      Steven Motz
// Date:        4/6/2024
// Description: This class provides methods for encrypting and decrypting strings using the AES algorithm

using System.Security.Cryptography;

namespace EncryptionApp
{
    internal static class Encryption
    {
        // Encrypts a string and returns the encrypted data as a base64 string using the AES algorithm
        internal static string Encrypt(string text, byte[] key, byte[] iv)
        {
            try
            {


                using var aesAlg = Aes.Create();
                aesAlg.Key = key;
                aesAlg.IV = iv;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV); // encryptor object
                using var ms = new MemoryStream(); // temporary storage
                using var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write); // stream for encryption
                using var sw = new StreamWriter(cs); // writes data to the stream

                sw.Write(text); // encrypt the data

                // stops the empty string errors
                sw.Flush(); // all data is written to the stream
                cs.FlushFinalBlock(); // all data is processed
                ms.Position = 0; // set the position to the beginning of the stream so I stop getting empty strings!

                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception e)
            {
                if (App.DebugMessagesOn())
                    Console.WriteLine("Error: " + e.Message);
                return null;
            }
        }

        // Generates a key and IV for the AES algorithm
        // from my understanding, the key is used to encrypt the data and the IV is used to make the encryption more secure by adding randomness
        internal static (byte[] key, byte[] iv) GenerateKeyAndIV()
        {
            try
            {
                using (var aes = Aes.Create())
                {
                    aes.GenerateKey();
                    aes.GenerateIV();
                    return (aes.Key, aes.IV);
                }
            }
            catch (Exception e)
            {
                if (App.DebugMessagesOn())
                    Console.WriteLine("Error: " + e.Message);
                return (null, null);
            }
        }

        // Decrypts a base64 string and returns the decrypted data as a string using the AES algorithm
        internal static string Decrypt(string encryptedText, byte[] key, byte[] iv)
        {
            try
            {
                byte[] cipher = Convert.FromBase64String(encryptedText);

                using var aesAlg = Aes.Create();
                aesAlg.Key = key;
                aesAlg.IV = iv;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV); // decryptor object
                using var ms = new MemoryStream(cipher); // temporary storage for the encrypted data
                using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read); // stream for decryption
                using var sr = new StreamReader(cs); // reads decrypted data from the stream

                return sr.ReadToEnd();
            }
            catch (Exception e)
            {
                if (App.DebugMessagesOn())
                    Console.WriteLine("Error: " + e.Message);
                return null;
            }
        }

    }
}
//https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography?view=net-8.0
//https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.cryptostream?view=net-8.0