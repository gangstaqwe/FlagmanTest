using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlagmanShop_Test.PageObjects
{
    public class Page_Fish_Rod
    {
        private IWebDriver webdriver;
        private readonly By _BuutonAddGoodInBasket = By.XPath("//*[@id='goods-parent']/div/div[9]/div/article/div[3]/ul/li[3]/a");
        private readonly By _ContinueShoping = By.Id("continue-shopping");
        private readonly By _ButtonExit = By.XPath("//ul [@class='header-enter icon']/li[2]/a");
        private readonly By _NumberOfGoodsInBasket = By.XPath("//a[@class='icon header-cart full-cart']/span");
        public Page_Fish_Rod(IWebDriver webdriver)
        {
            this.webdriver = webdriver;
        }

        public void AddGoodsInBasket()
        {
            ((IJavaScriptExecutor)webdriver).ExecuteScript("scroll(0,600)");
            webdriver.FindElement(_BuutonAddGoodInBasket).Click();
            webdriver.FindElement(_ContinueShoping).Click();            
            webdriver.FindElement(_ButtonExit).Click();
            TypeOfWait.WaitInterval(1);
            Assert.AreEqual("1", webdriver.FindElement(_NumberOfGoodsInBasket).Text);

        }
    }
}
