using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    public class WorkflowManager
    {
        private ICustomerValidator _customerValidator;
        private INotificationSender _notificationSender;

        public WorkflowManager(ICustomerValidator validator, INotificationSender sender)
        {
            _notificationSender = sender;
            _customerValidator = validator;
        }

        public void AddCustomer(ICustomer customer)
        {
            bool isCustomerValid = _customerValidator.ValidateCustomer(customer);
            customer.Valid = isCustomerValid;
            if (customer.Valid)
            {
                _notificationSender.Send(customer);
            }
                
            else
                Console.WriteLine("you are not a valid customer");
        }
    }
}
