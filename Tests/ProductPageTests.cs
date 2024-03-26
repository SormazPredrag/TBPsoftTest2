using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TBPsoftTest2.Framework;
using TBPsoftTest2.Pages;

namespace TBPsoftTest2.Tests
{
    public class ProductPageTests :  BaseTest
    {
        private ProductPage _productPage;
        string searchText = "Egyptian Cotton Towel";
        [SetUp]
        public void Setup()
        {
            base.driver = DriverFactory.GetDriver(DriverType.Chrome);
            _productPage = new ProductPage(base.driver);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void Test()
        {
            //webDriver = new ChromeDriver();
            driver.Url = "http://ultrasound.tbpsoft.com/Store";
            Thread.Sleep(1000);
            _productPage.list_prvaStrana = new List<string>();
            _productPage.list_drugaStrana = new List<string>();

            Console.WriteLine("Current page is: " + _productPage.GetCurrentPageNumber().ToString());
            var productItems = driver.FindElements(By.XPath(".//div[contains(@class, 'product-item')]//h5"));
            Console.WriteLine("Prebrojano 1: " + _productPage.list_productItems.Count);
            Assert.True(productItems.Count == 12);

            foreach (var productItem in _productPage.list_productItems)
            {
                //Console.WriteLine(productItem.Text);
                _productPage.list_prvaStrana.Add(productItem.Text);
            }
            //_productPage.ClickElement(_productPage.secondPageLink);
            //_productPage.OpenNextPage();
            _productPage.GoOnPage(2);

            Thread.Sleep(1000);
            Console.WriteLine("Current page is: " + _productPage.GetCurrentPageNumber().ToString());
            var productItems2 = driver.FindElements(By.XPath(".//div[contains(@class, 'product-item')]//h5"));
            Console.WriteLine("Prebrojano 2: " + _productPage.list_productItems.Count);
            Assert.True(_productPage.list_productItems.Count == 12);
            foreach (var productItem2 in productItems2)
            {
                //Console.WriteLine(productItem2.Text);
                _productPage.list_drugaStrana.Add(productItem2.Text);
            }

            Assert.False(_productPage.list_prvaStrana.SequenceEqual(_productPage.list_drugaStrana));

            //inputSearch.Clear();
            //inputSearch.SendKeys("Egyptian Cotton Towel");
            _productPage.SendText(_productPage.inputSearch, searchText);

            //searchButton.Click();
            _productPage.ClickElement(_productPage.searchButton);
            Thread.Sleep(1000);
            //var productItemsSearch = webDriver.FindElements(By.ClassName("product-item"));
            var nadjeno = _productPage.productItemsSearch.Count;
            //Assert.AreNotEqual(0, nadjeno);
            Assert.That(nadjeno, Is.Not.EqualTo(0));
            Console.WriteLine("Pronađeno elemenata: " + nadjeno);
            (driver as WebDriver)?.ExecuteScript($"console.log('Nadjeno proizvoda: {nadjeno}')");
            //webDriver.GetPageErrors().Should().BeEmpty();

            Assert.True(_productPage.productPrice1.Enabled);
            Assert.True(_productPage.productPrice1.Text.Contains("Price: $49.99"));
            //var productPrice = webDriver.FindElement(By.XPath(".//*[contains(text(),'Price: $49.99')]"));
            var productAvailable = driver.FindElement(By.XPath(".//*[contains(text(),'Available: Yes')]"));
        }

    }
}
