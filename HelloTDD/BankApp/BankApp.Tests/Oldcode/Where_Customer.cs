/*
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankApp.Tests
{
    [TestClass]
    public class Where_Customer
    {
        [TestMethod]
        public void Is_Greater_Than_18_And_Validated()
        {
            Customer customer = new Customer();
            customer.FirstName = "rajiv";
            customer.LastName = "popat";
            customer.Email = "rajiv_popat@dell.com";
            customer.Age = 19;
            Assert.AreEqual(CustomerManager.ValidateCustomer(customer), true);
        }

        [TestMethod]
        public void Is_Less_Than_18_And_Not_Validated()
        {
            Customer customer = new Customer();
            customer.FirstName = "rajiv";
            customer.LastName = "popat";
            customer.Email = "rajiv_popat@dell.com";
            customer.Age = 17;
            Assert.AreEqual(CustomerManager.ValidateCustomer(customer), false);

        }
    }
}
*/
