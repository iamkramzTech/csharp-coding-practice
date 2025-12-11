namespace Day03Loops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countStart = 1;
            Console.Write("Enter a Number: ");
            var number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine($"FOR LOOP: Counting from {countStart} to {number}");
            for (countStart = 1; countStart <= number; countStart++)
            {
                Console.Write(countStart + " ");
            }
            int countStartWhile = 1;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"WHILE LOOP: Even numbers from {countStartWhile} to {number}");
            while (countStartWhile <= number)
            {
                if (countStartWhile % 2 == 0)
                {
                    Console.Write(countStartWhile + " ");
                }
               
                countStartWhile += 1;
            }

           
        }
    }
}
