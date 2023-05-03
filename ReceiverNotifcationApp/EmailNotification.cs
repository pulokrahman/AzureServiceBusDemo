using SharedApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiverNotifcationApp
{
    public class EmailNotification
    {
        public void SendEmail(Customer c)
        {
            Console.WriteLine($"Email has been sent to {c.Name} for amount {c.BillableAmount}");
        }
    }
}
