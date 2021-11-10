using System;

namespace lab4.Exceptions
{
    public class MyCustomException : Exception
    {
        public static readonly MyCustomException IsNotAnInteger = new("is not an integer");
        public static readonly MyCustomException QuestionNotFound = new("question does not found");
        public static readonly MyCustomException IsNotADouble = new("The number should be double");
        public static readonly MyCustomException ThresholdError = new("lower threshold can not be more than the upper threshold");
        public static readonly MyCustomException GradeLessThanRequests = new("Input grade can not be less than 0 and more than 100");

        private MyCustomException(string message) : base(message)
        {
        }
    }
}