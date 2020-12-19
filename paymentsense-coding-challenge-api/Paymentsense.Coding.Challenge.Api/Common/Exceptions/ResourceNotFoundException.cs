using System;

namespace Paymentsense.Coding.Challenge.Api.Common.Exceptions
{
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException(string code, string message) :
            base(message)
        {
            Code = code;
        }

        public ResourceNotFoundException(string code, string message, Exception inner) :
            base(message, inner)
        {
            Code = code;
        }

        public string Code { get; }

        public object ToSimpleObject()
        {
            return new { code = Code, message = Message };
        }
    }
}
