using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace BPMbenchmarksGenerator.Interfaces
{
    public interface IBenchmarkInstance
    {
        int NumberOfJobs { get; }
        int MachineCapacity { get; }
        string Name { get; }

        ReadOnlyCollection<IJobParameters> JobsList { get; }
    }
}
