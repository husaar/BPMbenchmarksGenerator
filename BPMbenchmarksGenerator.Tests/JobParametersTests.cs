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
    class JobParametersTests
    {
        [Test]
        public void JobParameters_NewObjectJobParametersIndex_IsCorrect()
        {
            var jobParameters = new JobParameters(2, 33, 5);
            jobParameters.JobParametersIndex.Should().Be(2);
        }

        [Test]
        public void JobParameters_NewObjectJobProcessingTime_IsCorrect()
        {
            var jobParameters = new JobParameters(2, 33, 5);
            jobParameters.JobProcessingTime.Should().Be(33);
        }

        [Test]
        public void JobParameters_NewObjectJobSize_IsCorrect()
        {
            var jobParameters = new JobParameters(2, 33, 5);
            jobParameters.JobSize.Should().Be(5);
        }
    }
}
