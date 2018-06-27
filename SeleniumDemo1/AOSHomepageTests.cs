using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDemo1
{
    class AOSHomepageTests
    {
        IWebDriver driver = new ChromeDriver();
        [SetUp]
        public void Initialize() {
            driver.Navigate().GoToUrl("http://www.advantageonlineshopping.com");

        }

        [Test]
        public void LoginTest() {
            AOSHomepageObjects AOSHomepage = new AOSHomepageObjects(driver);
            AOSHomepage.AOSLogin("scott", "Seahawks21!");

            System.Threading.Thread.Sleep(3000);
            driver.SwitchTo().Window(driver.WindowHandles.First());
            AOSHomepage.UserLink.Click();
            driver.FindElement(By.XPath("//*[@id='loginMiniTitle']/label[1]")).Click();

            driver.SwitchTo().Window(driver.WindowHandles.Last());
            string MyAccountText = driver.FindElement(By.TagName("h3")).Text;
            Console.WriteLine(MyAccountText);

        }
        [TearDown]
        public void Close() {
            driver.Quit();

        }
    }
}
