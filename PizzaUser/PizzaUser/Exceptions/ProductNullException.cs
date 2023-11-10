namespace PizzaUser.Exception
{
    public class ProductNullException : System.Exception
    {
        public ProductNullException()
        {
        }

        public ProductNullException(string? message) : base(message)
        {
        }
    }
}
