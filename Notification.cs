using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class Notification : EventArgs
    {
        public string Action { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public static void um_Notification(object sender, Notification e)
        {
            Console.WriteLine($"User {e.Action} - {e.UserId}: {e.UserName}");
        }
    }
}
