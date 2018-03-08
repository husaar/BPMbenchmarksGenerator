using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMbenchmarksGenerator
{
    class BenchmarkInstance
    {
        private int numberOfJobs;
        private int machineCapacity;

        private readonly List<JobParameters> jobsList;

        public BenchmarkInstance(int numberOfJobs, int machineCapacity, List<JobParameters> jobList)
        {
            this.numberOfJobs = numberOfJobs;
            this.machineCapacity = machineCapacity;
            this.jobsList = jobList;
        }

        public override string ToString()
        {
            string s = string.Format($"{numberOfJobs},{machineCapacity},\n");

            foreach (JobParameters jp in jobsList)
            {
                s = s + string.Format("{0}\n", jp);
            }

            return s;
        }
    }

}
