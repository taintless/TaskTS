using System;
using System.IO;

namespace Task
{
    public static class Services
    {
        public static string FormatWrappedString(FileInfoModel fileData)
        {
            var finalText = "";
            while (true)
            {
                if (fileData.Text.Length <= fileData.SymbolsCount)
                {
                    finalText += fileData.Text + Environment.NewLine;
                    break;
                }
                var spaceIndex = fileData.Text.Substring(0,
                    fileData.SymbolsCount + 1).LastIndexOf(" ", StringComparison.Ordinal);

                var textToAdd = fileData.Text.Substring(0,
                    spaceIndex > -1 ? spaceIndex : fileData.SymbolsCount);

                finalText += textToAdd + Environment.NewLine;
                fileData.Text = fileData.Text.Substring(textToAdd.Length).Trim();
            }

            return finalText;
        }

        public static void WriteToFile(string path, string textToWrite)
        {
            File.WriteAllText(path, textToWrite);
        }

        public static string[] ReadFromFile(string path)
        {
            return File.ReadAllLines(path);
        }

        public static int StringToCount(string countInput)
        {
            return int.TryParse(countInput, out int count) && count > 0 ? count : throw new ApplicationException("Invalid data");
        }
    }
}
