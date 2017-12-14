using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BankApp.Tests
{
    [TestClass]
    public class Where_Customer
    {
        [TestMethod]
        public void Is_Greater_Than_18_And_Validated()
        {
            var mockCustomer = new Mock<ICustomer>();
            mockCustomer.SetupProperty(p => p.FirstName, "rajiv");
            mockCustomer.SetupProperty(p => p.LastName, "popat");
            mockCustomer.SetupProperty(p => p.Email, "rajiv_popat@dell.com");
            mockCustomer.SetupProperty(p => p.Age, 19);

            CustomerValidator validator = new CustomerValidator();
            Assert.AreEqual(validator.ValidateCustomer(mockCustomer.Object), true);
            mockCustomer.VerifyGet(p=>p.Age, Times.Once);

        }

        [TestMethod]
        public void Is_Less_Than_18_And_Not_Validated()
        {
            var mockCustomer = new Mock<ICustomer>();
            mockCustomer.SetupProperty(p => p.FirstName, "rajiv");
            mockCustomer.SetupProperty(p => p.LastName, "popat");
            mockCustomer.SetupProperty(p => p.Email , "rajiv_popat@dell.com");
            mockCustomer.SetupProperty(p => p.Age, 17);

            CustomerValidator validator = new CustomerValidator();
            Assert.AreEqual(validator.ValidateCustomer(mockCustomer.Object), false);
            mockCustomer.VerifyGet(p => p.Age, Times.Once);
        }

        [TestMethod]
        public void Is_Greater_Than_18_And_Gets_Email()
        {
            var mockCustomer = new Mock<ICustomer>();
            mockCustomer.SetupAllProperties();
            var mockValidator = new Mock<ICustomerValidator>();
            mockValidator.Setup(p => p.ValidateCustomer(mockCustomer.Object)).Returns(true);
            var mockSender = new Mock<INotificationSender>();

            WorkflowManager manager = new WorkflowManager(mockValidator.Object, mockSender.Object);
            manager.AddCustomer(mockCustomer.Object);
            
            mockValidator.Verify(p=>p.ValidateCustomer(mockCustomer.Object), Times.Once);
            mockCustomer.VerifySet(p=>p.Valid = true);
            mockCustomer.VerifyGet(p=>p.Valid, Times.AtLeastOnce);
            mockSender.Verify(p=>p.Send(mockCustomer.Object), Times.Once);

        }

        [TestMethod]
        public void Is_Less_Than_18_And_Does_Not_Get_Email()
        {
            var mockCustomer = new Mock<ICustomer>();
            mockCustomer.SetupAllProperties();
            var mockValidator = new Mock<ICustomerValidator>();
            mockValidator.Setup(p => p.ValidateCustomer(mockCustomer.Object)).Returns(false);
            var mockSender = new Mock<INotificationSender>();

            WorkflowManager manager = new WorkflowManager(mockValidator.Object, mockSender.Object);
            manager.AddCustomer(mockCustomer.Object);

            mockValidator.Verify(p => p.ValidateCustomer(mockCustomer.Object), Times.Once);
            mockCustomer.VerifySet(p => p.Valid = false);
            mockCustomer.VerifyGet(p => p.Valid, Times.AtLeastOnce);
            mockSender.Verify(p => p.Send(mockCustomer.Object), Times.Never);
        }
    }
}
