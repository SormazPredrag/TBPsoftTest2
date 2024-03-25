using TBPsoftTest2.Framework;
using TBPsoftTest2.Pages;

namespace TBPsoftTest2.Tests
{
    public class HomePageTests : BaseTest
    {
        private HomePage _homePage;
        [SetUp]
        public void Setup()
        {
            base.driver = DriverFactory.GetDriver(DriverType.Chrome);
            _homePage = new HomePage(base.driver);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void Test()
        {
            driver.Navigate().GoToUrl("http://ultrasound.tbpsoft.com/");
            //webDriver.Url = "http://ultrasound.tbpsoft.com/";
            Assert.That(driver.Title, Is.EqualTo("New user registration - TBP tester"));
            Console.WriteLine(driver.Title);

            driver.Manage().Window.Maximize();
            //var windowSize = webDriver.Manage().Window.Maximize;
            //webDriver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);

            Assert.True(_homePage.articleText.Text.Contains("Aliquam at eleifend lorem."));
            Console.WriteLine("Page contains text: " + "Aliquam at eleifend lorem.");
            //Assert.Pass();
        }

    }
}
