using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
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
    class SearchItemObjects
    {
        WebDriverWait wait = new WebDriverWait(Hooks.driver, TimeSpan.FromSeconds(20));
        IWebDriver _driver = Hooks.driver;
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public void SearchItem()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("q")));
            _driver.FindElement(By.Name("q")).SendKeys("iron throne");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("q")).Submit();
            log.Info("keyword added to search tab.");
        }

        public void SelectItem()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[.='Iron Throne']")));
            _driver.FindElement(By.XPath("//span[.='Iron Throne']")).Click();
            log.Info("Searched item displayed");
        }

        public void VerifyItem()
        {
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//a[.='Iron Throne']")));
            IWebElement ele = _driver.FindElement(By.XPath("//a[.='Iron Throne']"));
            bool value = ele.Displayed;
            Assert.AreEqual(true, value);
            log.Info("Item Added to cart.");
            ((ITakesScreenshot)_driver).GetScreenshot().SaveAsFile(@"C:\Users\mindtreefeb86\source\repos\BigSmallSiteAutomation\BigSmallSiteAutomation\Feature Objects\SearchScreenshot.png", ScreenshotImageFormat.Png);
            log.Warn("Screenshot taken.");
        }
    }
}
