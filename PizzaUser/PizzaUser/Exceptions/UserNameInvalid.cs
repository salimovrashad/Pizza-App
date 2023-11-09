namespace PizzaUser.Exceptions
{
    internal class UserNameInvalid : System.Exception
    {
        public UserNameInvalid()
        {
        }

        public UserNameInvalid(string? message) : base(message)
        {
        }
    }
}