using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind.Tests
{
    internal class HintGeneratorTests
    {
        [Test]
        public void Test_AllCorrect()
        {
            Assert.That(HintGenerator.GenerateHint("1234", "1234"), Is.EqualTo("++++"));
        }

        [Test]
        public void Test_AllIncorrect()
        {
            Assert.That(HintGenerator.GenerateHint("1234", "5566"), Is.EqualTo(""));
        }

        [Test]
        public void Test_SomeCorrect()
        {
            Assert.That(HintGenerator.GenerateHint("1234", "1243"), Is.EqualTo("++--"));
        }

        [Test]
        public void Test_AllCorrectJustInWrongPositions()
        {
            Assert.That(HintGenerator.GenerateHint("1234", "4321"), Is.EqualTo("----"));
        }

        [Test]
        public void Test_ExampleFromDirections()
        {
            Assert.That(HintGenerator.GenerateHint("1234", "4233"), Is.EqualTo("++-"));
        }
    }
}
