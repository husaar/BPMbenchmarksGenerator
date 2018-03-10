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

            BenchmarkInstance instance = new BenchmarkInstance(genArgs.NumberOfJobs, genArgs.MachineCapacity, jp);

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
            if (jobProcTimeRange == "[1,10]")
            {
                genArgs.JobProcessingTimeFrom = 1;
                genArgs.JobProcessingTimeTo = 10;
            }
            else if (jobProcTimeRange == "[1,20]")
            {
                genArgs.JobProcessingTimeFrom = 1;
                genArgs.JobProcessingTimeTo = 20;
            }
        }

        public static void SetJobSizeArgs(string jobSizeRange, GenerationArgs genArgs)
        {
            if (jobSizeRange == "[1,10]")
            {
                genArgs.JobSizeFrom = 1;
                genArgs.JobSizeTo = 10;
            }
            else if (jobSizeRange == "[2,4]")
            {
                genArgs.JobSizeFrom = 2;
                genArgs.JobSizeTo = 4;
            }
            else if (jobSizeRange == "[4,8]")
            {
                genArgs.JobSizeFrom = 4;
                genArgs.JobSizeTo = 8;
            }
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

    }
}
