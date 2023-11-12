namespace PizzaUser.Exceptions
{
    internal class UserNotFoundException : System.Exception
    {
        public UserNotFoundException()
        {
        }

        public UserNotFoundException(string? message) : base(message)
        {
        }
    }
}
