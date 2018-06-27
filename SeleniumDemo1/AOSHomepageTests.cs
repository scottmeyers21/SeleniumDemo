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
        //Instantiate driver
        IWebDriver driver = new ChromeDriver();
        [SetUp]
        //Navigate to URL
        public void Initialize() {
            driver.Navigate().GoToUrl("http://www.advantageonlineshopping.com");

        }

        [Test]
        public void LoginTest() {
            //Instantiate Objects class
            AOSHomepageObjects AOSHomepage = new AOSHomepageObjects(driver);
            //Execute Login function
            AOSHomepage.AOSLogin("scott", "Seahawks21!");

            //Navigate to My Account page
            System.Threading.Thread.Sleep(3000);
            driver.SwitchTo().Window(driver.WindowHandles.First());
            AOSHomepage.UserLink.Click();
            AOSHomepage.MyAccountLink.Click();

            System.Threading.Thread.Sleep(3000);
            driver.SwitchTo().Window(driver.WindowHandles.Last());

            //Validate My Account Text
            string MyAccountText = driver.FindElement(By.XPath("/html/body/div[3]/section/article/h3")).Text;
            
            Console.WriteLine(MyAccountText);
           
            Assert.AreEqual(MyAccountText, "MY ACCOUNT");
            
        }
        [TearDown]
        public void Close()
        {
            driver.Quit();

        }
    }
}
