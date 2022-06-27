using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace BigSmallSiteAutomation.Feature_Objects
{
    class TrackOrderObjects
    {
        WebDriverWait wait = new WebDriverWait(Hooks.driver, TimeSpan.FromSeconds(20));
        IWebDriver _driver = Hooks.driver;
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void ClickOnTrack()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@href='/pages/track-your-order']")));
            _driver.FindElement(By.XPath("//a[@href='/pages/track-your-order']")).Click();
            log.Info("Track link is working.");
        }

        public void EnterValidEmail()
        {
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.Id("ola_email")));
            _driver.FindElement(By.Id("ola_email")).SendKeys("swastikverma1993@gmail.com");
            log.Info("Email Accepted.");
        }

        public void EnterInvalidTrackId()
        {
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.Id("ola_orderNumber")));
            _driver.FindElement(By.Id("ola_orderNumber")).SendKeys("VKHItsdretdwtr6");
            log.Info("Track Id Accepted.");
        }

        public void ClickOnFindOrder()
        {
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.Id("ola_submitButton")));
            _driver.FindElement(By.Id("ola_submitButton")).Click();
            log.Info("Track Button Working.");
        }

        public void VerifyErrorMessage()
        {
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.Id("ola_orderHeaderContent")));
            IWebElement ele = _driver.FindElement(By.Id("ola_orderHeaderContent"));
            bool value = ele.Displayed;
            log.Error("Track Error Message Displayed.");
            Assert.AreEqual(true, value);
            ((ITakesScreenshot)_driver).GetScreenshot().SaveAsFile(@"C:\Users\mindtreefeb86\source\repos\BigSmallSiteAutomation\BigSmallSiteAutomation\Feature Objects\TrackScreenshot.png", ScreenshotImageFormat.Png);
            log.Info("Screenshot Taken of the page.");
        }
    }
}
