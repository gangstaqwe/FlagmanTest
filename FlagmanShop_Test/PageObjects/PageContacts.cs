using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlagmanShop_Test.PageObjects
{
    public class PageContacts
    {
        private IWebDriver webdriver;

        private readonly By _LinkEmail = By.XPath("//a[text()='e-shop@flagman.kiev.ua']");
        private readonly By _LinkViber = By.XPath("//a[text()='Flagman']");
        private readonly By _LinkTelegram = By.XPath("//a[text()='@flagman_bot']");

        public PageContacts(IWebDriver webdriver)
        {
            this.webdriver = webdriver;
        }
        public void CheckClicableElementEmail()
        {
            TypeOfWait.WaitElement(webdriver, _LinkEmail);
        }
        public void CheckClicableElementViber()
        {
            TypeOfWait.WaitElement(webdriver, _LinkViber);
        }
        public void CheckClicableElementTelegram()
        {
            TypeOfWait.WaitElement(webdriver, _LinkTelegram);
        }
    }
    
}
