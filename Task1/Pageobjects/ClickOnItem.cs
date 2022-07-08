using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Pageobjects
{
    public class ClickOnItem
    {
        private IWebDriver driver;
        public ClickOnItem(IWebDriver driver)
        {
            this.driver = driver;
            
        }

        
        private static By clickOn = By.XPath("//img[@alt='SAMSUNG Galaxy M32 5G (Sky Blue, 128 GB)']");
        
        public IWebElement getClick()
        {
            return driver.FindElement(clickOn);

        }
        

        public void explicitWait()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//span[@class='_2I9KP_'][1]")));
        }





    }
}
