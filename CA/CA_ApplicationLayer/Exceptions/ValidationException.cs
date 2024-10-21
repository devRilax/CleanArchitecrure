namespace CA_ApplicationLayer.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException() : base("Validation Error") { }

        public ValidationException(string errorMessage) : base(errorMessage) { }
    }
}
