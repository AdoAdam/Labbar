namespace Labb1
{
    internal class Labb1
    {
        static string input = "";
        static bool foundSecondNumber = false;
        static int secondNumberIndex = 0;
        static long sum = 0;
        static void Main(string[] args)
        {
            Console.Write("Mata in text: ");
            input = Console.ReadLine();

            for (int rowIndex = 0; rowIndex < input.Length; rowIndex++)
            {
                foundSecondNumber = FoundSecondNumber(rowIndex);
                PrintResults(rowIndex);
                if (foundSecondNumber)
                    Console.WriteLine();
                Console.ResetColor();
            }
            Console.WriteLine("Total: " + sum);
        }

        static void PrintResults(int rowIndex)
        {
            string numberSubstring = "";
            int startIndex = 0;

            for (int charIndex = 0; charIndex < input.Length; charIndex++)
            {           
                if (foundSecondNumber)
                {
                    if (charIndex == rowIndex)
                    {
                        startIndex = charIndex;
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (charIndex == secondNumberIndex + 1)
                    {
                        Console.ResetColor();
                    }
                    Console.Write(input[charIndex]);

                    numberSubstring = input.Substring(startIndex, secondNumberIndex - startIndex + 1);
                }
                else
                {
                    break;
                }
            }
            if (!String.IsNullOrEmpty(numberSubstring))
                sum += long.Parse(numberSubstring);
        }

        static bool FoundSecondNumber(int rowIndex)
        {
            for (int i = rowIndex + 1; i < input.Length; i++)
            {
                if (char.IsLetter(input[i])) 
                    return false;

                if (input[i] == input[rowIndex])
                {
                    secondNumberIndex = i;
                    return true;
                }
            }
            return false;
        }
    }
}
