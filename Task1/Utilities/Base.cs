using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
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
        public ExtentReports extent;
        public ExtentTest test;
        public IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            String reportPath = projectDirectory + "//index.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);          
        }

        [SetUp]
        public void setup1()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

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

        [TearDown]
        public void afterTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;
           
            DateTime time = DateTime.Now;
            String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";
           
            if (status == TestStatus.Failed)
            {
                test.Fail("Test failed", captureScreenShot(driver, fileName));
                test.Log(Status.Fail, "test failed with logtrace" + stackTrace);
            }
            else if (status == TestStatus.Passed)
            {

            }
            extent.Flush();
        }
        public MediaEntityModelProvider captureScreenShot(IWebDriver driver, String screenShotName)

        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            var screenshot = ts.GetScreenshot().AsBase64EncodedString;

            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenShotName).Build();
        }

        [OneTimeTearDown]
        public void closeBrowser()
        {
            Thread.Sleep(2000);
            driver.Quit();
        }
    }
}
