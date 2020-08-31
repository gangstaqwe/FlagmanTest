using FlagmanShop_Test.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace FlagmanShop_Test
{
    [TestFixture]
    public class Tests:BaseClass
    {
        private readonly By _NumberOfGoodsInBasket = By.XPath("//a[@class='icon header-cart full-cart']/span");

        [Test]
        public void CheckTabsInTopSite()
        {
            var homePage = new HomePage(webdriver);
            Assert.That(homePage.AllTheTopTab, Has.Member("�����")); // �������� ������ � ������ ��������� (��� �� �� ��������) ������� Empty           
        }
    
        [Test]
        public void CheckBottomBoxInformation()
        {

            var homePage = new HomePage(webdriver);
            TypeOfWait.WaitInterval(2);
            Assert.That(homePage.TabsInformationBottom, Has.Member("�����")); // �������� ��� ����� "�����" ������������
            
        }
        [Test]
        public void CheckSocialNetworkFacebook()
        {
            var homePage = new HomePage(webdriver);
            homePage
                .CheckClickableAndVisibleSocialNetworkFacebook();           
            //Assert.IsTrue
        }

        [Test]
        public void CheckSocialNetworkInstagram()
        {
            var homePage = new HomePage(webdriver);
            homePage
                .CheckClickableAndVisibleSocialNetworkInstagram();
            //Assert.IsTrue
        }

        [Test]
        public void CheckSocialNetworkTelegram()
        {
            var homePage = new HomePage(webdriver);
            homePage
                .CheckClickableAndVisibleSocialNetworkTelegram();
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

            Assert.IsTrue(webdriver.FindElement(By.Id("register_button")).Enabled); // ��� ����� ��� ������ ����� ������� 

        }

        [Test]
        public void CheckEnterInAccount()
        {
            var homePage = new HomePage(webdriver);
            homePage
                .EntryInAccount();
            Assert.IsTrue(webdriver.FindElement(By.XPath("//a [@name='profile']")).Displayed);          
            // �������� ��� ������� ������������
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
        }

         [Test]
         public void CheckFieldSearch()
         {          
            String e = "������Ȼ";
            var homePage = new HomePage(webdriver);
            homePage
                .FieldSearch();
            Assert.AreEqual("������Ȼ", webdriver.FindElement(By.XPath("//span[text()='�������']")).Text); // �������� �� �� �� ��� ����� �������������
        }

         [Test]
         public void CheckFieldSearchIfNoResult()
         {
            var homePage = new HomePage(webdriver);
            homePage
                .FieldSearchIsEmpty();
            Assert.AreEqual("������ �� �������", webdriver.FindElement(By.XPath("//p[text()='������ �� �������']")).Text);

         }
        [Test]
        public void CheckFunctionAddGoodsAndVisibleNumber()
        {
            var homePage = new HomePage(webdriver);
            var catalogLure = new CatalogLure(webdriver);
            var pageLure = new PageLure(webdriver);
            homePage
                .ClickToCatalogAndLure();
            Assert.IsTrue(webdriver.FindElement(By.XPath("//img [@src='https://i.flagman.kiev.ua/goods/1280/1280741.png']")).Displayed);// �� ������� ���
            catalogLure
                .PageCatalogLure();           
            pageLure
                .PageWithDifferentProductLure(); // ��� ������� ������� ���������
            // add Assert
           
        }
        [Test]
        public void CheckThenGoodsNotDeleteAfterQuitAcc()
        {
            var homePage = new HomePage(webdriver);
            var page_Fish_Rod = new Page_Fish_Rod(webdriver);
            homePage
                .EntryInAccClickBySpinning();
            // add Assert
            page_Fish_Rod
                .AddGoodsInBasket();
            Assert.AreEqual("1", webdriver.FindElement(_NumberOfGoodsInBasket).Text);
        }
        

    }
}