using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPMbenchmarksGenerator.Interfaces;

namespace BPMbenchmarksGenerator.Models
{
    public partial class JobParameters : IJobParameters
    {
        public int JobParametersIndex { get; }
        public int JobProcessingTime { get; }
        public int JobSize { get; } 

        public JobParameters(int jobIndex, int jobProcessingTime, int jobSize)
        {
            JobParametersIndex = jobIndex;
            JobProcessingTime = jobProcessingTime;
            JobSize = jobSize;
        }

    }
}
