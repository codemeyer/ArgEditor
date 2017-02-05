using System;
using System.IO;

namespace ArgEditor.Tests
{
    public static class ExampleDataHelper
    {
        public static string GetExampleDataPath(string fileName)
        {
            return Path.Combine(GetExampleDataBaseFolder(), fileName);
        }

        private static string GetExampleDataBaseFolder()
        {
            string directory = AppDomain.CurrentDomain.BaseDirectory;

            return Path.Combine(directory, @"..\..\..\..\TestData\");
        }
    }
}
