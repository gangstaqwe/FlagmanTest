using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;

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
        private readonly By _IconFacebook = By.XPath("//a [@title='Facebook']");
        private readonly By _IconInstagram = By.XPath("//a [@title='Instargam']");
        private readonly By _IconTelegram = By.XPath("//a [@title='Telegram']");      
        private readonly By _ButtonRegistration = By.XPath("//a [@href='#registration']");
        private readonly By _FieldName = By.XPath("//input [@class='register_name']");
        private readonly By _FieldPhone = By.ClassName("phone-mask");
        private readonly By _FieldEmail = By.XPath("//input [@id='u_email']");
        private readonly By _FieldPassword = By.XPath("//input [@id='password']");
        private readonly By _ClcikByFieldEnable = By.CssSelector(".u_RegisterProcessing-label");
        private readonly By _EnterWithPassword = By.CssSelector("li a[name='signin']");
        private readonly By _FieldSearch = By.XPath("//input [@id='search-text']");
        private readonly By _ButtonSearch = By.XPath("//button[@class='search']");
        private readonly By _ButtonCatalog = By.XPath("//ul[@class='main-menu']/li[1]/a");
        private readonly By _ButtonLure = By.XPath("//ul/li[2]/a[2]"); // плохой xpath, можно было ссылку вписать
        private readonly By _ButtonSpinningsInTopMenu = By.XPath("//ul[@class='main-menu']/li[2]");
        private readonly By _ButtonSpinningRod = By.XPath("//div[text()='Спиннинговые удилища']");
        

        public HomePage(IWebDriver webdriver)
        {
            this.webdriver = webdriver;
        }
        
       
        public List<string> AllTheTopTab =>
            webdriver.FindElements(_AllTabInTop).Select(x => x.Text).ToList(); //получаем список из 8 вкладок (верх)

        public List<string> TabsInformationBottom =>
            webdriver.FindElements(_BottomBoxInformation).Select(x => x.Text).ToList(); //получаем список из 8 вкладок (боттом)


        public void CheckClickableAndVisibleSocialNetworkFacebook()
        {
            var m_driver = webdriver.WindowHandles;
            webdriver.FindElement(_IconFacebook).Click();
            webdriver.SwitchTo().Window(m_driver.First()); // перехожу между page
            string actualhrefFace = webdriver.FindElement(_IconFacebook).GetAttribute("href"); // получаю юрл из фейсбук
            Assert.AreEqual(actualhrefFace, TestSettings.FacebookUrl);
        }// проверяю что мой текущ юрл соответст юрл в тестсетингс

        public void CheckClickableAndVisibleSocialNetworkInstagram()
        {
                var m_driver = webdriver.WindowHandles;
                webdriver.FindElement(_IconInstagram).Click();
                webdriver.SwitchTo().Window(m_driver.First()); // переход на пред страницу
                string actualhrefInst = webdriver.FindElement(_IconInstagram).GetAttribute("href");
                Assert.AreEqual(actualhrefInst, TestSettings.InstaUlr);
        }

        public void CheckClickableAndVisibleSocialNetworkTelegram()
        {
            var m_driver = webdriver.WindowHandles;
            webdriver.FindElement(_IconTelegram).Click();
            webdriver.SwitchTo().Window(m_driver.First()); // на пред страницу
            string actualhrefTel = webdriver.FindElement(_IconTelegram).GetAttribute("href");
            Assert.AreEqual(actualhrefTel, TestSettings.TelegaramUrl);
        }

        /*public void ChooseLanguage()
        {
            
            webdriver.FindElement(_ButtonLanguage).Click();
            //webdriver.SwitchTo().Frame(2);
            Actions action = new Actions(webdriver);
            
            Thread.Sleep(4000);
            //action.Click();
            webdriver.FindElement(_UkraineLanguage).Click();
            

        }
        */

       
        public void EnterDataInRegistrationForm(string name, string phone, string email, string password)
        {

            webdriver.FindElement(_ButtonRegistration).Click();
            webdriver.FindElement(_FieldName).SendKeys(name);
            webdriver.FindElement(_FieldPhone).SendKeys(phone);
            webdriver.FindElement(_FieldEmail).SendKeys(email);
            webdriver.FindElement(_FieldPassword).SendKeys(password);
            webdriver.FindElement(_ClcikByFieldEnable).Click();
            // заполнил поля, нажал галочку в чек-боксе
        }
        
       public void EntryInAccount()
        {
            webdriver.FindElement(_EnterWithPassword).Click();
            webdriver.FindElement(By.XPath("//input[@class='custom-field-error input-field phone-number']")).SendKeys("380508375753"); // можно сделать отдельные классы
            webdriver.FindElement(By.XPath("//input[@class='custom-field-error input-field password']")).SendKeys("Тщлызкун228"); 
            webdriver.FindElement(By.CssSelector("div button[class='btn btn-big']")).Click();
            TypeOfWait.WaitInterval(1);
        }
        public EntryWithPassword GoToRegistrationAndEntryWithPass()
        {
            webdriver.FindElement(_ButtonRegistration).Click();
            webdriver.FindElement(By.CssSelector(".popup-content .xhr")).Click();
            return new EntryWithPassword(webdriver);
            
        }

        public void FieldSearch()
        {
            webdriver.FindElement(_FieldSearch).SendKeys("крючки"); // можно сдеалть отдельний класс для выбора конкретного слова поиска (пока так)
            webdriver.FindElement(_ButtonSearch).Click();          
        }

        public void FieldSearchIsEmpty()
        {
            webdriver.FindElement(_FieldSearch).SendKeys("крячкы"); 
            webdriver.FindElement(_ButtonSearch).Click();
        }
         public CatalogLure ClickToCatalogAndLure()
        {
            webdriver.FindElement(_ButtonCatalog).Click();
            webdriver.FindElement(_ButtonLure).Click();
            return new CatalogLure(webdriver);

        }

        public Page_Fish_Rod EntryInAccClickBySpinning()
        {
            EntryInAccount();
            webdriver.FindElement(_ButtonSpinningsInTopMenu).Click();
            webdriver.FindElement(_ButtonSpinningRod).Click();
            return new Page_Fish_Rod(webdriver);

        }
    }
}
