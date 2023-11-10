using PizzaUser.Exceptions;
using PizzaUser.Models;

namespace PizzaUser.Services
{
    public static class Authorization
    {
        public static void SignUp()
        {
            try
            {
                Users users = new Users();

                Console.Write("Enter Name: ");
                users.Name = Console.ReadLine();
                Console.Write("Enter Surname: ");
                users.Surname = Console.ReadLine();
                Console.Write("Enter Username: ");
                users.Username = Console.ReadLine();
                Console.Write("Enter Password: ");
                users.Password = Console.ReadLine();

                UserServices.AddUser(users);
            }
            catch (UserNameInvalid ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (UserSurnameInvalid ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (UserUsernameInvalid ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (PasswordInvalid ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void Login()
        {

        }
    }
}
