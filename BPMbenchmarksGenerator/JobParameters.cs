using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMbenchmarksGenerator
{
    class JobParameters
    {
        private int jobIndex;
        private int jobProcessingTime;
        private int jobSize;

        public JobParameters(int jobIndex, int jobProcessingTime, int jobSize)
        {
            this.jobIndex = jobIndex;
            this.jobProcessingTime = jobProcessingTime;
            this.jobSize = jobSize;
        }

        public override string ToString()
        {
            return string.Format($"{this.jobIndex},{this.jobProcessingTime},{this.jobSize},");
        }
    }
}
