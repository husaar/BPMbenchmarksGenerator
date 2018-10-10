using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using BPMbenchmarksGenerator.Interfaces;

namespace BPMbenchmarksGenerator.Models
{
    public partial class BenchmarkInstance : IBenchmarkInstance
    {
        public int NumberOfJobs { get; }
        public int MachineCapacity { get; }
        public string Name { get; }

        private readonly IList<IJobParameters> jobsList;
        private ReadOnlyCollection<IJobParameters> readonlyJobList;

        public ReadOnlyCollection<IJobParameters> JobsList
        {
            get
            {
                if (readonlyJobList == null)
                {
                    readonlyJobList = new ReadOnlyCollection<IJobParameters>(jobsList);
                }

                return readonlyJobList;
            }
        }

        public BenchmarkInstance(int numberOfJobs, int machineCapacity, string name, IList<IJobParameters> jobList)
        {
            NumberOfJobs = numberOfJobs;
            MachineCapacity = machineCapacity;
            Name = name;
            jobsList = jobList;            
        }
    }

}
