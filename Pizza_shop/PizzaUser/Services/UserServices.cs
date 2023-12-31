﻿using PizzaUser.Database;
using PizzaUser.Models;

namespace PizzaUser.Services
{
    public static class UserServices
    {
        public static void AddUser(Users users)
        {
            PizzaDatabase.users.Add(users);
        }

        public static void AllUsers() 
        {
            PizzaDatabase.users.ForEach(delegate (Users users)
            {
                Console.WriteLine(users);
            });
        }

        public static Users GetUserbyID(int id)
        {
            return PizzaDatabase.users.SingleOrDefault(e => e.Id == id);

        }

        public static void MakeUserAdmin(int id)
        {
            Users user = GetUserbyID(id);
            if (user != null)
            {
                user.isAdmin = true;
                Console.WriteLine($"User {user.Name} is now an admin.");
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        public static void RemoveUser(int id)
        {
            Users user = GetUserbyID(id);
            if (user != null)
            {
                PizzaDatabase.users.Remove(user);
                Console.WriteLine($"User {user.Name} removed successfully.");

                // Update IDs for remaining users
                foreach (Users remainingUser in PizzaDatabase.users)
                {
                    if (remainingUser.Id > id)
                    {
                        remainingUser.Id--;
                    }
                }
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }



    }
}

