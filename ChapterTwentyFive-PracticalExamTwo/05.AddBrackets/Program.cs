using System;
using System.Collections.Generic;
using System.Text;

namespace _05.AddBrackets
{
    class Program
    {
        static bool hasBrackets = true;

        static void Main(string[] args)
        {
            try
            {
                string expression = ReadExpression();

                while (hasBrackets)
                {
                    expression = ExtractExpression(expression);
                }

                List<double> numbers = ExtractNumbers(expression);
                List<char> operators = ExtractOperators(expression);

                if (numbers.Count == operators.Count)
                {
                    numbers[0] = -numbers[0];
                    operators.RemoveAt(0);
                }

                object[] firstResult = CalculateMultiplicationsAndDivisions(numbers, operators);
                numbers = (List<double>)firstResult[0];
                operators = (List<char>)firstResult[1];
                double endResult = CalculateAdditionAndSubtraction(numbers, operators);

                Console.WriteLine($"Result = {endResult}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid expression!");
            }
        }

        static string ExtractExpression(string expression)
        {
            if (!expression.Contains(')') && !expression.Contains('('))
            {
                hasBrackets = false;
                return expression;
            }

            var start = expression.LastIndexOf('(');

            bool hasMinus = false;

            if (expression[start - 1] == '-')
            {
                hasMinus = true;
            } 

            var end = expression.IndexOf(')', start);
            var inBrackets = expression.Substring(start, end - start + 1);

            StringBuilder withoutBrackets = new StringBuilder();

            for (int i = 1; i < inBrackets.Length - 1; i++)
            {
                withoutBrackets.Append(inBrackets[i]);
            }

            string withoutBracketsStr = withoutBrackets.ToString();

            List<double> numbers = ExtractNumbers(withoutBracketsStr);
            List<char> operators = ExtractOperators(withoutBracketsStr);

            object[] firstResult = CalculateMultiplicationsAndDivisions(numbers, operators);
            numbers = (List<double>)firstResult[0];
            operators = (List<char>)firstResult[1];

            if (numbers.Count == operators.Count)
            {
                numbers[0] = -numbers[0];
                operators.RemoveAt(0);
            }

            double endResult = CalculateAdditionAndSubtraction(numbers, operators);

            string result = string.Empty;

            if (endResult < 0 && hasMinus)
            {
                result = expression.Replace("-" + inBrackets, "+" + Math.Abs(endResult).ToString());
            }
            else if (endResult < 0 && hasMinus == false)
            {
                result = expression.Replace("+" + inBrackets, endResult.ToString());
            }
            else
            {
                result = expression.Replace(inBrackets, endResult.ToString());
            }
            

            return result;
        }

        static string ReadExpression()
        {
            Console.Write("Enter expression: ");
            string expression = Console.ReadLine();
            return expression;
        }

        static double CalculateAdditionAndSubtraction(List<double> numbers, List<char> operators)
        {
            double result = numbers[0];

            for (int i = 1; i < numbers.Count; i++)
            {
                char operation = operators[i - 1];
                double nextNumber = numbers[i];

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

        static object[] CalculateMultiplicationsAndDivisions(List<double> numbers, List<char> operators)
        {
            int i = 1;

            while (operators.Contains('*') || operators.Contains('/'))
            {
                char operation = operators[i - 1];
                double nextNumber = numbers[i];

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

        static List<double> ExtractNumbers(string expression)
        {
            string[] splitResult = expression.Split(new char[] { '-', '+', '*', '/' }, StringSplitOptions.RemoveEmptyEntries);

            var numbers = new List<double>(splitResult.Length);

            foreach (var number in splitResult)
            {
                numbers.Add(double.Parse(number));
            }

            return numbers;
        }
    }
}
