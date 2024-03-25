using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace TBPsoftTest2.Framework
{
    public static class DriverFactory
    {
        public static IWebDriver GetDriver(DriverType driverType)
        {
            switch (driverType)
            {
                case DriverType.Chrome:
                    return new ChromeDriver();
                case DriverType.Firefox:
                    return new FirefoxDriver();
                case DriverType.Edge:
                    return new EdgeDriver();
                default:
                    throw new NotSupportedDriverException(driverType);
            }
        }
    }

    public enum DriverType
    {
        Chrome,
        Firefox,
        Edge
    }
}
