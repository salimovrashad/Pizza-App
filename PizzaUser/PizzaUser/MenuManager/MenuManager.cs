using System.Drawing;

namespace PizzaUser.MenuManager;
public static class MenuManager
{
    public static void ShowLoginMenu() => Console.WriteLine("\nChoose from below option: \n1. Sign up. \n2. Login. \n3. Exit.", Color.Yellow);

    public static void ShowPizzaMenu() => Console.WriteLine("\nChoose from below option: \n1. Look pizzas. \n2. Order pizza. \n3. Exit.", Color.Yellow);

    public static void ShowAdminMenu() => Console.WriteLine("\nChoose from below option: \n1. Pizzas. \n2. Users. \n3. Logout Admin.", Color.Red);

    public static void ShowPizzaManageMenu() => Console.WriteLine("\nChoose from below option: \n1. All pizzas. \n2. Add pizza. \n3. Edit pizza by ID. \n4. Back.", Color.Yellow);

    public static void ShowUserManageMenu() => Console.WriteLine("\nChoose from below option: \n1. All users. \n2. Add users. \n3. Edit user by ID. \n4. Remove user by ID. \n5. Back.", Color.Yellow);
}
