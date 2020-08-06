using FlagmanShop_Test.PageObjects;
using NUnit.Framework;
using System;

namespace FlagmanShop_Test
{
    [TestFixture]
    public class Tests:BaseClass
    {            
        [Test]
        public void HomePageTabDisplayed()
        {
            var homePage = new HomePage(webdriver);
            homePage
                .CheckTopAndBotDispalyed();
        }

        [Test]
        public void CheckTabsInTopSite()
        {
            var homePage = new HomePage(webdriver);
            Assert.That(homePage.AllTheTopTab, Has.No.Member(HomePage.BuyTab)); // проверка текста в списке елементов            
        }
        [Test]
        public void CheckDisplayedHomeTabs()
        {
            var homePage = new HomePage(webdriver);
            homePage
                .CheckDisplayedTabHitsSale();
        }

        [Test]
        public void CheckBottomBoxInformation()
        {

            var homePage = new HomePage(webdriver);
            TypeOfWait.WaitInterval(2);
            Assert.That(homePage.TabsInformationBottom, Has.Member(HomePage.BuyTab)); // проверка что текст "Акции" присутствует
            
        }
    }
}