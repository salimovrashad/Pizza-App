using PizzaUser.Models;
using System;

namespace PizzaUser.Database
{
    static class PizzaDatabase
    {
        public static List<Products> products = new List<Products>();
        public static List<Users> users = new List<Users>();
        public static List<Basket> basket = new List<Basket>();
    }
}
