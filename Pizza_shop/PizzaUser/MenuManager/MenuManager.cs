using System.Drawing;

namespace PizzaUser.MenuManager;
public static class MenuManager
{
    public static void ShowLoginMenu()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nChoose from below option: \n1. Sign up. \n2. Login. \n3. Exit.");
        Console.ResetColor();
    }

    public static void ShowPizzaMenu()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nChoose from below option: \n1. Look pizzas. \n2. Order pizza. \n3. Exit.");
        Console.ResetColor();
    }

    public static void ShowAdminMenu()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nChoose from below option: \n1. Pizzas. \n2. Users. \n3. Logout Admin.");
        Console.ResetColor();
    }

    public static void ShowPizzaManageMenu()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nChoose from below option: \n1. All pizzas. \n2. Add pizza. \n3. Edit pizza by ID. \n4. Remove pizza by ID. \n5. Back.");
        Console.ResetColor();
    }

    public static void ShowUserManageMenu()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nChoose from below option: \n1. All users. \n2. Edit user by ID. \n3. Remove user by ID. \n4. Back.");
        Console.ResetColor();
    }
}
