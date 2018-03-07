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
    class BPMGeneratorMethodsTests
    {
        [Test]
        public void ParseStringToInteger_IncorrectString_FormatExceptionIsThrown()
        {
            Assert.Throws<FormatException>(() => BPMGeneratorMethods.ParseStringToInteger("IncorrectString_123,,a", 1));
        }
    }
}
