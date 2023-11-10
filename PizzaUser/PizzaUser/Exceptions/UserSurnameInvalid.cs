namespace PizzaUser.Exceptions
{
    internal class UserSurnameInvalid : System.Exception
    {
        public UserSurnameInvalid()
        {
        }

        public UserSurnameInvalid(string? message) : base(message)
        {
        }
    }
}
