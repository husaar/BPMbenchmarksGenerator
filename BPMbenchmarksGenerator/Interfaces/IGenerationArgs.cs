using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMbenchmarksGenerator.Interfaces
{
    public interface IGenerationArgs
    {
        int NumberOfJobs { get; set; }
        int MachineCapacity { get; set; }
        int JobProcessingTimeFrom { get; set; }
        int JobProcessingTimeTo { get; set; }
        int JobSizeFrom { get; set; }
        int JobSizeTo { get; set; }
    }
}
