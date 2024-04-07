using Storage = EncryptionApp.Encryption;


namespace EncryptionApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnActionClick(object sender, EventArgs e)
        {
            string text = txtData.Text;
            (byte[] key, byte[] iv) = Encryption.GenerateKeyAndIV();
            string encryptedText = Encryption.Encrypt(text, key, iv);
            lblEncrypted.Text = "Encrypted String: " +  encryptedText;
            string decryptedText = Encryption.Decrypt(encryptedText, key, iv);
            lblDecrypted.Text = "Decrypted String: " + decryptedText;
        }
    }

}
