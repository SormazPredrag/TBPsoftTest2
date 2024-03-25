using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TBPsoftTest2.Pages
{
    public class HomePage : BasePage
    {
        [FindsBy(How = How.XPath, Using = ".//section[contains(@aria-labelledby, \"gettingStartedTitle\")]//p")]
        public IWebElement articleText;
        public HomePage(IWebDriver driver) : base(driver)
        {

        }
        
    }
}
