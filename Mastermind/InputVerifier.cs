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

            if (inputString.Length > 4)
            {
                valid = false;
                messages.Add("Input was longer than 4 characters. Input must be 4 characters in length.");
            }

            if (inputString.Length < 4)
            {
                valid = false;
                messages.Add("Input was shorter than 4 characters. Input must be 4 characters in length.");
            }

            if (!int.TryParse(inputString, out _))
            {
                valid = false;
                messages.Add("Input must only contain digits ranging from 1 to 6.");
            }
            else
            {
                if (inputString.Any(c => c < '1' || c > '6'))
                {
                    valid = false;
                    messages.Add("Input must only contain digits ranging from 1 to 6.");
                }
            }

            return (valid, string.Join(" ", messages));
        }
    }
}
