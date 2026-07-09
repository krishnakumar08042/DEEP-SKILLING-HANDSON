using NUnit.Framework;
using Moq;
using CustomerCommLib; 

namespace CustomerComm.Tests
{
    [TestFixture]
    public class CustomerCommTests
    {
        private Mock<IMailSender> _mockMailSender;
        private CustomerComm _customerComm;

        [OneTimeSetUp]
        public void Init()
        {
            _mockMailSender = new Mock<IMailSender>();

            _mockMailSender
                .Setup(m => m.SendMail(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true);

            _customerComm = new CustomerComm(_mockMailSender.Object);
        }

        [TestCase(true)]
        public void SendMailToCustomer_WhenCalled_ReturnsTrue(bool expectedResult)
        {
            bool actualResult = _customerComm.SendMailToCustomer();

            Assert.AreEqual(expectedResult, actualResult);
            
            _mockMailSender.Verify(m => m.SendMail(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}