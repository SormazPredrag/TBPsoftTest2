using TBPsoftTest2.Framework;
using TBPsoftTest2.Models;
using TBPsoftTest2.Pages;

namespace TBPsoftTest2.Tests
{
    internal class RegistrationPageTest : BaseTest
    {
        private RegistrationPage _registrationPage;

        [SetUp]
        public void Setup()
        {
            driver = DriverFactory.GetDriver(DriverType.Chrome);
            _registrationPage = new RegistrationPage(driver);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Parallelizable(ParallelScope.Self)]
        //[TestCase("UserName1", "UserLastName1", "user@m", "Password1", "Password1", "Invalid Email Address")] //@Luka ovaj prolazi
        [TestCase("UserName1", "UserLastName1", "user", "Password1", "Password1", "Invalid Email Address")]
        [TestCase("UserName1", "UserLastName1", "user@mail.com", "Password1", "Password2", "Passwords do not match")]
        public void UserRegistrationInvalidData(string firstName, string lastName, string email, string password, string confirmPassword, string errorMessage)
        {
            driver.Url = "http://ultrasound.tbpsoft.com/Registration/Registration";
            Thread.Sleep(500);

            UserRegistration newUser = new UserRegistration(firstName, lastName, email, password, confirmPassword);

            _registrationPage.RegisterNewUser(newUser);
            
            Thread.Sleep(300);
            List<string> errorMessages = _registrationPage.GetErrorMessages();

            Assert.True(_registrationPage.ConfirmRegistration());
            //Assert.True(errorMessages.Contains(errorMessage));
        }

        [TestCase("UserName1", "UserLastName1", "user@m", "Password1", "Password1", "/Success")]
        public void UserRegistrationSuccsess(string firstName, string lastName, string email, string password, string confirmPassword, string successUrl)
        {
            driver.Url = "http://ultrasound.tbpsoft.com/Registration/Registration";
            Thread.Sleep(500);

            UserRegistration newUser = new UserRegistration(firstName, lastName, email, password, confirmPassword);

            _registrationPage.RegisterNewUser(newUser);

            Thread.Sleep(300);
            List<string> errorMessages = _registrationPage.GetErrorMessages();

            Assert.True(driver.Url.Contains(successUrl));
        }
    }
}
