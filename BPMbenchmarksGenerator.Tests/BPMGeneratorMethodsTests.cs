using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;
using Moq;
using BPMbenchmarksGenerator;
using BPMbenchmarksGenerator.Interfaces;

namespace BPMbenchmarksGenerator.Tests
{
    [TestFixture]
    class BPMGeneratorMethodsTests
    {
        [Test]
        public void ParseStringToInteger_IncorrectString_FormatExceptionIsThrown()
        {
            Assert.Throws<FormatException>(() => BPMGeneratorMethods.ParseStringToInteger("IncorrectString_123,,a", 1));
        }

        [Test]
        public void GenerateJobParameters_JobProcessingTime_RangeIsCorrect()
        {
            int idx = 2;
            IGenerationArgs generationArgsMock = Mock.Of<IGenerationArgs>(generationArgs =>
            generationArgs.JobProcessingTimeFrom == 10 &&
            generationArgs.JobProcessingTimeTo == 12 &&
            generationArgs.JobSizeFrom == 55 &&
            generationArgs.JobSizeTo == 60
            );

            JobParameters jb = BPMGeneratorMethods.GenerateJobParameters(idx, generationArgsMock);

            jb.JobProcessingTime.Should().BeInRange(generationArgsMock.JobProcessingTimeFrom, generationArgsMock.JobProcessingTimeTo);       
        }

        [Test]
        public void GenerateJobParameters_JobSize_RangeIsCorrect()
        {
            int idx = 2;
            IGenerationArgs generationArgsMock = Mock.Of<IGenerationArgs>(generationArgs =>
            generationArgs.JobProcessingTimeFrom == 10 &&
            generationArgs.JobProcessingTimeTo == 12 &&
            generationArgs.JobSizeFrom == 55 &&
            generationArgs.JobSizeTo == 60
            );

            JobParameters jb = BPMGeneratorMethods.GenerateJobParameters(idx, generationArgsMock);

            jb.JobSize.Should().BeInRange(generationArgsMock.JobSizeFrom, generationArgsMock.JobSizeTo);
        }
    }
}
