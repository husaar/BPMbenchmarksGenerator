using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;
using Moq;
using BPMbenchmarksGenerator;

namespace BPMbenchmarksGenerator.Tests
{
    [TestFixture]
    class BenchmarkInstanceTests
    {
        [Test]
        public void BenchmarkInstance_NewObjectNumberOfJobs_IsCorrect()
        {
            List<JobParameters> list = new List<JobParameters>();
            var jobParametersMock = It.IsAny<JobParameters>();

            list.Add(jobParametersMock);

            var benchmark = new BenchmarkInstance(5, 10, list);

            benchmark.NumberOfJobs.Should().Be(5);
        }

        [Test]
        public void BenchmarkInstance_NewObjectMachineCapacity_IsCorrect()
        {
            List<JobParameters> list = new List<JobParameters>();
            var jobParametersMock = It.IsAny<JobParameters>();

            list.Add(jobParametersMock);

            var benchmark = new BenchmarkInstance(5, 10, list);

            benchmark.MachineCapacity.Should().Be(10);
        }

        [Test]
        public void BenchmarkInstance_NewObjectJobsList_ContaintTwoObjects()
        {
            List<JobParameters> list = new List<JobParameters>();
            var jobParametersMock = It.IsAny<JobParameters>();

            list.Add(jobParametersMock);
            list.Add(jobParametersMock);

            var benchmark = new BenchmarkInstance(5, 10, list);

            benchmark.JobsList.Should().HaveCount(2);
        }
    }
}
