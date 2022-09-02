using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Pageobjects
{
    class ProductDescrptionPage
    {
        private IWebDriver driver;
        public ProductDescrptionPage (IWebDriver driver)
        {
            this.driver = driver;
        }

        private static By cart = By.XPath("//button[@class='_2KpZ6l _2U9uOA _3v1-ww']");
        private static By mycart = By.CssSelector("._2FYYw1._2_OGP3._2T1qz2");

        public void ClickToAddToCart()
        {
            driver.FindElement(cart).Click();
        }

        public IWebElement GetMycart()
        {
            return driver.FindElement(mycart);
        }
    }
}
