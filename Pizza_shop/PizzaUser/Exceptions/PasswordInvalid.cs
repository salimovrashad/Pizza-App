namespace PizzaUser.Exceptions
{
    internal class PasswordInvalid : System.Exception
    {
        public PasswordInvalid()
        {
        }

        public PasswordInvalid(string? message) : base(message)
        {
        }
    }
}