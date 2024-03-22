using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SeleniumExtras.PageObjects;
using AngleSharp.Dom;

namespace TBPsoftTest2
{
    public class ProductPage : BasePage
    {
        //private WebDriver driver { get; set; } = null;
        [FindsBy(How = How.XPath, Using = ".//div[contains(@class, 'product-item')]//h5")]
        private IList<IWebElement> list_productItems;
        [FindsBy(How = How.ClassName, Using = "product-item")]
        private IList<IWebElement> productItemsSearch;
        [FindsBy(How = How.XPath, Using = ".//a[@href='/Store?pageNumber=2']")]
        private IWebElement secondPageLink;  //".//a[contains(text(), 'Next')]"
        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")] 
        private IWebElement searchButton;
        [FindsBy(How = How.CssSelector, Using = "Input[class*='form-control']")]
        private IWebElement inputSearch;
        [FindsBy(How = How.XPath, Using = ".//*[contains(text(),'Price: $49.99')]")]
        private IWebElement productPrice1;

        private List<string> list_prvaStrana;
        private List<string> list_drugaStrana;
        public ProductPage() : base()
        //public ProductPage(WebDriver driver) : base(driver)
        {

        }

        [Test]
        public void Test3()
        {
            PageFactory.InitElements(webDriver, this);

            //webDriver = new ChromeDriver();
            webDriver.Url = "http://ultrasound.tbpsoft.com/Store";
            Thread.Sleep(1000);
            list_prvaStrana = new List<string>();
            list_drugaStrana = new List<string>();

            var productItems = webDriver.FindElements(By.XPath(".//div[contains(@class, 'product-item')]//h5"));
            Console.WriteLine("Prebrojano 1: " + list_productItems.Count);
            Assert.True(productItems.Count == 12);
            
            foreach (var productItem in list_productItems)
            {
                //Console.WriteLine(productItem.Text);
                list_prvaStrana.Add(productItem.Text);
            }

            clickElement(webDriver, secondPageLink);

            Thread.Sleep(1000);
            var productItems2 = webDriver.FindElements(By.XPath(".//div[contains(@class, 'product-item')]//h5"));
            Console.WriteLine("Prebrojano 2: " + list_productItems.Count);
            Assert.True(list_productItems.Count == 12);
            foreach (var productItem2 in productItems2)
            {
                //Console.WriteLine(productItem2.Text);
                list_drugaStrana.Add(productItem2.Text);
            }

            Assert.False(list_prvaStrana.SequenceEqual(list_drugaStrana));

            inputSearch.Clear();
            inputSearch.SendKeys("Egyptian Cotton Towel");

            //searchButton.Click();
            clickElement(webDriver, searchButton);
            Thread.Sleep(1000);
            //var productItemsSearch = webDriver.FindElements(By.ClassName("product-item"));
            var nadjeno = productItemsSearch.Count;
            //Assert.AreNotEqual(0, nadjeno);
            Assert.That(nadjeno, Is.Not.EqualTo(0));
            Console.WriteLine("Pronađeno elemenata: " + nadjeno);
            webDriver.ExecuteScript($"console.log('Nadjeno proizvoda: {nadjeno}')");
            //webDriver.GetPageErrors().Should().BeEmpty();

            Assert.True(productPrice1.Enabled);
            Assert.True(productPrice1.Text.Contains("Price: $49.99"));
            //var productPrice = webDriver.FindElement(By.XPath(".//*[contains(text(),'Price: $49.99')]"));
            var productAvailable = webDriver.FindElement(By.XPath(".//*[contains(text(),'Available: Yes')]"));
        }
    }
}
