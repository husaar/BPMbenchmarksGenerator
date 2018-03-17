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
            generationArgs.JobProcessingTimeTo == 12
            );

            JobParameters jb = BPMGeneratorMethods.GenerateJobParameters(idx, generationArgsMock);

            jb.JobProcessingTime.Should().BeInRange(generationArgsMock.JobProcessingTimeFrom, generationArgsMock.JobProcessingTimeTo);
        }

        [Test]
        public void GenerateJobParameters_JobSize_RangeIsCorrect()
        {
            int idx = 2;
            IGenerationArgs generationArgsMock = Mock.Of<IGenerationArgs>(generationArgs =>
            generationArgs.JobSizeFrom == 55 &&
            generationArgs.JobSizeTo == 60
            );

            JobParameters jb = BPMGeneratorMethods.GenerateJobParameters(idx, generationArgsMock);

            jb.JobSize.Should().BeInRange(generationArgsMock.JobSizeFrom, generationArgsMock.JobSizeTo);
        }

        [Test]
        public void GenerateOneBencharkInstance_MachineCapacity_ValueIsCorrect()
        {
            IGenerationArgs generationArgsMock = Mock.Of<IGenerationArgs>(generationArgs =>
            generationArgs.MachineCapacity == 55);

            BenchmarkInstance bi = BPMGeneratorMethods.GenerateOneBencharkInstance(generationArgsMock);

            bi.MachineCapacity.Should().Be(generationArgsMock.MachineCapacity);

        }

        [Test]
        public void GenerateOneBencharkInstance_NumberOfJobs_ValueIsCorrect()
        {
            IGenerationArgs generationArgsMock = Mock.Of<IGenerationArgs>(generationArgs =>
            generationArgs.NumberOfJobs == 10);

            BenchmarkInstance bi = BPMGeneratorMethods.GenerateOneBencharkInstance(generationArgsMock);

            bi.NumberOfJobs.Should().Be(generationArgsMock.NumberOfJobs);
        }

        [Test]
        public void GenerateOneBencharkInstance_JobParametersList_LengthIsCorrect()
        {
            IGenerationArgs generationArgsMock = Mock.Of<IGenerationArgs>(generationArgs =>
            generationArgs.NumberOfJobs == 10);

            BenchmarkInstance bi = BPMGeneratorMethods.GenerateOneBencharkInstance(generationArgsMock);

            bi.JobsList.Should().HaveCount(generationArgsMock.NumberOfJobs);
        }

        [TestCase("[2,7]")]
        [TestCase("[ 2, 7]")]
        [TestCase("[ 2, 7 ]")]
        [TestCase("[2     , 7]")]
        [TestCase("[  2  ,   7  ]")]
        public void DecomposeSquareBracketStringToInts_CorrectStringArgument_ArrayLengthIsCorrect(string sqBracket)
        {
            int[] decomposedArgs = BPMGeneratorMethods.DecomposeSquareBracketStringToInts(sqBracket);

            decomposedArgs.Should().HaveCount(2);
        }

        [TestCase("[2,7]")]
        [TestCase("[ 2, 7]")]
        [TestCase("[ 2, 7 ]")]
        [TestCase("[2     , 7]")]
        [TestCase("[  2  ,   7  ]")]
        public void DecomposeSquareBracketStringToInts_CorrectStringArgument_ArrayFirstElementIsCorrect(string sqBracket)
        {
            int[] decomposedArgs = BPMGeneratorMethods.DecomposeSquareBracketStringToInts(sqBracket);

            decomposedArgs[0].Should().Be(2);
        }


        [TestCase("[2,7]")]
        [TestCase("[ 2, 7]")]
        [TestCase("[ 2, 7 ]")]
        [TestCase("[2     , 7]")]
        [TestCase("[  2  ,   7  ]")]
        public void DecomposeSquareBracketStringToInts_CorrectStringArgument_ArraySecondElementIsCorrect(string sqBracket)
        {
            int[] decomposedArgs = BPMGeneratorMethods.DecomposeSquareBracketStringToInts(sqBracket);

            decomposedArgs[1].Should().Be(7);
        }
    }
}
