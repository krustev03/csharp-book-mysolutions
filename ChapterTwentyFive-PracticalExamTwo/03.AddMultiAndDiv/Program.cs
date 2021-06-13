using System;
using System.Collections.Generic;

namespace _03.AddMultiAndDiv
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string expression = ReadExpression();

                List<int> numbers = ExtractNumbers(expression);
                List<char> operators = ExtractOperators(expression);

                object[] firstResult = CalculateMultiplicationsAndDivisions(numbers, operators);
                numbers = (List<int>)firstResult[0];
                operators = (List<char>)firstResult[1];
                long endResult = CalculateAdditionAndSubtraction(numbers, operators);
                Console.WriteLine($"{expression} = {endResult}");
            }
            catch (Exception ex)
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

        static long CalculateAdditionAndSubtraction(List<int> numbers, List<char> operators)
        {
            long result = numbers[0];

            for (int i = 1; i < numbers.Count; i++)
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

        static object[] CalculateMultiplicationsAndDivisions(List<int> numbers, List<char> operators)
        {
            int i = 1;

            while(operators.Contains('*') || operators.Contains('/'))
            {
                char operation = operators[i - 1];
                int nextNumber = numbers[i];

                if (operation == '*')
                {
                    numbers[i - 1] = (numbers[i - 1] * nextNumber);
                    numbers.RemoveAt(i);
                    operators.RemoveAt(i - 1);
                    i--;
                }

                else if (operation == '/')
                {
                    if (nextNumber == 0)
                    {
                        throw new Exception();
                    }
                    numbers[i - 1] = (numbers[i - 1] / nextNumber);
                    numbers.RemoveAt(i);
                    operators.RemoveAt(i - 1);
                    i--;
                }

                i++;
            }

            var result = new object[] { numbers, operators };
            return result;
        }
            
        static List<char> ExtractOperators(string expression)
        {
            List<char> operators = new List<char>();

            foreach (var c in expression)
            {
                if (c == '+' || c == '-' || c == '*' || c == '/')
                {
                    operators.Add(c);
                }
            }

            return operators;
        }

        static List<int> ExtractNumbers(string expression)
        {
            string[] splitResult = expression.Split('-', '+', '*', '/');

            var numbers = new List<int>(splitResult.Length);

            foreach (var number in splitResult)
            {
                numbers.Add(int.Parse(number));
            }

            return numbers;
        }
    }
}
