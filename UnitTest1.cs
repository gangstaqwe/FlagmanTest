using FlagmanShop_Test.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
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
            Assert.That(homePage.AllTheTopTab, Has.Member("Акции")); // проверка текста в списке елементов (что то не работает) получаю Empty           
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
            Assert.That(homePage.TabsInformationBottom, Has.Member("Акции")); // проверка что текст "Акции" присутствует
            
        }
        [Test]
        public void CheckSocialNetworkBox()
        {
            var homePage = new HomePage(webdriver);
            homePage
                .CheckClickableAndVisibleSocialNetwork();
            
            //Assert.IsTrue
        }
        /*[Test]
        public void ChechChooselanguage()
        {
            var homePage = new HomePage(webdriver);
            homePage
                .ChooseLanguage();
        }
        */
        [Test]
        public void  EntaerDataFromRegistrationForm()
        {
            var homePage = new HomePage(webdriver);
            homePage
                .EnterDataInRegistrationForm(RandomDataGenerate.RandomName(), RandomDataGenerate.GeneratePhoneNumber(CountryCode.Ukraine,LengthPhoneNumber.Ukraine), 
                RandomDataGenerate.GenerateRandomEmail(EmailAddress.Gmail),RandomDataGenerate.GenerateRandomString(8)); // random data]

            Assert.IsTrue(webdriver.FindElement(By.Id("register_button")).Enabled); // про веряю что кнопка стала активна 

        }

        [Test]
        public void CheckEnterInAccount()
        {
            var homePage = new HomePage(webdriver);
            homePage
                .EntryInAccount();
            Assert.IsTrue(webdriver.FindElement(By.XPath("//a [@name='profile']")).Displayed);
            Assert.IsTrue(webdriver.FindElement(By.CssSelector("li a[class='xhr']")).Displayed);
            // проверка что обьекты отображаются
        }

        [Test]
        public void CheckEntryWithPassword()
        {
            var homePage = new HomePage(webdriver);
            var EntryWithPass = new EntryWithPassword(webdriver);
            homePage
                .GoToRegistrationAndEntryWithPass()
                .PageEntryWithPass();
            Assert.IsTrue(webdriver.FindElement(By.XPath("//a [@name='profile']")).Displayed);
            Assert.IsTrue(webdriver.FindElement(By.CssSelector("li a[class='xhr']")).Displayed);

        }
         [Test]
         public void CheckFieldSearch()
         {          
            String e = "«КРЮЧКИ»";
            var homePage = new HomePage(webdriver);
            homePage
                .FieldSearch();
            Assert.AreEqual("«КРЮЧКИ»", webdriver.FindElement(By.XPath("//span[text()='«крючки»']")).Text); // проверка на на то что текст соотвутствует
            Assert.IsTrue(webdriver.FindElement(By.XPath("//div[@class='row search-results-sort']")).Displayed); // блок должен отображаться
            //Assert.IsTrue(webdriver.FindElement(By.XPath("//span[text()='«крючки»']")).Text.Contains(e));
        }

         [Test]
         public void CheckFieldSearchIfNoResult()
         {
            var homePage = new HomePage(webdriver);
            homePage
                .FieldSearchIsEmpty();
            Assert.AreEqual("Ничего не найдено", webdriver.FindElement(By.XPath("//p[text()='Ничего не найдено']")).Text);

         }
        [Test]
        public void CheckFunctionAddGoodsAndVisibleNumber()
        {
            var homePage = new HomePage(webdriver);
            var catalogLure = new CatalogLure(webdriver);
            var pageLure = new PageLure(webdriver);
            homePage
                .ClickToCatalogAndLure(); // на главной стр
            catalogLure
                .PageCatalogLure(); // переход на стр прикормки
            pageLure
                .PageWithDifferentProductLure(); // стр каталог товаров прикормки
                
        }
        [Test]
        public void CheckThenGoodsNotDeleteAfterQuitAcc()
        {
            var homePage = new HomePage(webdriver);
            var page_Fish_Rod = new Page_Fish_Rod(webdriver);
            homePage
                .EntryInAccClickBySpinning();
        }
        

    }
}