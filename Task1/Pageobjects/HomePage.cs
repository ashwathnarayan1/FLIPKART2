using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task1.Pageobjects
{
    class HomePage
    {
        private  IWebDriver driver;
        public HomePage (IWebDriver driver)
        {
            this.driver = driver;
        }

        private static By phNo = By.XPath("//input[@class='_2IX_2- VJZDxU']");
        private static By password = By.XPath("//input[@type='password']");
        private static By signIn = By.XPath("//button[@class='_2KpZ6l _2HKlqd _3AWRsL']");
        private static By search = By.XPath("//input[@class='_3704LK']");
        private static By text = By.XPath("//div[contains(text(),'SAMSUNG Galaxy M32 5G (Sky Blue, 128 GB)')]");
        private static By footerLink = By.LinkText("YouTube");
        private static By name = By.XPath("(//div[contains(text(),'ASHWATH')])[1]");
        private static By logoutPress = By.XPath("//a[@href='#']");

        public void ValidLogin (string pnum, string pass)
        {
            driver.FindElement(phNo).SendKeys(pnum);
            driver.FindElement(password).SendKeys(pass);
            driver.FindElement(signIn).Click();
        }

        public void ValidSearch (string find)
        {
            driver.FindElement(search).SendKeys(find);
            Thread.Sleep(2000);
            driver.FindElement(search).SendKeys(Keys.Enter);
        }

        public IWebElement GetText ()
        {
            return driver.FindElement(text);
        }

        public void ScrollingDownFunc ()
        {
            IWebElement scrollToFooter = driver.FindElement(footerLink);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", scrollToFooter);
            Thread.Sleep(2000);
        }

        public void ExplicitWait ()
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[@class='_3704LK']")));
        }

        public void Logout ()
        {
            Actions a = new Actions(driver);
            a.MoveToElement(driver.FindElement(name)).Perform();
            driver.FindElement(logoutPress).Click();
            Thread.Sleep(3000);
        }
    }
}

