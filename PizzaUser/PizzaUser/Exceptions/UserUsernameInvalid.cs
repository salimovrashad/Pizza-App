namespace PizzaUser.Exceptions
{
    internal class UserUsernameInvalid : System.Exception
    {
        public UserUsernameInvalid()
        {
        }

        public UserUsernameInvalid(string? message) : base(message)
        {
        }
    }
}
