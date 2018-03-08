using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace BPMbenchmarksGenerator
{
    public class BenchmarkInstance
    {
        public int NumberOfJobs { get; }
        private int MachineCapacity { get; }

        private readonly List<JobParameters> jobsList;
        private ReadOnlyCollection<JobParameters> readonlyJobList;

        public ReadOnlyCollection<JobParameters> JobsList
        {
            get
            {
                if (readonlyJobList == null)
                {
                    readonlyJobList = new ReadOnlyCollection<JobParameters>(jobsList);
                }

                return readonlyJobList;
            }
        }

        public BenchmarkInstance(int numberOfJobs, int machineCapacity, List<JobParameters> jobList)
        {
            NumberOfJobs = numberOfJobs;
            MachineCapacity = machineCapacity;
            jobsList = jobList;
        }

        public override string ToString()
        {
            string s = string.Format($"{NumberOfJobs},{MachineCapacity},\n");

            foreach (JobParameters jp in jobsList)
            {
                s = s + string.Format("{0}\n", jp);
            }

            return s;
        }
    }

}
