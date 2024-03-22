using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBPsoftTest2
{
    public class HomePageTests : HomePage
    {
        [SetUp]
        public void Setup()
        {
            webDriver = new ChromeDriver();
        }

        [TearDown]
        public void TearDown()
        {
            webDriver.Quit();
        }

        [Test]
        public void Test()
        {
            PageFactory.InitElements(webDriver, this);
            //webDriver = new ChromeDriver(); 
            webDriver.Navigate().GoToUrl("http://ultrasound.tbpsoft.com/");
            //webDriver.Url = "http://ultrasound.tbpsoft.com/";
            Assert.That(webDriver.Title, Is.EqualTo("New user registration - TBP tester"));
            Console.WriteLine(webDriver.Title);

            webDriver.Manage().Window.Maximize();
            //var windowSize = webDriver.Manage().Window.Maximize;
            //webDriver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);

            Assert.True(articleText.Text.Contains("Aliquam at eleifend lorem."));
            Console.WriteLine("Page contains text: " + "Aliquam at eleifend lorem.");
            //Assert.Pass();
        }

    }
}
