namespace Mastermind
{
    public class Program
    {
        public static int MAX_NUM_ATTEMPTS = 10;

        public static string SecretAnswer { get; set; } = String.Empty;

        public static void InitializeSecretAnswer()
        {
            Random random = new Random();
            SecretAnswer = string.Join("", Enumerable.Range(0, 4).Select(_ => random.Next(1, 7).ToString()));
        }

        public static void Main(string[] args)
        {
            int attempts = 1;
            bool won = false;

            InitializeSecretAnswer();

            Console.WriteLine("Welcome to the Mastermind game!");

            while (attempts <= MAX_NUM_ATTEMPTS)
            {
                Console.WriteLine($"Attempt {attempts} of {MAX_NUM_ATTEMPTS} | Enter your guess (4 digits with each digit ranging from 1 to 6):");

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

                attempts++;
            }

            if (won)
            {
                Console.WriteLine("Congratulations! You've guessed the secret answer!");
            }
            else
            {
                Console.WriteLine(String.Format("Sorry, you were unable to guess the secret answer which was {0}.", SecretAnswer));
            }
        }
    }
}