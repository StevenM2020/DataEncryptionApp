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
            File.WriteAllText(GetPath(path), text);
        }

        // Reads the contents of a file and returns it as a string
        internal static string GetString(string path)
        {
            return File.ReadAllText(GetPath(path));
        }

        // Gets the path of the executable and combines it with the file name
        private static string GetPath(string fileName)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            return Path.Combine(baseDirectory, fileName);
        }
    }
}
