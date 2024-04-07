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

        /* When the button is clicked, encrypt the text and save it
         to a file and then decrypt the text from the file*/
        private void OnActionClick(object sender, EventArgs e)
        {
            try
            {
                string text = txtData.Text;

                // Check if the text is empty
                if (text == null || text.Trim() == "")
                {
                    DisplayAlert("Error", "Please enter some text to encrypt.", "OK");
                    return;
                }

                // Encrypt the text and save it to a file
                (byte[] key, byte[] iv) = Encryption.GenerateKeyAndIV();
                string encryptedText = Encryption.Encrypt(text, key, iv);
                Storage.SaveString(encryptedText, "encrypted.txt");
                lblEncrypted.Text = "Encrypted String: " + encryptedText;

                // Decrypt the encrypted text from the file
                string encryptedTextFromFile = Storage.GetString("encrypted.txt");
                string decryptedText = Encryption.Decrypt(encryptedTextFromFile, key, iv);
                lblDecrypted.Text = "Decrypted String: " + decryptedText;

                // tell the user where the file is located
                lblFileLocation.Text = "Your data is securely stored in your appdata packages";

            }
            catch (Exception ex)
            {
                DisplayAlert("Error", "An error occurred", "OK");
                if (App.DebugMessagesOn())
                    Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

}