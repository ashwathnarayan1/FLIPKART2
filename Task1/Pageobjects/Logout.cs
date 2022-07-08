using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Pageobjects
{
    class Logout
    {
        IWebDriver driver;
        public Logout(IWebDriver driver)
        {
            this.driver = driver;

        }
    
      private static By name = By.XPath("(//div[contains(text(),'ASHWATH')])[1]");
        private static By logoutPress = By.XPath("//a[@href='#']");
        public void logout()
        {
            Actions a = new Actions(driver);
            a.MoveToElement(driver.FindElement(name)).Perform();
            a.MoveToElement(driver.FindElement(logoutPress)).Click().Perform();
        }
    }



}
