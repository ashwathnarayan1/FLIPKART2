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
    public class CartPage
    {
        private IWebDriver driver;
        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private static By scroll = By.CssSelector("div[class='_22qcVs _2EGuYt col col-4-12'] span:nth-child(1)");
        private static By remove = By.XPath("//div[contains(text(),'Remove')]");
        private static By yesRemove = By.XPath("(//div[@class='_3dsJAO _24d-qY FhkMJZ'])[1]");
        private static By logo = By.XPath("//a[@href='/']");
        private static By mycart = By.XPath("(//div[@class='_3g_HeN'])[1]");

        public void ExplicitWait()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='_3dsJAO'][2]")));
        }

        public void Scrolls()
        {
            IWebElement validScroll = driver.FindElement(scroll);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", validScroll);
        }

        public IWebElement GetRemove()
        {
            return driver.FindElement(remove);
        }

        public IWebElement GetYesRemove()
        {
            return driver.FindElement(yesRemove);
        }

        public IWebElement GetLogo()
        {
            return driver.FindElement(logo);
        }

        public IWebElement GetMycart()
        {
            return driver.FindElement(mycart);
        }
    }
}
