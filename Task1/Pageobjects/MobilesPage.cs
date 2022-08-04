using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task1.Pageobjects
{
    class MobilesPage
    {
        private IWebDriver driver;
        public MobilesPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private static By electronics = By.XPath("/html[1]/body[1]/div[1]/div[1]/div[2]/div[1]/div[1]/span[1]");
        private static By mi = By.XPath("//a[@title='Mi']");
        private static By realme = By.XPath("//a[@title='Realme']");
        private static By samsung = By.XPath("//a[@title='Samsung']");
        private static By infinix = By.XPath("//a[@title='Infinix']");
        private static By oppo = By.XPath("//a[@title='OPPO']");
        private static By apple = By.XPath("//a[@title='Apple']");
        private static By vivo = By.XPath("//a[@title='Vivo']");
        private static By honor = By.XPath("//a[@title='Honor']");
        private static By asus = By.XPath("//a[@title='Asus']");
        private static By poco = By.XPath("//a[@title='Poco X2']");
        private static By narzo10 = By.XPath("//a[@title='realme Narzo 10']");
        private static By infinixhot = By.XPath("//a[@title='Infinix Hot 9']");
        private static By iqoo = By.XPath("//a[@title='IQOO 3']");
        private static By iphonese = By.XPath("//a[@title='iPhone SE']");
        private static By razr = By.XPath("//a[@title='Motorola razr']");
        private static By narzo10a= By.XPath("//a[@title='realme Narzo 10A']");
        private static By motorola = By.XPath("//a[@title='Motorola g8 power lite']");

        ArrayList actualmobiles = new ArrayList();
        ArrayList expectedmobiles = new ArrayList();

        public void MobilesUnderElectronics()
        {
            Actions a = new Actions(driver);
            a.MoveToElement(driver.FindElement(electronics)).Perform();
            Thread.Sleep(2000);
          
            actualmobiles.Add(driver.FindElement(mi).Text);
            actualmobiles.Add(driver.FindElement(realme).Text);
            actualmobiles.Add(driver.FindElement(samsung).Text);
            actualmobiles.Add(driver.FindElement(infinix).Text);
            actualmobiles.Add(driver.FindElement(oppo).Text);
            actualmobiles.Add(driver.FindElement(apple).Text);
            actualmobiles.Add(driver.FindElement(vivo).Text);
            actualmobiles.Add(driver.FindElement(honor).Text);
            actualmobiles.Add(driver.FindElement(asus).Text);
            actualmobiles.Add(driver.FindElement(poco).Text);
            actualmobiles.Add(driver.FindElement(narzo10).Text);
            actualmobiles.Add(driver.FindElement(infinixhot).Text);
            actualmobiles.Add(driver.FindElement(iqoo).Text);
            actualmobiles.Add(driver.FindElement(iphonese).Text);
            actualmobiles.Add(driver.FindElement(razr).Text);
            actualmobiles.Add(driver.FindElement(narzo10a).Text);
            actualmobiles.Add(driver.FindElement(motorola).Text);

            foreach (string item in actualmobiles)
            {
                TestContext.Progress.WriteLine(item);
            }
      
            expectedmobiles.Add("Mi");
            expectedmobiles.Add("Realme");
            expectedmobiles.Add("Samsung");
            expectedmobiles.Add("Infinix");
            expectedmobiles.Add("OPPO");
            expectedmobiles.Add("Apple");
            expectedmobiles.Add("Vivo");
            expectedmobiles.Add("Honor");
            expectedmobiles.Add("Asus");
            expectedmobiles.Add("Poco X2");
            expectedmobiles.Add("realme Narzo 10");
            expectedmobiles.Add("Infinix Hot 9");
            expectedmobiles.Add("IQOO 3");
            expectedmobiles.Add("iPhone SE");
            expectedmobiles.Add("Motorola razr");
            expectedmobiles.Add("realme Narzo 10A");
            expectedmobiles.Add("Motorola g8 power lite");

            foreach (string item1 in expectedmobiles)
            {
                TestContext.Progress.WriteLine(item1);
            }
        }     

       public ArrayList GetActualMobiles()
        {
            return actualmobiles;
        }

        public ArrayList GetExpectedMobiles()
        {
            return expectedmobiles;
        }
    }
}
