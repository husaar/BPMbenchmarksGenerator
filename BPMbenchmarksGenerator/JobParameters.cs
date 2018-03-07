using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMbenchmarksGenerator
{
    class JobParameters
    {
        public int JobProcessingTime { get; }
        public int JobSize { get; }

        public JobParameters(int jobProcessingTime, int jobSize)
        {
            JobProcessingTime = jobProcessingTime;
            JobSize = jobSize;
        }
    }
}
