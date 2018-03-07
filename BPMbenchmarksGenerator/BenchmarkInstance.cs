using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMbenchmarksGenerator
{
    class BenchmarkInstance
    {
        public int NumberOfJobs { get; }
        public int MachineCapacity { get; }

        private readonly List<JobParameters> jobsList;

        public List<JobParameters> JobsList
        {
            get { return this.jobsList; }
        }

        public BenchmarkInstance(int numberOfJobs, int machineCapacity, List<JobParameters> jobList)
        {
            NumberOfJobs = numberOfJobs;
            MachineCapacity = machineCapacity;
            jobsList = jobList;
        }
    }
}
