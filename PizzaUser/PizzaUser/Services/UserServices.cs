using PizzaUser.Database;
using PizzaUser.Models;

namespace PizzaUser.Services
{
    public static class UserServices
    {
        public static void AddUser(Users user)
        {
            PizzaDatabase.users.Add(user);
        }
        public static void AllUsers() 
        {
            PizzaDatabase.users.ForEach(delegate (Users users)
            {
                Console.WriteLine(users);
            });
        }
    }
}
