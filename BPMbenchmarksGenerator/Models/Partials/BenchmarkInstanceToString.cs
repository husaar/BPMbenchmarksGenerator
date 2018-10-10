using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using BPMbenchmarksGenerator.Interfaces;

namespace BPMbenchmarksGenerator.Models
{
    public partial class BenchmarkInstance : IBenchmarkInstance
    {
        public override string ToString()
        {
            string s = string.Format($"{NumberOfJobs},{MachineCapacity},\n");

            foreach (IJobParameters jp in jobsList)
            {
                s = s + string.Format("{0}\n", jp);
            }

            return s;
        }
    }
}
