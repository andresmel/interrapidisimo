namespace universidad.Exceptions
{
    public class MateriaProfesorException : Exception
    {
        public MateriaProfesorException() { }

        public MateriaProfesorException(string message)
            : base(message) { }

        public MateriaProfesorException(string message, Exception inner)
            : base(message, inner) { }
    }
}
