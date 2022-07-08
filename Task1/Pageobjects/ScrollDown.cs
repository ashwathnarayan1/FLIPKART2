using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task1.Pageobjects
{
    public class ScrollDown
    {
        IWebDriver driver;
        public  ScrollDown(IWebDriver driver)
        {
            this.driver = driver;
        }

        private static By logo = By.XPath("//a[@href='/']");
        private static By footerLink = By.LinkText("YouTube");
        private static By headerLink = By.XPath("//input[contains(@placeholder,'Search for products, brands and more')]");
        public IWebElement getLogo()
        {
            return driver.FindElement(logo);
        }

        public void scrollingDownFunc()
        {
            IWebElement scrollToFooter = driver.FindElement(footerLink);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", scrollToFooter);
            Thread.Sleep(2000);
           

        }
       
        

        


    }
}
