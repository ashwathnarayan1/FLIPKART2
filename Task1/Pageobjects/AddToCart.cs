using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Pageobjects
{
    public class AddToCart
    {
        private IWebDriver driver;
        public AddToCart(IWebDriver driver)
        {
            this.driver = driver;

        }


        private static By cart = By.XPath("//button[@class='_2KpZ6l _2U9uOA _3v1-ww']");
        private static By mycart = By.XPath("(//div[@class='_3g_HeN'])[1]");
        public void clickToAddToCart()
        {
            driver.FindElement(cart).Click();

        }
        public IWebElement getMycart()
        {
            return driver.FindElement(mycart);
        }
    }
}
