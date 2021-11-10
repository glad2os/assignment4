using System;
using System.Collections.Generic;
using lab4.Exceptions;

namespace lab4
{
    internal static class Program
    {
        private static bool _working = true;

        private static readonly Dictionary<string, Action> Questions = new()
        {
            {"0", () => { _working = false; }},
            {"1", Tasks.Question1},
            {"2", Tasks.Question2},
            {"3", Tasks.Question3},
            {"4", Tasks.Question4},
            {"5", Tasks.Question5},
            {"6", Tasks.Question6},
            {"7", Tasks.Question7}
        };


        private static void Main(string[] args)
        {
            while (_working)
                try
                {
                    //Console.Clear();
                    Console.Write("Enter the number (1-7) for the question to run or 0 to exit: ");
                    var question = Console.ReadLine() ?? string.Empty;

                    if (!Questions.TryGetValue(question, out var action))
                        throw MyCustomException.QuestionNotFound;

                    Console.WriteLine($"You entered: {question}");
                    Console.WriteLine("------------");
                    action.Invoke();
                }
                catch (MyCustomException e)
                {
                    Console.WriteLine(e.Message);
                }
        }
    }
}