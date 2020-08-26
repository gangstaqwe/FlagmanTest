using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace FlagmanShop_Test.PageObjects
{
    class PageLure
    {
        private IWebDriver webdriver;
        private readonly By _AddRodCarpProMethodInBasket = By.XPath("//*[@id='goods-parent']/div[1]/div[3]/div/article/div[2]/ul/li[3]");
        private readonly By _ContinueShoping = By.Id("continue-shopping");
        public PageLure(IWebDriver webdriver)
        {
            this.webdriver = webdriver;
        }

        public void PageWithDifferentProductLure()
        {
            ((IJavaScriptExecutor)webdriver).ExecuteScript("scroll(0,400)");
            webdriver.FindElement(_AddRodCarpProMethodInBasket).Click();
            TypeOfWait.WaitInterval(1);
            Assert.IsTrue(webdriver.FindElement(By.XPath("//div[@class='popup light-popup popup-cart']")).Displayed);
            webdriver.FindElement(_ContinueShoping).Click();
            Assert.AreEqual("1", webdriver.FindElement(By.XPath("//div/a/span[text()='1']")).Text);
            
        }
    }
}
