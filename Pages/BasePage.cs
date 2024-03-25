using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace TBPsoftTest2.Pages
{
    public class BasePage
    {
        public BasePage(IWebDriver driver)
        {
            this.Driver = driver;
            PageFactory.InitElements(Driver, this);
        }

        protected IWebDriver Driver;
        private List<string> links = new List<string>();
        private string? currentWindow = null;
        
        protected void WaitForElement(IWebElement element)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(3))
            {
                PollingInterval = TimeSpan.FromSeconds(3),
            };         
            wait.Until(_ => element.Displayed && element.Enabled);
        }
        
        protected void ScrollToElement(IWebElement element)
        {
            WaitForElement(element);
            //new Actions(driver).ScrollToElement(element).Perform();
            (Driver as WebDriver)?.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
        
        public void ClickElement(IWebElement element)
        {
            WaitForElement(element);
            ScrollToElement(element);
            //element.Click();
            (Driver as WebDriver)?.ExecuteScript("arguments[0].click();", element);
            //return element;
        }
        public IWebElement SendText(IWebElement element, string text)
        {
            WaitForElement(element);
            ClickElement(element);
            element.Clear();
            element.SendKeys(text);
            return element;
        }
    }
}