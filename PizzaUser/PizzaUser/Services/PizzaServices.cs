using PizzaUser.Database;
using PizzaUser.Models;

namespace PizzaUser.PizzaServices
{
    public static class PizzaServices
    {
        public static void AddPizza(Products pizza)
        {
            PizzaDatabase.products.Add(pizza);
        }
        public static void GetAllPizza() 
        {
            PizzaDatabase.products.ForEach(delegate (Products pizza)
            {
                Console.WriteLine(pizza);
            });
        }
        public static Products UpProductById(int Id)
        {
            var delegat = PizzaDatabase.products.FindAll(p => p.Id == Id);
            foreach (var item in delegat)
            {
                return item;
            }
            return null;
        }
    }
}
