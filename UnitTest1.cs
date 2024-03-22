using AngleSharp.Dom;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

using SeleniumExtras.WaitHelpers;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace TBPsoftTest2
{
    public class BasePage
    {
        protected WebDriver webDriver { get; set; } = null;
        private List<string> links = new List<string>();
        private string? currentWindow = null;
        
        protected void waitForElement(IWebElement element)
        {
            var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(3))
            {
                PollingInterval = TimeSpan.FromSeconds(3),
            };         
            wait.Until(_ => element.Displayed && element.Enabled);
        }
        
        protected void scrollToElement(IWebElement element)
        {
            waitForElement(element);
            //new Actions(driver).ScrollToElement(element).Perform();
            webDriver.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
        
        protected void clickElement(IWebElement element)
        {
            waitForElement(element);
            scrollToElement(element);
            //element.Click();
            webDriver.ExecuteScript("arguments[0].click();", element);
            //return element;
        }
        protected IWebElement sendText(IWebElement element, String text)
        {
            waitForElement(element);
            clickElement(element);
            element.Clear();
            element.SendKeys(text);
            return element;
        }

        /*
        [SetUp]
        public void Setup()
        {
            webDriver = new ChromeDriver();
        }

        [TearDown]
        public void TearDown()
        {
            webDriver.Quit();
        }*/


        /*[Test]
        public void Test0()
        {

        }*/

        /*
        [TestCase("trt")]
        public void Test2(string val)
        {
            //Assert.Pass();
            Assert.That(val, Is.EqualTo("trt"));
        }
        */
    }
}