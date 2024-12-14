namespace ProjetoSistema.Services.Exceptions
{
    [Serializable]
    internal class DbConcorrencyException : Exception
    {
        public DbConcorrencyException()
        {
        }

        public DbConcorrencyException(string? message) : base(message)
        {
        }

        public DbConcorrencyException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}