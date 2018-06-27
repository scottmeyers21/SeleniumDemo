using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDemo1
{
    public class AOSHomepageObjects
    {
        IWebDriver driver;

        public AOSHomepageObjects(IWebDriver driver) {
            this.driver = driver;
        }
        public IWebElement UserLink{
            get
            {
                return driver.FindElement(By.Id("menuUser"));
            }
        }
        public IWebElement UserNameField {
            get {
                return driver.FindElement(By.Name("username"));
            }
        }
        public IWebElement PasswordField {
            get {
                return driver.FindElement(By.Name("password"));
            }
        }
        public IWebElement SignInButton {
            get {
                return driver.FindElement(By.Id("sign_in_btnundefined"));
            }
        }


        public void AOSLogin(string username, string password) {
            string CurrentWindow = driver.CurrentWindowHandle;
            UserLink.Click();
            System.Threading.Thread.Sleep(3000);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            UserNameField.SendKeys(username);
            PasswordField.SendKeys(password);
            SignInButton.Click();

        }
    }
}
