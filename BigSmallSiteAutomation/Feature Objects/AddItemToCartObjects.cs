using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BigSmallSiteAutomation.Feature_Objects
{
    class AddItemToCartObjects
    {
        WebDriverWait wait = new WebDriverWait(Hooks.driver, TimeSpan.FromSeconds(20));
        IWebDriver _driver = Hooks.driver;
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void ClickOnTheItem()
        {
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//div[@data-image-count='11']")));
            _driver.FindElement(By.XPath("//div[@data-image-count='11']")).Click();
            log.Info("Item is Clicked.");
        }

        public void ClickOnAddToCart()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@name='add']")));
            _driver.FindElement(By.XPath("//button[@name='add']")).Click();
            log.Info("Cart Button is working.");
        }

        public void VerifyCart()
        {
            Thread.Sleep(2000);
            IWebElement ele = _driver.FindElement(By.XPath("//a[@class='cart__product-name']"));
            bool value = ele.Displayed;
            Assert.AreEqual(true, value);
            log.Info("Item is Added to Cart.");
            ((ITakesScreenshot)_driver).GetScreenshot().SaveAsFile(@"C:\Users\mindtreefeb86\source\repos\BigSmallSiteAutomation\BigSmallSiteAutomation\Feature Objects\CartScreenshot.png", ScreenshotImageFormat.Png);
            log.Info("Screenshot is taken of cart.");
        }

        
    }
}
