using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;

namespace FlagmanShop_Test.PageObjects
{
    class CatalogLure
    {
        private IWebDriver webdriver;
        private readonly By _ButtonLureInCatalog = By.XPath("//a [text()='Прикормка']");

        public CatalogLure(IWebDriver webdriver)
        {
            this.webdriver = webdriver;
        }
        public PageLure PageCatalogLure()
        {
            webdriver.FindElement(_ButtonLureInCatalog).Click();
            return new PageLure(webdriver);
        }
    }
}
