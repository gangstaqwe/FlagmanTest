using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading;


namespace FlagmanShop_Test
{
    public class BaseClass
    {
        protected IWebDriver webdriver;


        public void DoBeforeAllTheTests() // чекни едже
        {
            webdriver = new EdgeDriver();
            webdriver.Manage().Cookies.DeleteAllCookies();
            webdriver.Navigate().GoToUrl(TestSettings.HostPrefix);
            webdriver.Manage().Window.Maximize();
            TypeOfWait.ShouldLocate(webdriver, "https://www.flagman.kiev.ua/");
        }


        [SetUp] // выполнять каждый раз перед запуском теста
        public void DobeforeEach()
        {
           
            // chrome settings
            webdriver = new ChromeDriver();
            webdriver.Manage().Cookies.DeleteAllCookies();
            webdriver.Navigate().GoToUrl(TestSettings.HostPrefix);
            webdriver.Manage().Window.Maximize();
            TypeOfWait.ShouldLocate(webdriver, "https://www.flagman.kiev.ua/"); // проверка на то что я нахожусь именно на этой странице
        }

        [TearDown]

        protected void DoAfterEach()
        {
            webdriver.Quit();
        }

        
    }
}