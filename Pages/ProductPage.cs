using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TBPsoftTest2.Pages
{
    public class ProductPage : BasePage, IHavePagination
    {
        //private WebDriver driver { get; set; } = null;
        [FindsBy(How = How.XPath, Using = ".//div[contains(@class, 'product-item')]//h5")]
        public IList<IWebElement> list_productItems;
        [FindsBy(How = How.ClassName, Using = "product-item")]
        public IList<IWebElement> productItemsSearch;
        [FindsBy(How = How.XPath, Using = ".//a[@href='/Store?pageNumber=2']")]
        public IWebElement secondPageLink;  //".//a[contains(text(), 'Next')]"
        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        public IWebElement searchButton;
        [FindsBy(How = How.CssSelector, Using = "Input[class*='form-control']")]
        public IWebElement inputSearch;
        [FindsBy(How = How.XPath, Using = ".//*[contains(text(),'Price: $49.99')]")]
        public IWebElement productPrice1;

        public List<string> list_prvaStrana;
        public List<string> list_drugaStrana;
        public ProductPage(IWebDriver driver) : base(driver)
        //public ProductPage(WebDriver driver) : base(driver)
        {

        }

        public void GetCurrentPageNumber()
        {
            throw new NotImplementedException();
        }

        public void OpenNextPage()
        {
            throw new NotImplementedException();
        }

        public void OpenPreviousPage()
        {
            throw new NotImplementedException();
        }

        public void GoOnPage(int pageNumber)
        {
            throw new NotImplementedException();
        }
    }
}
