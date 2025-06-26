namespace universidad.Exceptions
{
    public class EstudianteException : Exception
    {
        public EstudianteException()
        {
        }
        public EstudianteException(string message)
            : base(message)
        {
        }
        public EstudianteException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
