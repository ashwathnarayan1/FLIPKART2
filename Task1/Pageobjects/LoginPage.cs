using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Pageobjects
{
    public class LoginPage
    {
        private IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
              
        }


        private static By phNo = By.XPath("//input[@class='_2IX_2- VJZDxU']");

        
        private static By password = By.XPath("//input[@type='password']");

        
        private static By signIn = By.XPath("//button[@class='_2KpZ6l _2HKlqd _3AWRsL']");

        public void validLogin (string pnum, string pass)
        {
            driver.FindElement(phNo).SendKeys(pnum);
            driver.FindElement (password).SendKeys(pass);
            driver.FindElement(signIn).Click();
           
        }


    }

}
