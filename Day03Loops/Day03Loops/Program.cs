using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Day03Loops
{
    internal class Program
    {
        private const int DefaultStart = 1; // SET Default iteration Start  to 1

        static void Main(string[] args)
        {
            #region -- old spaghetti code
            //int countStart = 1;
            //Console.Write("Enter a Number: ");
            //var number = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine();
            //Console.WriteLine($"FOR LOOP: Counting from {countStart} to {number}");
            //for (countStart = 1; countStart <= number; countStart++)
            //{
            //    Console.Write(countStart + " ");
            //}

            //int countStartWhile = 1;
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine($"WHILE LOOP: Even numbers from {countStartWhile} to {number}");
            //while (countStartWhile <= number)
            //{
            //    if (countStartWhile % 2 == 0)
            //    {
            //        Console.Write(countStartWhile + " ");
            //    }

            //    countStartWhile += 1;
            //}

            //int countStartDoWhile = 1;
            //int sum = 0;
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine($"DO-WHILE LOOP: Total Sum from {countStartDoWhile} to {number}");
            //do
            //{
            //    sum += countStartDoWhile;
            //    countStartDoWhile++;
            //} while (countStartDoWhile <= number);
            //Console.Write($"Sum = {sum}");
            #endregion
            #region -- new code clean and modular --
            // Call the Driver's Method, is this Driver Method if not what is the correct professional term?
            Run();
            PromptUserForAnotherNumber();        
           #endregion
        }

        /// <summary>
        /// Get Number input by user
        /// </summary>
        /// <param name="prompt">prompt message to Display in user</param>
        /// <returns>integer number input by user</returns>
        static int PromptUserForNumber(string prompt)
        {
            Console.Write(prompt);

            while (true)
            {
                try
                {
                    bool success = int.TryParse(Console.ReadLine(), out var number);

                    if (success)
                    {
                        if (number <= 0)
                        {
                            throw new ArgumentException($"{nameof(number)} must not be less than {DefaultStart}");
                        }

                        return number;
                    }
              
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception)
                {
                    Console.WriteLine("Unexpected Error!");
                }
                Console.Write("\nPlease enter a valid number (integer): ");
            }

        }

        /// <summary>
        /// Count Number from Default start Number up to Number Input by user
        /// </summary>
        /// <param name="number">integer number input by user</param>
        static void IncrementCountFromOneToInputNumber(int number)
        {
            Console.WriteLine();
            Console.WriteLine($"FOR LOOP: Counting from {DefaultStart} to {number}");
            for (int i = DefaultStart; i <= number; i++)
            {
                Console.Write(i + " ");
            }
        }

        /// <summary>
        /// Display Even Number range from Default Start Number to Number Input by user
        /// </summary>
        /// <param name="number">integer number input by user</param>
        static void DisplayEvenNumber(int number)
        {
            int i = DefaultStart;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"WHILE LOOP: Even numbers from {DefaultStart} to {number}");
            while (i <= number)
            {
                if (i % 2 == 0)
                {
                    Console.Write(i + " ");
                }

                i += 1;
            }
        }

        /// <summary>
        /// Perform Arithmetic Operation Additon
        /// </summary>
        /// <param name="number">integer number input by user</param>
        /// <returns></returns>
        static int PerformAddition(int number)
        {
            var i = DefaultStart;
            var sum = 0; // store the value of the result of numbers being add during loop 
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"DO-WHILE LOOP: Total Sum from {DefaultStart} to {number}");
            do
            {
                sum += i;
                i++;
            }
            while (i <= number);

            return sum;
        }

        /// <summary>
        /// Display Sum
        /// </summary>
        /// <param name="sum">result of number being added</param>
        static void DisplaySum(int sum)
        {
            Console.Write($"Sum = {sum}");
        }

        /// <summary>
        /// What is the correct professional standard name term of put all methods here then call this  Run() method in Main?
        /// is it Driver code Method? or the Main is the Driver Method
        /// </summary>
        static void Run()
        {
            var number = PromptUserForNumber("Enter a number: ");

            IncrementCountFromOneToInputNumber(number: number);

            DisplayEvenNumber(number: number);

            var totalSum = PerformAddition(number: number);

            DisplaySum(totalSum);
        }

        /// <summary>
        /// Asks the user a Yes/No question with an optional default answer.
        /// Examples:
        /// AskYesNo("Continue?", true)  → shows: Continue? [Y/n]:
        /// AskYesNo("Continue?", false) → shows: Continue? [y/N]:
        /// <param name="question">string question</param>
        /// <param name="defaultYes">bool default</param>
        /// <returns>bool</returns>
        static bool AskYesNo(string question, bool defaultYes)
        {
            #region -- Yes No helper code
            while (true)
            {

                var prompt = defaultYes ? " [Y/n]: " : " [y/N] ";
                Console.Write(question + prompt);
                string? input = Console.ReadLine()?.Trim().ToLower();
                if (string.IsNullOrWhiteSpace(input))
                {
                    return defaultYes;
                }
                var choice = input[0];
                if (choice == 'y')
                {
                    return true;
                }
                if (choice == 'n')
                {
                    return false;
                }
                Console.WriteLine("Invalid choice. Please enter y or n.");
            }
            #endregion
        }

        /// <summary>
        /// Prompt user if want to try another number
        /// </summary>
        static void PromptUserForAnotherNumber()
        {
            #region -- working code

            while (true)
            {
                
               bool isRepeat = AskYesNo("\nDo you want to try another number?",defaultYes: true);
                            
               if(!isRepeat)
                {
                    break;
                }

                Run();
            }

            Console.WriteLine();
            Console.WriteLine("Program will end. Message: Goodbye...");

            #endregion

        }

    }
}
