using PizzaUser.Database;
using PizzaUser.Exception;
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
            throw new ProductNullException("Product id not found.!!!");
        }

        public static void RemovePizza(int pizzaId)
        {
            Products pizzaToRemove = PizzaDatabase.products.FirstOrDefault(pizza => pizza.Id == pizzaId);

            if (pizzaToRemove != null)
            {
                PizzaDatabase.products.Remove(pizzaToRemove);
                Console.WriteLine($"\n{pizzaToRemove.PizzaName} removed successfully.");
            }
            else
            {
                Console.WriteLine("\nPizza not found.!!!");
            }
        }

        public static void AddBasket(int id)
        {
            Products selectedPizza = PizzaDatabase.products.FirstOrDefault(pizza => pizza.Id == id);

            if (selectedPizza != null)
            {
                Console.Write("Count: ");
                int count = Convert.ToInt32(Console.ReadLine());

                Basket newBasketItem = new Basket
                {
                    Id = selectedPizza.Id,
                    PizzaName = selectedPizza.PizzaName,
                    TotalPrice = selectedPizza.Price * count,
                };

                PizzaDatabase.basket.Add(newBasketItem);
            }
            else
            {
                Console.WriteLine("Pizza not found.");
            }
        }

        public static void AllBasket()
        {
            PizzaDatabase.basket.ForEach(delegate (Basket basket) 
            {
                Console.WriteLine(basket);
            });
        }

        public static void RemoveFromBasket(int productId)
        {
            Basket itemToRemove = PizzaDatabase.basket.FirstOrDefault(item => item.Id == productId);

            if (itemToRemove != null)
            {
                PizzaDatabase.basket.Remove(itemToRemove);
                Console.WriteLine($"{itemToRemove.PizzaName} removed from the basket.");
            }
            else
            {
                Console.WriteLine("Item not found in the basket.");
            }
        }
    }
}
