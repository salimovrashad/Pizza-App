namespace PizzaUser.Exception
{
    internal class ProductNullException : System.Exception
    {
        public ProductNullException()
        {
        }

        public ProductNullException(string? message) : base(message)
        {
        }
    }
}
