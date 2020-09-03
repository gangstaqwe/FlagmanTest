using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace FlagmanShop_Test.PageObjects
{
    public class PageLure
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
            webdriver.FindElement(_ContinueShoping).Click();          
        }
    }
}
