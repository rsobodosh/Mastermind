namespace Mastermind
{
    public class HintGenerator
    {
        public const int MAX_NUM_CHARS = 4;

        public static string GenerateHint(string secretAnswer, string input)
        {
            var hint = AddPlusSymbols(secretAnswer, input);
            hint = AddMinusSymbols(secretAnswer, input, hint);

            return string.Join("", hint.Values);
        }

        private static Dictionary<char, string> AddPlusSymbols(string secretAnswer, string input)
        {
            Dictionary<char, string> hint = new Dictionary<char, string>();

            for (int i = 0; i < MAX_NUM_CHARS; i++)
            {
                if (input[i] == secretAnswer[i] && !hint.ContainsKey(input[i]))
                {
                    hint.Add(input[i], "+");
                }
            }

            return hint;
        }

        private static Dictionary<char, string> AddMinusSymbols(string secretAnswer, string input, Dictionary<char, string> hint)
        {
            foreach (char c in input)
            {
                if (secretAnswer.Contains(c) && !hint.ContainsKey(c))
                {
                    hint.Add(c, "-");
                }
            }

            return hint;
        }
    }
}
