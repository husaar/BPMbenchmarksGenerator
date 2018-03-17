using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMbenchmarksGenerator.Interfaces
{
    public interface IJobParameters
    {
        int JobParametersIndex { get; }
        int JobProcessingTime { get; }
        int JobSize { get; }

    }
}
