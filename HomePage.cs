using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBPsoftTest2
{
    public class HomePage : BasePage
    {
        [FindsBy(How = How.XPath, Using = ".//section[contains(@aria-labelledby, \"gettingStartedTitle\")]//p")]
        public IWebElement articleText;
        public HomePage() : base()
        {
            // Ovde postaviti dodatne inicijalizacije ako su potrebne

        }
        
    }
}
