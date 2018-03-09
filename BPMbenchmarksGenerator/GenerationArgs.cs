using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMbenchmarksGenerator
{
    public class GenerationArgs
    {
        public int NumberOfJobs { get; }
        public int MachineCapacity { get; }
        public int JobProcessingTimeFrom { get; }
        public int JobProcessingTimeTo { get; }
        public int JobSizeFrom { get; }
        public int JobSizeTo { get; }

        public GenerationArgs(int numberOfJobs, int machineCapacity, int jobProcessingTimeFrom, 
            int jobProcessingTimeTo, int jobSizeFrom, int jobSizeTo)
        {
            NumberOfJobs = numberOfJobs;
            MachineCapacity = machineCapacity;
            JobProcessingTimeFrom = jobProcessingTimeFrom;
            JobProcessingTimeTo = jobProcessingTimeTo;
            JobSizeFrom = jobSizeFrom;
            JobSizeTo = jobSizeTo;
        }
    }
}
