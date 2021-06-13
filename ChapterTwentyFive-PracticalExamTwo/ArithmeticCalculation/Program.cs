using System;
using System.Collections.Generic;

namespace ArithmeticCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string expression = ReadExpression();

                int[] numbers = ExtractNumbers(expression);
                char[] operators = ExtractOperators(expression);

                long result = CalculateExpression(numbers, operators);
                Console.WriteLine($"{expression} = {result}");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Invalid expression!");
            }
        }

        static string ReadExpression()
        {
            Console.Write("Enter expression: ");
            string expression = Console.ReadLine();
            return expression;
        }

        static long CalculateExpression(int[] numbers, char[] operators)
        {
            long result = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                char operation = operators[i - 1];
                int nextNumber = numbers[i];

                if (operation == '+')
                {
                    result += nextNumber;
                }
                else if (operation == '-')
                {
                    result -= nextNumber;
                }
            }

            return result;
        }

        static char[] ExtractOperators(string expression)
        {
            List<char> operators = new List<char>();

            foreach (var c in expression)
            {
                if (c == '+' || c == '-')
                {
                    operators.Add(c);
                }
            }

            return operators.ToArray();
        }

        static int[] ExtractNumbers(string expression)
        {
            string[] splitResult = expression.Split('-', '+');

            var numbers = new List<int>(splitResult.Length);

            foreach (var number in splitResult)
            {
                numbers.Add(int.Parse(number));
            }

            return numbers.ToArray();
        }
    }
}
