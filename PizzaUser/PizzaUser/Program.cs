using PizzaUser.Database;
using PizzaUser.Exceptions;
using PizzaUser.Models;
using PizzaUser.Services;
using System.Drawing;
using System.Text.RegularExpressions;
using Console = Colorful.Console;

namespace PizzaUser
{
    public class Program
    {
        static void Main(string[] args)
        {
            string logo = @"  __  __                                                 _         ____  _                  
 |  \/  | __ _ _ __ ___  _ __ ___   __ _       _ __ ___ (_) __ _  |  _ \(_)__________ _ ___ 
 | |\/| |/ _` | '_ ` _ \| '_ ` _ \ / _` |_____| '_ ` _ \| |/ _` | | |_) | |_  /_  / _` / __|
 | |  | | (_| | | | | | | | | | | | (_| |_____| | | | | | | (_| | |  __/| |/ / / / (_| \__ \
 |_|  |_|\__,_|_| |_| |_|_| |_| |_|\__,_|     |_| |_| |_|_|\__,_| |_|   |_/___/___\__,_|___/";
            Console.WriteLine(logo, Color.Red);
            string bar = "Welcome to Mamma-Mia Pizzas...";
            for (int i = 0; i < bar.Length; i++)
            {
                Console.SetCursorPosition(i, 5);
                Console.WriteLine(bar[i], Color.Red);
                Thread.Sleep(10);
            }

            Products mamma_miaSpecial = new Products()
            {
                PizzaName = "Mamma-mia Special",
                Price = 20,
            };
            Products americanHot = new Products()
            {
                PizzaName = "American Hot",
                Price = 17,
            };
            Products chickenBbq = new Products()
            {
                PizzaName = "Chicken BBQ",
                Price = 16,
            };
            PizzaServices.PizzaServices.AddPizza(mamma_miaSpecial);
            PizzaServices.PizzaServices.AddPizza(americanHot);
            PizzaServices.PizzaServices.AddPizza(chickenBbq);

            while (true)
            {
            Login:
                MenuManager.MenuManager.ShowLoginMenu();
                int choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        Authorization.SignUp();
                        break;
                    case 2:
                        Console.Write("Enter Username: ");
                        string username = Console.ReadLine();
                        Console.Write("Enter Password: ");
                        string password = Console.ReadLine();

                        if ((username == "admin" && password == "admin") || PizzaDatabase.users.Any(u => u.Username == username && u.Password == password && u.isAdmin == true))
                        {
                        AdminChoose:
                            MenuManager.MenuManager.ShowAdminMenu();
                            int chooseadmin = Convert.ToInt32(Console.ReadLine());
                            switch (chooseadmin)
                            {
                                case 1:
                                Pizzas:
                                    MenuManager.MenuManager.ShowPizzaManageMenu();
                                    int choose3 = Convert.ToInt32(Console.ReadLine());
                                    switch (choose3)
                                    {
                                        case 1:
                                            PizzaServices.PizzaServices.GetAllPizza();
                                            break;
                                        case 2:
                                            Products pizza = new Products();

                                            Console.Write("Pizza Name: ");
                                            pizza.PizzaName = Console.ReadLine();
                                            Console.Write("Pizza Price: ");
                                            pizza.Price = Convert.ToInt32(Console.ReadLine());

                                            PizzaServices.PizzaServices.AddPizza(pizza);
                                            break;
                                        case 3:
                                            Console.WriteLine("Enter the ID of the pizza you want to edit: ");
                                            int editinp = Convert.ToInt32(Console.ReadLine());

                                            Products updatedProduct = PizzaServices.PizzaServices.UpProductById(editinp);
                                            Console.Write("Name: ");
                                            updatedProduct.PizzaName = Console.ReadLine();
                                            Console.Write("Price: ");
                                            updatedProduct.Price = Convert.ToInt32(Console.ReadLine());

                                            Console.WriteLine("Update successfull!");
                                            break;
                                        case 4:
                                            goto AdminChoose;
                                    }
                                    goto Pizzas;
                                case 2:
                                Users:    
                                   MenuManager.MenuManager.ShowUserManageMenu();
                                    int choose4 = Convert.ToInt32(Console.ReadLine());
                                    switch (choose4)
                                    {
                                        case 1:
                                            UserServices.AllUsers();
                                            break;
                                        case 2:
                                            Authorization.SignUp();
                                            break;
                                        case 3:
                                            Console.Write("Enter the ID of the user you want to admin: ");
                                            int ID = Convert.ToInt32(Console.ReadLine());
                                            UserServices.MakeUserAdmin(ID);
                                            break;
                                        case 4:
                                            Console.Write("Enter the ID of the user you want to remove: ");
                                            int removeUserID = Convert.ToInt32(Console.ReadLine());
                                            UserServices.RemoveUser(removeUserID);
                                            break;
                                        case 5:
                                            goto AdminChoose;
                                    }
                                    goto Users;
                                case 3:
                                    goto Login;
                                default:
                                    Console.WriteLine("Invalid option. Please try again.", Color.Red);
                                    break;
                            }
                            goto AdminChoose;
                        }

                        foreach (var user in PizzaDatabase.users)
                        {
                            
                            if (username == user.Username && password == user.Password)
                            {
                            Userchoose:
                                MenuManager.MenuManager.ShowPizzaMenu();
                                int choose1 = Convert.ToInt32(Console.ReadLine());

                                switch (choose1)
                                {
                                    case 1:
                                        PizzaServices.PizzaServices.GetAllPizza();
                                        break;
                                    case 2:
                                    OrdP:
                                        Console.Write("Enter the ID of the pizza you want to order: ");
                                        int productId = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("Count: ");
                                        int count = Convert.ToInt32(Console.ReadLine());

                                        bool productExistsInBasket = false;

                                        for (int i = 0; i < PizzaDatabase.basket.Count; i++)
                                        {
                                            if (PizzaDatabase.basket[i].Id == productId)
                                            {
                                                productExistsInBasket = true;
                                                break;
                                            }
                                        }

                                        if (!productExistsInBasket)
                                        {
                                            PizzaServices.PizzaServices.AddBasket(productId, count);
                                        }
                                        else
                                        {
                                            Console.WriteLine("This product is already in basket.");
                                        }
                                        Basket:
                                        Console.WriteLine("Basket List: ");
                                        PizzaServices.PizzaServices.AllBasket();
                                        Console.WriteLine("1. Complete order.\n2. Continue ordering. ");
                                        int chooseor = Convert.ToInt32(Console.ReadLine());
                                        switch (chooseor)
                                        {
                                            case 1:
                                                Console.WriteLine("Enter address: ");
                                                string address = Console.ReadLine();
                                                Console.WriteLine("Enter phone number: ");
                                                try
                                                {
                                                    string phoneNumber = Console.ReadLine();
                                                    if (!Regex.IsMatch(phoneNumber, @"^\+994(50)|(51)|(55)|(10)|(70)|(77)-[0-9]{3}-[0-9]{2}-[0-9]{2}")) throw new PhoneNumberInvalid("Wrong Phone Number. Ex:+99400-000-00-00"); 
                                                    Console.WriteLine($"Address: {address}, PhoneNum: {phoneNumber}");
                                                    Console.WriteLine("\nYour order has been received!");
                                                }
                                                catch (PhoneNumberInvalid ex)
                                                {
                                                    Console.WriteLine(ex.Message);
                                                    goto Basket;
                                                }
                                                PizzaDatabase.basket.Clear();
                                                break;
                                            case 2:
                                                goto OrdP;
                                        }
                                        break;
                                    case 3:
                                        goto Login;
                                    default:
                                        Console.WriteLine("Invalid option. Please try again.", Color.Red);
                                        break;
                                }
                                goto Userchoose;
                            }
                            else 
                            { 
                                Console.WriteLine("User not found!");
                            }
                        }
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.", Color.Red);
                        break;
                }
            }
            
        }
    }
}