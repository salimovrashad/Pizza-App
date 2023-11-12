namespace PizzaUser.Exceptions;
public class PhoneNumberInvalid : System.Exception
{
    public PhoneNumberInvalid()
    {
    }

    public PhoneNumberInvalid(string? message) : base(message)
    {
    }
}
