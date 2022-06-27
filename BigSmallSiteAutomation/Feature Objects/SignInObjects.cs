using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BigSmallSiteAutomation.Feature_Objects
{
    class SignInObjects
    {
        WebDriverWait wait = new WebDriverWait(Hooks.driver,TimeSpan.FromSeconds(30));
        IWebDriver _driver = Hooks.driver;
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void GotoHomepage()
        {
            _driver.Navigate().GoToUrl("https://www.bigsmall.in/");
            log.Debug("Homepage opened.");
        }

        public void GotoLoginPage()
        {
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[.='sign in']")));
                _driver.FindElement(By.XPath("//span[.='sign in']")).Click();
                log.Info("Login page Opened.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                log.Error("Login Page not Opened.");
            }
        }

        public void EnterIdPass(string username,string password)
        {
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//input[@type='email']")).SendKeys(username);
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//input[@type='password']")).SendKeys(password);
            log.Info("Login credentials Entered.");
        }

        public void ClickOnSignIn()
        {
            Thread.Sleep(2000);
            _driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            log.Info("Signin button worked.");
        }
        public void VerifyAccount()
        {
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//p[.='Adarsh Kumar']")));
            IWebElement ele = _driver.FindElement(By.XPath("//p[.='Adarsh Kumar']"));
            bool value = ele.Displayed;
            Assert.AreEqual(true, value);
            log.Debug("User Account Page Opened.");
            ((ITakesScreenshot)_driver).GetScreenshot().SaveAsFile(@"C:\Users\mindtreefeb86\source\repos\BigSmallSiteAutomation\BigSmallSiteAutomation\Feature Objects\SignInScreenshot.png", ScreenshotImageFormat.Png);
            log.Warn("Screenshot taken.");
        }
    }
}
