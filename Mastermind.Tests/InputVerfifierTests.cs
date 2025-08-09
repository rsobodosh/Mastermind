namespace Mastermind.Tests
{
    public class InputVerfifierTests
    {
        [Test]
        public void Test_EmptyInput()
        {
            Assert.That(InputVerifier.VerifyUserInput(string.Empty), Is.EqualTo((false, "Input was empty.")));
        }

        [Test]
        public void Test_LongInput()
        {
            Assert.That(InputVerifier.VerifyUserInput("12345"), Is.EqualTo((false, $"Input was longer than {Common.MAX_NUM_CHARS} characters. Input must be {Common.MAX_NUM_CHARS} characters in length.")));
        }

        [Test]
        public void Test_ShortInput()
        {
            Assert.That(InputVerifier.VerifyUserInput("123"), Is.EqualTo((false, $"Input was shorter than {Common.MAX_NUM_CHARS} characters. Input must be {Common.MAX_NUM_CHARS} characters in length.")));
        }

        [Test]
        public void Test_NonNumericInput()
        {
            Assert.That(InputVerifier.VerifyUserInput("abcd"), Is.EqualTo((false, $"Input must only contain digits ranging from {Common.MIN_CHAR} to {Common.MAX_CHAR}.")));
        }

        [Test]
        public void Test_NonNumericLongInput()
        {
            Assert.That(InputVerifier.VerifyUserInput("abcde"), Is.EqualTo((false, $"Input was longer than {Common.MAX_NUM_CHARS} characters. Input must be {Common.MAX_NUM_CHARS} characters in length. Input must only contain digits ranging from {Common.MIN_CHAR} to {Common.MAX_CHAR}.")));
        }

        [Test]
        public void Test_NonNumericShortInput()
        {
            Assert.That(InputVerifier.VerifyUserInput("abc"), Is.EqualTo((false, $"Input was shorter than {Common.MAX_NUM_CHARS} characters. Input must be {Common.MAX_NUM_CHARS} characters in length. Input must only contain digits ranging from {Common.MIN_CHAR} to {Common.MAX_CHAR}.")));
        }

        [Test]
        public void Test_OutOfRangeInput()
        {
            Assert.That(InputVerifier.VerifyUserInput("0789"), Is.EqualTo((false, $"Input must only contain digits ranging from {Common.MIN_CHAR} to {Common.MAX_CHAR}.")));
        }

        [Test]
        public void Test_OneOutOfRangeInput()
        {
            Assert.That(InputVerifier.VerifyUserInput("1239"), Is.EqualTo((false, $"Input must only contain digits ranging from {Common.MIN_CHAR} to {Common.MAX_CHAR}.")));
        }

        [Test]
        public void Test_ValidInput()
        {
            Assert.That(InputVerifier.VerifyUserInput("1234"), Is.EqualTo((true, string.Empty)));
        }
    }
}