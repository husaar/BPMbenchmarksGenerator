using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace BPMbenchmarksGenerator
{
    public class BPMGeneratorMethods
    {

        private static Random r = new Random(DateTime.Now.Millisecond);

        public static BenchmarkInstance GenerateOneBencharkInstance(GenerationArgs genArgs)
        {
            List<JobParameters> jp = new List<JobParameters>();

            try
            {
                for (int i = 0; i < genArgs.NumberOfJobs; i++)
                {
                    jp.Add(GenerateJobParameters(i,genArgs));
                }
            }
            catch(ArgumentOutOfRangeException)
            {
                throw new ArgumentOutOfRangeException("Job processing or job size values are not in order. Check Customize tab.");
            }

            string instanceName = "J" + genArgs.NumberOfJobs.ToString() +
                "p" + genArgs.JobProcessingTimeFrom  + genArgs.JobProcessingTimeTo +
                "s" + genArgs.JobSizeFrom + genArgs.JobSizeTo;

            BenchmarkInstance instance = new BenchmarkInstance(genArgs.NumberOfJobs, genArgs.MachineCapacity, instanceName, jp);

            return instance;
        }

        private static JobParameters GenerateJobParameters(int index, GenerationArgs gArgs)
        {
            return new JobParameters(index, r.Next(gArgs.JobProcessingTimeFrom, gArgs.JobProcessingTimeTo),
                        r.Next(gArgs.JobSizeFrom, gArgs.JobSizeTo));
        }

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

        public static void SetNumberOfJobsArgs(string numberOfJobs, GenerationArgs genArgs)
        {
            genArgs.NumberOfJobs = int.Parse(numberOfJobs);
        }

        public static void SetJobProcTimeArgs(string jobProcTimeRange, GenerationArgs genArgs)
        {
            int[] jobProcArgs = DecomposeSquareBracketStringToInts(jobProcTimeRange);

            try
            {
                genArgs.JobProcessingTimeFrom = jobProcArgs[0];
                genArgs.JobProcessingTimeTo = jobProcArgs[1];
            }
            catch (System.NullReferenceException nrex)
            {
                MessageBox.Show($"Message: {nrex.Message} \n Source: {nrex.Source}");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Message: {ex.Message} \n Source: {ex.Source}");
            }
        }

        public static void SetJobSizeArgs(string jobSizeRange, GenerationArgs genArgs)
        {
            int[]  jobSizeArgs = DecomposeSquareBracketStringToInts(jobSizeRange);

            try
            {
                genArgs.JobSizeFrom = jobSizeArgs[0];
                genArgs.JobSizeTo = jobSizeArgs[1];
            }
            catch (System.NullReferenceException nrex)
            {
                MessageBox.Show($"Message: {nrex.Message} \n Source: {nrex.Source}");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Message: {ex.Message} \n Source: {ex.Source}");
            }
        }

        public static int[] DecomposeSquareBracketStringToInts(string squareBracket)
        //correct squareBracket format: [arg1,arg2]
        {
            string[] substrings = squareBracket.Split(new char[] { '[', ',', ']' });

            try
            {
                //subs array first and last elements are "", because delimiters '[' and ']' were placed at the beginning and end of the string str
                int[] decomposedArgs = new int[] { int.Parse(substrings[1]), int.Parse(substrings[2]) };
                return decomposedArgs;
            }
            catch(FormatException fex)
            {
                MessageBox.Show($"Message: {fex.Message} \n Source: {fex.Source}");
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Message: {ex.Message} \n Source: {ex.Source}");
            }


            return null;
           
        }

        public static void SetMachineCapacityArgs(string machineCapacity, GenerationArgs genArgs)
        {
            genArgs.MachineCapacity = int.Parse(machineCapacity);
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

        public static string UpdateStatusWithGenArgsAndSaveDirectory(GenerationArgs genArgs, string directory)
        {
            string status = "";

            status = "Benchmarks parameters: \n";
            status += string.Format($"Jobs: {genArgs.NumberOfJobs} \n Machine Capacity: {genArgs.MachineCapacity}\n");
            status += string.Format($"Proc. time: [ {genArgs.JobProcessingTimeFrom} , {genArgs.JobProcessingTimeTo} ]\n");
            status += string.Format($"Sizes: [ {genArgs.JobSizeFrom} , {genArgs.JobSizeTo} ]\n\n");

            status += "Benchmark instnaces will be saved in: \n";
            status += directory + "\n\n";

            return status;
        }

        public static string UpdateStatusWithGenerationArgs(GenerationArgs genArgs, TextBox txStatus)
        {
            string status = txStatus.Text;

            status += string.Format($"Jobs: {genArgs.NumberOfJobs} \n Machine Capacity: {genArgs.MachineCapacity}\n");
            status += string.Format($"Proc. time: [ {genArgs.JobProcessingTimeFrom} , {genArgs.JobProcessingTimeTo} ]\n");
            status += string.Format($"Sizes: [ {genArgs.JobSizeFrom} , {genArgs.JobSizeTo} ]\n\n");

            return status;
        }

        public static string UpdateStatusAsSuccessful(TextBox txStatus)
        {
            string status = txStatus.Text;

            status += string.Format($"Benchmark generation finished successfully!");

            return status;
        }

        public static void PrintBenchmarkToFile(BenchmarkInstance instance, string destination)
        {
            try
            {
                File.WriteAllText(destination, instance.ToString());
            }
            catch (ArgumentNullException anex)
            {
                MessageBox.Show(anex.Message);
            }
            catch (ArgumentException aex)
            {
                MessageBox.Show(aex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public static void PrintAllGeneratedBenchmarksToMessageBox(List<BenchmarkInstance> allBenchmarks)
        {
            foreach (BenchmarkInstance b in allBenchmarks)
            {
                MessageBox.Show(b.ToString(), b.Name);
            }
        }

    }
}
