using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Controls;

namespace BPMbenchmarksGenerator
{
    public class BPMGeneratorMethods
    {
        public static int ParseStringToInteger(string s, int lowestPossibleNumber)
        {
            int integer = -2;
            string exceptionMessage = null;
            try
            {
                integer = int.Parse(s);
            }
            catch (FormatException)
            {
                exceptionMessage = "Provided number has to be integer!";
                throw new FormatException(exceptionMessage);
            }

            if (integer < lowestPossibleNumber)
            {
                exceptionMessage = string.Format($"Integer value should be at least {lowestPossibleNumber.ToString()}.");
                throw new Exception(exceptionMessage);
            }

            return integer;
        }

        public static int ParseStringToInteger(string s, TextBlock sourceMessage, int lowestPossibleNumber)
        {
            int integer = -3;
            string exceptionMessage = null;
            try
            {
                integer = int.Parse(s);
            }
            catch (FormatException)
            {
                exceptionMessage = sourceMessage.Text.Trim(':') + " has to be integer!";
                throw new FormatException(exceptionMessage);
            }

            if (integer < lowestPossibleNumber)
            {
                exceptionMessage = string.Format($"{sourceMessage.Text.Trim(':')} should be at least {lowestPossibleNumber.ToString()}.");
                throw new Exception(exceptionMessage);
            }

            return integer;
        }

        public static string GetStartingDirectory()
        {
            return Directory.GetCurrentDirectory();
        }

        public static string CurrentSaveDirectoryStatus(string directory)
        {
            string status = "";
            if (directory != "")
            {
                status = "Ready for benchmark generation.\n\n";
                status += "Benchmarks will be saved in:\n";
                status += directory; //BPMGeneratorMethods.GetStartingDirectory();
                status += "\n\nClick Path to change directory. \n\n";
            }
            else
            {
                status = "Please select direcotry were bencharks will be saved.";
            }

            return status;
        }

    }
}
