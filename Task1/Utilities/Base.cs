using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task1.Pageobjects;
using WebDriverManager.DriverConfigs.Impl;

namespace Task1.Utilities
{
   public class Base
    {
        public IWebDriver driver;
        [OneTimeSetUp]
        public void OpenBrowser()
        {

            String browserName = ConfigurationManager.AppSettings["browser"];
            InitBrowser(browserName);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.flipkart.com/";

                     
        }
        
        

        public IWebDriver getDriver ()
        {
            return driver;
        }


        public void InitBrowser (string browserName)
        {

            switch (browserName)
            {

                case "Chrome":
                new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                driver = new ChromeDriver();
                    break;

                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;

                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    break;

            }

        }
        [OneTimeTearDown]
        public void closeBrowser()
        {
            Thread.Sleep(2000);
            driver.Quit();
        }
    }
}
