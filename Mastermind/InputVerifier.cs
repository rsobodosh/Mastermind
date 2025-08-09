namespace Mastermind
{
    public class InputVerifier
    {
        public static (bool valid, string message) VerifyUserInput(string? inputString)
        {
            var valid = true;
            var messages = new List<string>();

            if (string.IsNullOrWhiteSpace(inputString))
            {
                return (false, "Input was empty.");
            }

            if (inputString.Length > Common.MAX_NUM_CHARS)
            {
                valid = false;
                messages.Add($"Input was longer than {Common.MAX_NUM_CHARS} characters. Input must be {Common.MAX_NUM_CHARS} characters in length.");
            }

            if (inputString.Length < Common.MAX_NUM_CHARS)
            {
                valid = false;
                messages.Add($"Input was shorter than {Common.MAX_NUM_CHARS} characters. Input must be {Common.MAX_NUM_CHARS} characters in length.");
            }

            if (!int.TryParse(inputString, out _))
            {
                valid = false;
                messages.Add($"Input must only contain digits ranging from {Common.MIN_CHAR} to {Common.MAX_CHAR}.");
            }
            else
            {
                if (inputString.Any(c => c < Common.MIN_CHAR || c > Common.MAX_CHAR))
                {
                    valid = false;
                    messages.Add($"Input must only contain digits ranging from {Common.MIN_CHAR} to {Common.MAX_CHAR}.");
                }
            }

            return (valid, string.Join(" ", messages));
        }
    }
}
