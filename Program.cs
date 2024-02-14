using Events;
using System.ComponentModel.DataAnnotations;

class Program
{
    public static void Main()
    {
        int id;
        _ = new User { Name = "John", Id = 100, Email = "johndoe@gmail.com", Contact = 9963521485 };
        _ = new User { Name = "Jane", Id = 101, Email = "janedoe@gmail.com", Contact = 9632587485 };

        UserManagement um = new UserManagement();
        um.UserEventCompleted += Notification.um_Notification;

        while (true)
        {
            Console.WriteLine("User Management Menu:");
            Console.WriteLine("1. Add User");
            Console.WriteLine("2. Remove User");
            Console.WriteLine("3. Update User");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Enter new name:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter new email:");
                    string email = Console.ReadLine();
                    Console.WriteLine("Enter new contact:");
                    long contact = long.Parse(Console.ReadLine());

                    User user = new User { Name = name, Id = 103, Email = email, Contact = contact };
                    um.AddUser(user);
                    break;
                case "2":
                    Console.WriteLine("Enter id of the iuser to be removed:");
                    id = int.Parse(Console.ReadLine());
                    um.RemoveUser(id);
                    break;
                case "3":
                    Console.WriteLine("Enter id of the iuser to be updated:");
                    id = int.Parse(Console.ReadLine());
                    um.UpdateUser(id);
                    break;
                case "4":
                    Environment.Exit(0);
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}