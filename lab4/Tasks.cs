using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using lab4.Exceptions;

namespace lab4
{
    public static class Tasks
    {
        public static void Question1()
        {
            var cubes = new List<Tuple<int, double, double>>();

            for (var i = 11 - 1; i >= 0; i--)
                cubes.Add(new Tuple<int, double, double>(i, Math.Pow(i, 2), Math.Pow(i, 3)));

            Console.WriteLine(cubes.ToStringTable(
                new[] {"Number", "Squares", "Cubes"},
                a => a.Item1, a => a.Item2, a => a.Item3));
        }

        public static void Question2()
        {
            var lT = GetDouble("write the lower threshold: ");
            var uT = GetDouble("write the upper threshold: ");
            if (uT < lT) throw MyCustomException.ThresholdError;
            //(0°C × 9/5) + 32 
            var temperature = new List<Tuple<double, double>>();

            for (var i = lT; i <= uT; i++)
                temperature.Add(new Tuple<double, double>(i, (i * 9 / 5) + 32));

            Console.WriteLine(temperature.ToStringTable(
                new[] {"Fahrenheits", "Celsius"},
                a => a.Item1, a => $"{a.Item2:0.0#}"));
        }

        public static void Question3()
        {
            const int percentage = 8;
            var deposited = 1000;

            for (var i = 0; i <= 10; i++)
            {
                deposited += deposited * percentage / 100;
                Console.WriteLine($"{i} {deposited:c}");
            }
        }

        public static void Question4()
        {
            var grade = 0;

            while (true)
            {
                if (grade >= 999) break;

                var input = GetInteger("Please input grade: ");

                if (input is not (> 0 and < 100))
                    throw MyCustomException.GradeLessThanRequests;

                grade += input;
            }
        }

        public static void Question5()
        {
            var firstChar = GetChar("please input first char: ");
            var secondChar = GetChar("please input second char: ");

            if (firstChar > secondChar)
                throw MyCustomException.ThresholdError;

            var letters = new List<Tuple<char, int, string, string>>();

            for (int i = firstChar; i <= secondChar; i++)
                letters.Add(FormattingChar((char) i));

            Console.WriteLine(letters.ToStringTable(
                new[] {"Letter", "Decimal", "Octal", "Hex"},
                a => a.Item1,
                a => a.Item2,
                a => a.Item3,
                a => a.Item4));
        }

        public static void Question6()
        {
            var equations = new List<Tuple<double, double, double, int, double>>();

            var y = new Func<double, double>(x => 2 * x * x - x - 6);

            for (double i = 1; i <= 5; i += 0.5)
                equations.Add(new Tuple<double, double, double, int, double>
                    (i, 2 * i * i, i * -1, -6, y(i)));

            Console.WriteLine(equations.ToStringTable(
                new[] {"x", "2x²", "-x", "-6", "y"},
                a => $"{a.Item1:0.0#}",
                a => $"{a.Item2:0.0#}",
                a => $"{a.Item3:0.0#}",
                a => $"{a.Item4:0.0#}",
                a => $"{a.Item5:0.0#}"));
        }

        public static void Question7()
        {
            var number = GetInteger("Please input the number: ");
            do
            {
                Console.Write(number%10);
                number /= 10;
            } while (number >= 1);
            Console.Write("\n");
        }

        private static double GetDouble(string text)
        {
            Console.Write(text);
            if (!double.TryParse(Console.ReadLine(), out var variable))
                throw MyCustomException.IsNotADouble;
            return variable;
        }

        private static int GetInteger(string text)
        {
            Console.Write(text);
            if (!int.TryParse(Console.ReadLine(), out var variable))
                throw MyCustomException.IsNotAnInteger;
            return variable;
        }

        private static char GetChar(string text)
        {
            Console.Write(text);
            char userInput = Console.ReadKey().KeyChar;
            if (!char.TryParse(userInput.ToString(), out var variable))
                throw MyCustomException.IsNotAnInteger;
            Console.Write("\n");
            return variable;
        }

        private static Tuple<char, int, string, string> FormattingChar(char userInput)
        {
            return new Tuple<char, int, string, string>(userInput, (int) Convert.ToUInt32(userInput),
                DecimalToOctal((int) Convert.ToUInt32(userInput)),
                $"{(int) Convert.ToUInt32(userInput):x}");
        }

        private static string DecimalToOctal(int dec)
        {
            if (dec < 1) return "0";

            var octStr = string.Empty;

            while (dec > 0)
            {
                octStr = octStr.Insert(0, (dec % 8).ToString());
                dec /= 8;
            }

            return octStr;
        }
    }
}