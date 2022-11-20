using System;

namespace MyMVVM.Exceptions
{
    public class InvalidTypeException : Exception
    {
        public Type? Type{get; init;}

        private string _message;

        public override string Message => _message;

        public InvalidTypeException(Type type, string message = "")
        {
            _message = message;
            
            if(String.IsNullOrEmpty(message)){
                _message = $"The type {type.Name} is invalid for this operation";
            }       
        }

    }
}