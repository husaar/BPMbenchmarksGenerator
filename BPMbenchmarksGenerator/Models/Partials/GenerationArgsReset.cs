using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPMbenchmarksGenerator.Interfaces;

namespace BPMbenchmarksGenerator.Models
{
    public partial class GenerationArgs : IGenerationArgs
    {
        public void Reset()
        {
            NumberOfJobs = -1;
            MachineCapacity = -1;
            JobProcessingTimeFrom = -1;
            JobProcessingTimeTo = -1;
            JobSizeFrom = -1;
            JobSizeTo = -1;
        }
    }
}
