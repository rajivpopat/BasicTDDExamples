using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    public interface INotificationSender
    {
        void Send(ICustomer customer);
    }
}
