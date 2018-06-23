using System;

namespace SpringHello.utillty
{
    public class Utillty
    {
        public static int GetInt32Number()
        {
            int number = 0;
            while (true)
            {
                try
                {
                    number = Int32.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Please enter a number.");
                }
            }

            return number;
        }

        public static decimal GetDecimalNumber()
        {
            decimal number;
            while (true)
            {
                try
                {
                    number = decimal.Parse(Console.ReadLine());
                    if (number < 0)
                    {
                        throw new FormatException();
                    }

                    break;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Please enter a number or positive numbers");
                }
            }

            return number;
        }
    }
}