// Class:       Storage
// Author:      Steven Motz
// Date:        4/6/2024
// Description: This class provides methods for saving and reading from a file

namespace EncryptionApp
{
    internal static class Storage
    {
        // Saves a string to a file
        internal static void SaveString(string text, string path)
        {
            try
            {
                File.WriteAllText(GetPath(path), text);
            }
            catch (Exception e)
            {
                if (App.DebugMessagesOn())
                    Console.WriteLine("Error: " + e.Message);
            }
        }

        // Reads the contents of a file and returns it as a string
        internal static string GetString(string path)
        {
            try
            {
                return File.ReadAllText(GetPath(path));
            }
            catch (Exception e)
            {
                if (App.DebugMessagesOn())
                    Console.WriteLine("Error: " + e.Message);
                return null;
            }
        }

        // Gets the path of the executable and combines it with the file name
        private static string GetPath(string fileName)
        {
            try
            {
                string appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string withAppName = Path.Combine(appData, "EncryptionApp");
                Directory.CreateDirectory(withAppName);
                return Path.Combine(withAppName, fileName);
            }
            catch (Exception e)
            {

                return null;
            }
        }
    }
}
