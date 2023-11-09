using PizzaUser.Database;
using PizzaUser.Exception;
using PizzaUser.Exceptions;
using PizzaUser.Models;
using PizzaUser.Services;
using System.Drawing;
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
                Thread.Sleep(90);
            }

             
            while (true)
            {

            Login:
                Console.WriteLine("\nChoose from below option: \n1. Sign up. \n2. Login. \n3. Exit", Color.Yellow);
                int choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 1:

                        try
                        {
                            Users users = new Users();

                            Console.WriteLine("Name: ");
                            users.Name = Console.ReadLine();
                            Console.WriteLine("Surname: ");
                            users.Surname = Console.ReadLine();
                            Console.WriteLine("Password: ");
                            users.Password = Console.ReadLine();

                            UserServices.AddUser(users);
                        }

                        catch (UserNameInvalid ex) 
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (PasswordInvalid ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;
                    case 2:
                        Console.WriteLine("Adi daxil edin: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Sifre daxil edin: ");
                        string password = Console.ReadLine();

                        if (name == "admin" && password == "admin")
                        {
                        AdminChoose:
                            Console.WriteLine("\nChoose from below option: \n1. Pizzas. \n2. Users. \n3. Logout Admin", Color.Red);
                            int chooseadmin = Convert.ToInt32(Console.ReadLine());
                            switch (chooseadmin)
                            {
                                case 1:
                                Pizzas:
                                    Console.WriteLine("\nChoose from below option: \n1. All pizza. \n2. Add pizza. \n3. Edit pizza by ID. \n4. Back");
                                    int choose3 = Convert.ToInt32(Console.ReadLine());
                                    switch (choose3)
                                    {
                                        case 1:

                                            PizzaServices.PizzaServices.GetAllPizza();

                                            break;
                                        case 2:

                                            Products pizza = new Products();

                                            Console.WriteLine("Pizza Name: ");
                                            pizza.PizzaName = Console.ReadLine();
                                            Console.WriteLine("Pizza Price: ");
                                            pizza.Price = Convert.ToInt32(Console.ReadLine());

                                            PizzaServices.PizzaServices.AddPizza(pizza);

                                            break;
                                        case 3:
                                            Console.WriteLine("Edit id input: ");
                                            int editinp = Convert.ToInt32(Console.ReadLine());

                                            Products updatedProduct = PizzaServices.PizzaServices.UpProductById(editinp);
                                            Console.WriteLine("Name: ");
                                            updatedProduct.PizzaName = Console.ReadLine();
                                            Console.WriteLine("Price: ");
                                            updatedProduct.Price = Convert.ToInt32(Console.ReadLine());

                                            Console.WriteLine("Update successfull!!!");
                                            break;
                                        case 4:
                                            goto AdminChoose;
                                    }
                                    goto Pizzas;
                                case 2:
                                    UserServices.AllUsers();
                                    break;
                                case 3:
                                    goto Login;
                            }
                            goto AdminChoose;
                        }

                        foreach (var item in PizzaDatabase.users)
                        {
                            if (name == item.Name && password == item.Password)
                            {
                            Userchoose:
                                Console.WriteLine("Choose from below option: \n1. Look pizzas. \n2. Order pizza. \n3. Exit", Color.Yellow);
                                int choose1 = Convert.ToInt32(Console.ReadLine());

                                switch (choose1)
                                {
                                    case 1:
                                        PizzaServices.PizzaServices.GetAllPizza();
                                        break;
                                    case 2:
                                        Console.Write("Enter ID of the pizza you want to order: ");
                                        int productId = Convert.ToInt32(Console.ReadLine());

                                        Products selectedPizza = PizzaDatabase.products.Find(product => product.Id == productId);

                                        try
                                        {
                                            if (selectedPizza != null)
                                            {
                                                Console.Write("Enter number of pizza: ");
                                                int count = Convert.ToInt32(Console.ReadLine());
                                                int totalPrice = selectedPizza.Price * count;
                                                Console.WriteLine($"Total Price => {totalPrice}");
                                                Console.WriteLine("S - Add to basket \nG - Back");
                                                char choose4 = Convert.ToChar(Console.ReadLine());
                                                switch (choose4)
                                                {
                                                    case 'S':
                                                        Console.WriteLine("Added to basket!");
                                                        Console.WriteLine("Do you want to order? (Y - yes, N - no)");
                                                        char choose5 = Convert.ToChar(Console.ReadLine());
                                                        if (choose5 == 'Y')
                                                        {

                                                            Console.WriteLine("Enter address: ");
                                                            string address = Console.ReadLine();
                                                            Console.WriteLine("Enter phone number: ");
                                                            string phoneNumber = Console.ReadLine();

                                                            Console.WriteLine("Your order has been received!");

                                                        }
                                                        else if (choose5 == 'N')
                                                        {
                                                            PizzaServices.PizzaServices.GetAllPizza();
                                                        }
                                                        break;
                                                    case 'G':
                                                        PizzaServices.PizzaServices.GetAllPizza();
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                throw new ProductNullException("Bu ID-de olan mehsul yoxdur!!!");
                                            }
                                        }
                                        catch (ProductNullException ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                        }
                                        break;
                                    case 3:
                                        goto Login;
                                }
                                goto Userchoose;
                            }

                            else
                            {
                                Console.WriteLine("Bele user yoxdu!!!");
                            }
                        }
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                }
            }
            
            
        }
    }
}