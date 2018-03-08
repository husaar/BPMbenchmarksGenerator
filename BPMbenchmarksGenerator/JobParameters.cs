using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMbenchmarksGenerator
{
    public class JobParameters
    {
        private int JobParametersIndex { get; }
        private int JobProcessingTime { get; }
        private int JobSize { get; } 

        public JobParameters(int jobIndex, int jobProcessingTime, int jobSize)
        {
            JobParametersIndex = jobIndex;
            JobProcessingTime = jobProcessingTime;
            JobSize = jobSize;
        }

        public override string ToString()
        {
            return string.Format($"{JobParametersIndex},{JobProcessingTime},{JobSize},");
        }
    }
}
