using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Pageobjects
{
    class MobilesPage
    {
        private IWebDriver driver;
        public MobilesPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private static By electronics = By.XPath("/html[1]/body[1]/div[1]/div[1]/div[2]/div[1]/div[1]/span[1]");
        private static By options = By.ClassName("._3QN6WI");
       
        public void MobilesUnderElectronics()
        {
            Actions a = new Actions(driver);
            a.MoveToElement(driver.FindElement(electronics)).Perform();
            IList<IWebElement> mobileoptions = driver.FindElements(options);
            TestContext.Progress.WriteLine(mobileoptions);           
        }     
    }
}
