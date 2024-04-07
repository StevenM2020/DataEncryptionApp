// Program:     EncryptionApp
// Author:      Steven Motz
// Date:        4/6/2024
// Description: This program demonstrates how to encrypt and decrypt a string using the AES algorithm and save the encrypted string to a file

using Encryption = EncryptionApp.Encryption;
using Storage = EncryptionApp.Storage;

namespace EncryptionApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        // When the button is clicked, encrypt the text and save it to a file and then decrypt the text from the file
        private void OnActionClick(object sender, EventArgs e)
        {
            // Encrypt the text and save it to a file
            string text = txtData.Text;
            (byte[] key, byte[] iv) = Encryption.GenerateKeyAndIV();
            string encryptedText = Encryption.Encrypt(text, key, iv);
            Storage.SaveString(encryptedText, "encrypted.txt");
            lblEncrypted.Text = "Encrypted String: " +  encryptedText;

            // Decrypt the encrypted text from the file
            string encryptedTextFromFile = Storage.GetString("encrypted.txt");
            string decryptedText = Encryption.Decrypt(encryptedTextFromFile, key, iv);
            lblDecrypted.Text = "Decrypted String: " + decryptedText;

        }
    }

}