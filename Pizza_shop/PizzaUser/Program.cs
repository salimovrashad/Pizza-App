using PizzaUser.Database;
using PizzaUser.Exception;
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
            //SPECIAL PIZZAS//
            Products mamma_miaSpecial = new Products()
            {
                PizzaName = "Mamma-mia Special",
                Price = 200,
            };
            Products americanHot = new Products()
            {
                PizzaName = "American Hot",
                Price = 170,
            };
            Products chickenBbq = new Products()
            {
                PizzaName = "Chicken BBQ",
                Price = 160,
            };
            PizzaServices.PizzaServices.AddPizza(mamma_miaSpecial);
            PizzaServices.PizzaServices.AddPizza(americanHot);
            PizzaServices.PizzaServices.AddPizza(chickenBbq);

            while (true)
            {
            Login:
                MenuManager.MenuManager.ShowLoginMenu();
                try
                {
                    if (!int.TryParse(Console.ReadLine(), out int choose))
                    {
                        throw new System.FormatException("Please enter integer value and try again.");
                    }
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
                                #region Admin Menu
                                Console.WriteLine($"\nHello {username}.!");
                                AdminChoose:
                                MenuManager.MenuManager.ShowAdminMenu();
                                try
                                {
                                    if (!int.TryParse(Console.ReadLine(), out int chooseadmin))
                                    {
                                        throw new System.FormatException("Please enter integer value and try again.");
                                    }
                                    switch (chooseadmin)
                                    {
                                        case 1:
                                        Pizzas:
                                            MenuManager.MenuManager.ShowPizzaManageMenu();
                                            try
                                            {
                                                if (!int.TryParse(Console.ReadLine(), out int choose3))
                                                {
                                                    throw new System.FormatException("Please enter integer value and try again.");
                                                }
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

                                                        if (pizza.Price < 0)
                                                        {
                                                            Console.WriteLine("The value cannot be negative. Please try again.", Color.Red);
                                                        }
                                                        else
                                                        {
                                                            PizzaServices.PizzaServices.AddPizza(pizza);
                                                        }
                                                        break;
                                                    case 3:
                                                        Console.WriteLine("Enter the ID of the pizza you want to edit: ");
                                                        try
                                                        {
                                                            if (!int.TryParse(Console.ReadLine(), out int editinp))
                                                            {
                                                                throw new System.FormatException("Please enter integer value and try again.");
                                                            }
                                                            try 
                                                            { 
                                                                Products updatedProduct = PizzaServices.PizzaServices.UpProductById(editinp);
                                                                Console.Write("Name: ");
                                                                updatedProduct.PizzaName = Console.ReadLine();
                                                                Console.Write("Price: ");
                                                                updatedProduct.Price = Convert.ToInt32(Console.ReadLine());
                                                                Console.WriteLine("\nUpdate successfull!");
                                                            }
                                                            catch (ProductNullException ex)
                                                            {
                                                                Console.WriteLine(ex.Message);
                                                            }
                                                        }
                                                        catch (FormatException ex)
                                                        {
                                                            Console.WriteLine(ex.Message);
                                                        }

                                                        break;
                                                    case 4:
                                                        Console.WriteLine("Enter the ID of the pizza you want to remove: ");
                                                        try
                                                        {
                                                            if (!int.TryParse(Console.ReadLine(), out int removeinp))
                                                            {
                                                                throw new System.FormatException("Please enter integer value and try again.");
                                                            }
                                                            PizzaServices.PizzaServices.RemovePizza(removeinp);
                                                        }
                                                        catch (FormatException ex)
                                                        {
                                                            Console.WriteLine(ex.Message);
                                                        }

                                                        break;
                                                    case 5:
                                                        goto AdminChoose;
                                                    default:
                                                        Console.WriteLine("Invalid option. Please try again.", Color.Red);
                                                        break;
                                                }
                            
                                            }
                                            catch (FormatException ex)
                                            {
                                                Console.WriteLine(ex.Message);
                                            }

                                            goto Pizzas;
                                        case 2:
                                        Users:
                                            MenuManager.MenuManager.ShowUserManageMenu();
                                            try
                                            {
                                                if (!int.TryParse(Console.ReadLine(), out int choose4))
                                                {
                                                    throw new System.FormatException("Please enter integer value and try again.");
                                                }
                                                switch (choose4)
                                                {
                                                case 1:
                                                    UserServices.AllUsers();
                                                    break;
                                                case 2:
                                                    Console.Write("Enter the ID of the user you want to admin: ");
                                                    try
                                                    {
                                                        if (!int.TryParse(Console.ReadLine(), out int ID))
                                                        {
                                                            throw new System.FormatException("Please enter integer value and try again.");
                                                        }
                                                        UserServices.MakeUserAdmin(ID);
                                                    }
                                                    catch (FormatException ex)
                                                    {
                                                        Console.WriteLine(ex.Message);
                                                    }
                                                    break;
                                                case 3:
                                                    Console.Write("Enter the ID of the user you want to remove: ");
                                                    try
                                                    {
                                                        if (!int.TryParse(Console.ReadLine(), out int removeUserID))
                                                        {
                                                            throw new System.FormatException("Please enter integer value and try again.");
                                                        }
                                                        UserServices.RemoveUser(removeUserID);
                                                    }
                                                    catch (FormatException ex)
                                                    {
                                                        Console.WriteLine(ex.Message);
                                                    }
                                                    break;
                                                case 4:
                                                    goto AdminChoose;
                                                    default:
                                                        Console.WriteLine("Invalid option. Please try again.", Color.Red);
                                                        break;
                                            }
                                            }
                                            catch (FormatException ex)
                                            {
                                                Console.WriteLine(ex.Message);
                                            }
                                            goto Users;
                                        case 3:
                                            goto Login;
                                        default:
                                            Console.WriteLine("Invalid option. Please try again.", Color.Red);
                                            break;
                                    }

                                }
                                catch (FormatException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                goto AdminChoose;
                            }
                            #endregion AdminMenu
                            
                            foreach (var user in PizzaDatabase.users)
                            {
                                if (username == user.Username && password == user.Password)
                                {
                                    Console.WriteLine($"\nWelcome {username} !");
                                    Userchoose:
                                    MenuManager.MenuManager.ShowPizzaMenu(); 
                                    try
                                    {
                                        if (!int.TryParse(Console.ReadLine(), out int choose1))
                                        {
                                            throw new System.FormatException("Please enter integer value and try again.");
                                        }

                                        switch (choose1)
                                        {
                                        case 1:
                                            PizzaServices.PizzaServices.GetAllPizza();
                                            break;
                                        case 2:
                                        OrdP:
                                            Console.Write("\nEnter the ID of the pizza you want to order: ");
                                            int productId = Convert.ToInt32(Console.ReadLine());

                                            bool productExistsInBasket = PizzaDatabase.basket.Any(item => item.Id == productId);

                                            if (!productExistsInBasket)
                                            {
                                                PizzaServices.PizzaServices.AddBasket(productId);
                                            }
                                            else
                                            {
                                                Console.WriteLine("\nThis product is already in basket.");
                                            }
                                            Basket:
                                            Console.WriteLine("\nBasket List: ");
                                            PizzaServices.PizzaServices.AllBasket();
                                            Ordering:
                                                if (PizzaDatabase.basket.Count() == 0)
                                                {
                                                    Console.WriteLine("\n2. Continue ordering. \n3. Back");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("\n1. Complete order.\n2. Continue ordering. \n3. Back");
                                                }
                                            try
                                            {
                                                if (!int.TryParse(Console.ReadLine(), out int chooseor))
                                                {
                                                    throw new System.FormatException("Please enter integer value and try again.");
                                                }
                                                switch (chooseor)
                                                {
                                                    case 1:
                                                    Delivery:
                                                        if (PizzaDatabase.basket.Count() != 0)
                                                        {
                                                            Console.WriteLine("Enter address: ");
                                                            string address = Console.ReadLine();
                                                            Console.WriteLine("Enter phone number: ");
                                                            try
                                                            {
                                                                string phoneNumber = Console.ReadLine();
                                                                if (!Regex.IsMatch(phoneNumber, @"^\+994(50)|(51)|(55)|(10)|(70)|(77)-[0-9]{3}-[0-9]{2}-[0-9]{2}")) throw new PhoneNumberInvalid("Wrong Phone Number. Ex:+99400-000-00-00");
                                                                Console.WriteLine($"\nAddress: {address}, PhoneNum: {phoneNumber}");
                                                                Console.WriteLine("Your order has been received!");
                                                                PizzaDatabase.basket.Clear();
                                                            }
                                                            catch (PhoneNumberInvalid ex)
                                                            {
                                                                Console.WriteLine(ex.Message);
                                                                goto Delivery;
                                                            }
                                                        }
                                                            else
                                                            {
                                                                Console.WriteLine("Invalid option. Please try again.", Color.Red);
                                                                goto Ordering;
                                                            }
                                                            break;
                                                    case 2:
                                                        Enter1:
                                                            if (PizzaDatabase.basket.Count() == 0)
                                                            {
                                                                Console.WriteLine("\nEnter 1 : Add product to the basket");
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("\nEnter 1 : Add product to the basket,\n" +
                                                                          "Enter 2 : Remove product from the basket.");
                                                            }
                                                            try
                                                        {
                                                            if (!int.TryParse(Console.ReadLine(), out int choosebasket))
                                                            {
                                                                throw new System.FormatException("Please enter integer value and try again.!!!");
                                                            }
                                                            switch (choosebasket)
                                                        {
                                                            case 1:
                                                                goto OrdP;
                                                            case 2:
                                                                if (PizzaDatabase.basket.Count() != 0)
                                                                {
                                                                    Console.Write("\nEnter the ID of the pizza you want to remove from the basket: ");
                                                                    int removeBasketId = Convert.ToInt32(Console.ReadLine());
                                                                
                                                                    PizzaServices.PizzaServices.RemoveFromBasket(removeBasketId);
                                                                
                                                                    Console.WriteLine("\nBasket List: ");
                                                                    PizzaServices.PizzaServices.AllBasket();
                                                                
                                                                    goto Ordering;
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine("Invalid option. Please try again.", Color.Red);
                                                                    goto Enter1;
                                                                }
                                                                break;
                                                            default:
                                                                        Console.WriteLine("Invalid option. Please try again.", Color.Red);
                                                                        goto Enter1;
                                                        }
                                                        }
                                                        catch (FormatException ex)
                                                        {
                                                            Console.WriteLine(ex.Message);
                                                        }
                                                        break;
                                                    case 3:
                                                            goto Userchoose;
                                                        break;
                                                    default:
                                                        Console.WriteLine("Invalid option. Please try again.", Color.Red);
                                                            goto Basket;
                                                    break;
                                                }
                                            }
                                            catch (FormatException ex)
                                            {
                                                Console.WriteLine(ex.Message);
                                            }
                                            break;
                                        case 3:
                                            goto Login;
                                        default:
                                            Console.WriteLine("Invalid option. Please try again.", Color.Red);
                                            break;
                                    }
                                    }
                                    catch (FormatException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    goto Userchoose;
                                }
                                else
                                {
                                    if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                                    {
                                        Console.WriteLine("\nUsername and password cannot be empty or null.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("\n User not found.!");
                                    }
                                    
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
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            
        }
    }
}