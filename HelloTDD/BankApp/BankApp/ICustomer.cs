using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    public interface ICustomer
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }

        int Age { get; set; }

        bool Valid { get; set; }
    }
}
