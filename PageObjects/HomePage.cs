using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlagmanShop_Test.PageObjects
{    
    class HomePage
    {

        private IWebDriver webdriver;


        private readonly By _MenuHitsSale = By.XPath("//div[@class='rr-widget rr-widget-5e32d98f97a5251368b4f479-popular rr-active']");
        private readonly By _FooterDisplayed = By.XPath("//section[@class='subscribe-section clearfix ']");
        private readonly By _SearchField = By.XPath("//button[@class='search']");
        private readonly By _AllTabInTop = By.CssSelector("header-top_menu clearfix");
        private readonly By _HitsSaleText = By.XPath("//div [text()='     Хиты продаж   ']");
        private readonly By _HitsOfSaleWithDiscount = By.XPath("//div [text()='     Хиты продаж со скидками   ']");
        private readonly By _TabNew = By.XPath("//h3 [text()='Новинки']");
        private readonly By _BottomBoxInformation = By.XPath("//div [@class='col-sm-3 hidden-xs']");


        public static string BuyTab = "Акции";

        public HomePage(IWebDriver webdriver)
        {
            this.webdriver = webdriver;
        }

        public void CheckTopAndBotDispalyed()
        {
            String html_registration = "Войти с паролем";
            Assert.IsTrue(webdriver.PageSource.Contains(html_registration)); // содержит html элемент


            Assert.IsTrue(webdriver.FindElement(_MenuHitsSale).Displayed); // проверка что меню "Подпис на новости " отображается
             
            Assert.IsTrue(webdriver.FindElement(_FooterDisplayed).Displayed); // проверка на то что футер дисплайед

            Assert.IsTrue(webdriver.FindElement((_SearchField)).Enabled); // проверка на то что кнопка Поиска активна
        }

        public List<string> AllTheTopTab =>
            webdriver.FindElements(_AllTabInTop).Select(x => x.Text).ToList(); //получаем список из 8 вкладок (верх)

        public void CheckDisplayedTabHitsSale()
        {
            string TextFollowByNews = "Подписаться на новости ";
            TypeOfWait.WaitInterval(3);

            Assert.IsTrue(webdriver.FindElement(_HitsSaleText).Displayed); // проверяю что есть елемент Хиты продаж

            Assert.IsTrue(webdriver.FindElement(_HitsOfSaleWithDiscount).Displayed); // Хиты продаж со скидками чек

            Assert.IsTrue(webdriver.FindElement(_TabNew).Displayed); // новости 

            Assert.IsTrue(webdriver.PageSource.Contains(TextFollowByNews)); // проверка на оо что страница содержит этот текст
        }

        public List<string> TabsInformationBottom =>
            webdriver.FindElements(_BottomBoxInformation).Select(x => x.Text).ToList(); //получаем список из 8 вкладок (боттом сайта)
    }
}
