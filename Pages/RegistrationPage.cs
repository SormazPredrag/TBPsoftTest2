using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TBPsoftTest2.Models;

namespace TBPsoftTest2.Pages
{
    internal class RegistrationPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "")]
        private IWebElement _firstName;

        [FindsBy(How = How.XPath, Using = "")]
        private IWebElement _lastName;

        [FindsBy(How = How.XPath, Using = "")]
        private IWebElement _email;

        [FindsBy(How = How.XPath, Using = "")]
        public IWebElement _password;

        [FindsBy(How = How.XPath, Using = "")]
        private IWebElement _confirmPassword;

        [FindsBy(How = How.XPath, Using = "")]
        private IWebElement _register;

        [FindsBy(How = How.XPath, Using = "")]
        private IWebElement _errorMessage;

        public RegistrationPage(IWebDriver driver) : base(driver)
        {

        }

        public void InputFirstName(string firstName)
        {
            throw new NotImplementedException();
        }

        public void InputLastName(string lastName)
        {
            throw new NotImplementedException();
        }

        public void InputEmail(string email)
        {
            throw new NotImplementedException();
        }

        public void InputPassword(string password)
        {
            throw new NotImplementedException();
        }

        public void InputConfirmPassword(string confirmPassword)
        {
            throw new NotSupportedException();
        }

        public void ClickRegisterButton()
        {
            throw new NotImplementedException();
        }

        public string GetErrorMessage()
        {
            throw new NotImplementedException();
        }

        public List<string> GetErrorMessages()
        {
            throw new NotImplementedException();
        }

        public void RegisterNewUser(UserRegistration user)
        {
            InputFirstName(user.FirstName);
            InputLastName(user.LastName);
            InputEmail(user.Email);
            InputPassword(user.Password);
            InputConfirmPassword(user.ConfirmPassword);
            ClickRegisterButton();
        }

        public void ConfirmRegistration()
        {
            throw new NotImplementedException();
        }
    }
}
