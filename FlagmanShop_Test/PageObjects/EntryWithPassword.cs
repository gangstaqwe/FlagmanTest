using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlagmanShop_Test.PageObjects
{
    class EntryWithPassword
    {

        private readonly By _FieldPhone = By.XPath("//input [@id='u_phone']");
        private readonly By _FieldPassword = By.XPath("//input [@id='u_pass']");
        private readonly By _ButtonEntry = By.XPath("//button [@class='tell-me_link btn corner-border blue-border']");
        private IWebDriver webdriver;

        public EntryWithPassword(IWebDriver webdriver)
        {
            this.webdriver = webdriver;
        }


        public HomePage PageEntryWithPass()
        {
            webdriver.FindElement(_FieldPhone).SendKeys(TestSettings.PhoneToEntryWithAccount);
            webdriver.FindElement(_FieldPassword).SendKeys(TestSettings.PasswordToEntryWithAccount);
            webdriver.FindElement(_ButtonEntry).Click();
            return new HomePage(webdriver);
        }
    }
}
