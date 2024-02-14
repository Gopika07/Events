using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace Events
{
    public class UserManagement
    {
        public static List<User> users = new List<User>();
        public event EventHandler<Notification> UserEventCompleted;

        public void AddUser(User user)
        {
            users.Add(user);
            OnComplete(new Notification { Action = "Added", UserId = user.Id, UserName = user.Name });
        }
        public void RemoveUser(int id)
        {
            int currUser = users.FindIndex(user => user.Id == id);

            if (currUser != -1)
            {
                User user = users[currUser];
                users.Remove(user);
                OnComplete(new Notification { Action = "Removed", UserId = user.Id, UserName = user.Name });
            }
            else
            {
                Console.WriteLine("User not found!");
            }
        }
        public void UpdateUser(int id)
        {
            int userId = users.FindIndex(user => user.Id == id);
            User cUser = users[userId];
            if(userId!=-1)
            {
                Console.WriteLine("Enter new name:");
                string name = Console.ReadLine();
                cUser.Name = name;
                Console.WriteLine("Enter new email:");
                string email = Console.ReadLine();
                cUser.Email = email;
                Console.WriteLine("Enter new contact:");
                long contact = long.Parse(Console.ReadLine());
                cUser.Contact = contact;
                OnComplete(new Notification { Action = "Updated", UserId = cUser.Id, UserName = cUser.Name });
            }
        }

        protected virtual void OnComplete(Notification e)
        {
            UserEventCompleted?.Invoke(this, e);
        }

    }
}
