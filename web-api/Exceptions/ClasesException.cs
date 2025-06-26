namespace universidad.Exceptions
{
    public class ClasesException : Exception
    {

        public ClasesException() { }

        public ClasesException(string message)
            : base(message) { }

        public ClasesException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
