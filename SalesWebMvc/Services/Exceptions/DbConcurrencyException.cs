namespace SalesWebMvc.Services.Exceptions
{
    public class DbConcurrencyException : AppException
    {
        public DbConcurrencyException(string message) : base(message)
        {
        }
    }
}
