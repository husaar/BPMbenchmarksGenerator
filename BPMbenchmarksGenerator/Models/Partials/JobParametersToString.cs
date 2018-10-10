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
        public override string ToString()
        {
            return string.Format($"{JobParametersIndex},{JobProcessingTime},{JobSize},");
        }
    }
}
