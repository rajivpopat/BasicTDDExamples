namespace BankApp
{
    public interface ICustomerValidator
    {
        bool ValidateCustomer(ICustomer customer);
    }
}