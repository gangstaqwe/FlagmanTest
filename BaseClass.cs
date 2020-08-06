using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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

      
        [SetUp] // выполнять каждый раз перед запуском теста
        public void DobeforeEach()
        {
            webdriver = new ChromeDriver();
            webdriver.Manage().Cookies.DeleteAllCookies();
            webdriver.Navigate().GoToUrl(TestSettings.HostPrefix);
            TypeOfWait.ShouldLocate(webdriver, "https://www.flagman.kiev.ua/"); // проверка на то что я нахожусь именно на этой странице
            webdriver.Manage().Window.Maximize();

        }

        [TearDown]

        protected void DoAfterEach()
        {
            webdriver.Quit();
        }
    }
}