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
    class WishlistItemObjects
    {
        WebDriverWait wait = new WebDriverWait(Hooks.driver, TimeSpan.FromSeconds(20));
        IWebDriver _driver = Hooks.driver;
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public void ClickOnItem()
        {
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//div[@data-image-count='6']")));
            _driver.FindElement(By.XPath("//div[@data-image-count='6']")).Click();
            log.Info("Clicked on item.");
        }

        public void AddToWishlist()
        {
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//button[@aria-label='Add to Wishlist']")));
            _driver.FindElement(By.XPath("//button[@aria-label='Add to Wishlist']")).Click();
            log.Info("Item added to wishlist.");
        }

        public void GoToWishlist()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[.='wish list']")));
            _driver.FindElement(By.XPath("//span[.='wish list']")).Click();
            log.Info("Navigated to the wishlist page");
        }

        public void VerifyWishlist()
        {
            try
            {
                Thread.Sleep(1000);
                _driver.FindElement(By.Id("swym-welcome-button")).Click();
                log.Info("Clicked on Popup displayed.");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                log.Warn("Popup not displayed.");
            }
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//a[.='Super Dad Mug']")));
            IWebElement ele = _driver.FindElement(By.XPath("//a[.='Super Dad Mug']"));
            bool value = ele.Displayed;
            Assert.AreEqual(true, value);
            log.Info("Item verified in the wishlist");
            ((ITakesScreenshot)_driver).GetScreenshot().SaveAsFile(@"C:\Users\mindtreefeb86\source\repos\BigSmallSiteAutomation\BigSmallSiteAutomation\Feature Objects\WishlistScreenshot.png", ScreenshotImageFormat.Png);
            log.Warn("Screenshot taken.");

        }
    }
}
