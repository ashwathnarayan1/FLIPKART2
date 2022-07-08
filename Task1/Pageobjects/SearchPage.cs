using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task1.Pageobjects
{
    public class SearchPage
    {
       private IWebDriver driver;
        public SearchPage(IWebDriver driver)
        {
            this.driver = driver;
           
        }


        private static By search = By.XPath("//input[@class='_3704LK']");

        private static By text = By.XPath("//div[contains(text(),'SAMSUNG Galaxy M32 5G (Sky Blue, 128 GB)')]");

        public IWebElement getText()
        {
            return driver.FindElement(text);
        }

        public void validSearch(string find)
        {
            driver.FindElement(search).SendKeys(find);
            Thread.Sleep(2000);
            driver.FindElement(search).SendKeys(Keys.Enter);
        }

       

        public void explicitWait()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[@class='_3704LK']")));
        }

    }
}
