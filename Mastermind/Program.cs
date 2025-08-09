using System.Text;

namespace Mastermind
{
    public class Program
    {
        public static string SecretAnswer { get; set; } = String.Empty;

        public static void InitializeSecretAnswer()
        {
            Random random = new Random();
            StringBuilder sb = new StringBuilder();

            for (int i = 1; i <= Common.MAX_NUM_CHARS; i++)
            {
                sb.Append(random.Next(1, 7));
            }

            SecretAnswer = sb.ToString();
        }

        public static void Main(string[] args)
        {
            int attempt = 1;
            bool won = false;

            InitializeSecretAnswer();

            Console.WriteLine("Welcome to the Mastermind game!");

            while (attempt <= Common.MAX_NUM_ATTEMPTS)
            {
                Console.WriteLine($"Attempt {attempt} of {Common.MAX_NUM_ATTEMPTS} | Enter your guess ({Common.MAX_NUM_CHARS} digits with each digit ranging from {Common.MIN_CHAR} to {Common.MAX_CHAR}):");

                string? input = Console.ReadLine();

                (bool valid, string message) = InputVerifier.VerifyUserInput(input);

                if (valid)
                {
                    if (input == SecretAnswer)
                    {
                        won = true;
                        break;
                    }

                    string hint = HintGenerator.GenerateHint(input!, SecretAnswer);
                    
                    Console.WriteLine($"Hint: {hint}");
                }
                else
                {
                    Console.WriteLine(message);
                }

                attempt++;
            }

            if (won)
            {
                Console.WriteLine("Congratulations! You've guessed the secret answer!");
            }
            else
            {
                Console.WriteLine($"Sorry, you were unable to guess the secret answer which was {SecretAnswer}.");
            }
        }
    }
}