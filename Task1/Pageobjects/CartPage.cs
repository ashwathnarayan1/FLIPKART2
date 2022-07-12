﻿using OpenQA.Selenium;
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

        private static By scroll = By.XPath("/html[1]/body[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/form[1]/button[1]");
        private static By remove = By.XPath("//div[contains(text(),'Remove')]");
        private static By yesRemove = By.XPath("(//div[@class='_3dsJAO _24d-qY FhkMJZ'])[1]");
        private static By logo = By.XPath("//a[@href='/']");

        public void explicitWait()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='_3dsJAO'][2]")));
        }

        public void scrolls()
        {
            IWebElement validScroll = driver.FindElement(scroll);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", validScroll);
        }

        public IWebElement getRemove()
        {
            return driver.FindElement(remove);
        }

        public IWebElement getYesRemove()
        {
            return driver.FindElement(yesRemove);
        }

        public IWebElement getLogo()
        {
            return driver.FindElement(logo);
        }
    }
}
