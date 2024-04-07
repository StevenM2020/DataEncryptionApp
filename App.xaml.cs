namespace EncryptionApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }


        // this method is used to set the size of the window
        protected override Window CreateWindow(IActivationState activationState)
        {
            Window window = base.CreateWindow(activationState);
            window.Height = 750;
            window.Width = 600;
            return window;
        }

        // change this method to return true to see debug messages
        public static bool DebugMessagesOn()
        {
            return true;
        }
    }
}
