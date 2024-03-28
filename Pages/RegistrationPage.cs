using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TBPsoftTest2.Models;

namespace TBPsoftTest2.Pages
{
    internal class RegistrationPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "FirstName")]
        private IWebElement _firstName;

        [FindsBy(How = How.Id, Using = "LastName")]
        private IWebElement _lastName;

        [FindsBy(How = How.Id, Using = "Email")]
        private IWebElement _email;

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement _password;

        [FindsBy(How = How.Id, Using = "ConfirmPassword")]
        private IWebElement _confirmPassword;

        [FindsBy(How = How.XPath, Using = ".//input[@type='submit']")]
        private IWebElement _register;

        /*[FindsBy(How = How.XPath, Using = ".//span[class*='field-validation-error']")]
        private IWebElement _errorMessage; */

        [FindsBy(How = How.XPath, Using = ".//span[contains(@class, 'field-validation-error')]")]
        private IList<IWebElement> _errorMessages;

        [FindsBy(How = How.Id, Using = "successMessage")]
        private IWebElement _successMessage;

        public RegistrationPage(IWebDriver driver) : base(driver)
        {

        }

        public void InputFirstName(string firstName)
        {
            SendText(_firstName, firstName);
        }

        public void InputLastName(string lastName)
        {
            SendText(_lastName, lastName);
        }

        public void InputEmail(string email)
        {
            SendText(_email, email);
        }

        public void InputPassword(string password)
        {
            SendText(_password, password);
        }

        public void InputConfirmPassword(string confirmPassword)
        {
            SendText(_confirmPassword, confirmPassword);
        }

        public void ClickRegisterButton()
        {
            ClickElement(_register);
        }

        public string GetErrorMessage()
        {
            List<string> sveGreske = GetErrorMessages();
            string rezultat = "";
            foreach (var greska in sveGreske)
            { 
                rezultat+= greska;
            }
            return rezultat; 
        }

        public List<string> GetErrorMessages()
        {
            List<string> greske = new List<string>();
            //Console.WriteLine(_errorMessages.Count);
            foreach (var error in _errorMessages)
            {
                if (!string.IsNullOrEmpty(error.Text))
                {
                    //Console.WriteLine(error.Text);
                    greske.Add(error.Text);
                }
            }
            return greske;
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

        public bool ConfirmRegistration()
        {
            return _successMessage.Enabled;
        }
    }
}
