namespace Mastermind
{
    public class HintGenerator
    {
        public static string GeneratorHint(string secretAnswer, string input)
        {
            var hint = AddPlusSymbols(secretAnswer, input);
            hint = AddMinusSymbols(secretAnswer, input, hint);

            return string.Join("", hint.Values);
        }

        public static Dictionary<char, string> AddPlusSymbols(string secretAnswer, string input)
        {
            Dictionary<char, string> hint = new Dictionary<char, string>();

            for (int i = 0; i < 4; i++)
            {
                if (input[i] == secretAnswer[i] && !hint.ContainsKey(input[i]))
                {
                    hint.Add(input[i], "+");
                }
            }

            return hint;
        }

        public static Dictionary<char, string> AddMinusSymbols(string secretAnswer, string input, Dictionary<char, string> hint)
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
