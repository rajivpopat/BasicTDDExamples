namespace BankApp
{
    public class CustomerValidator : ICustomerValidator
    {
        public bool ValidateCustomer(ICustomer customer)
        {
            if (customer.Age > 18)
                return true;
            return false;
        }
    }
}