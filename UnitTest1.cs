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
            Assert.That(homePage.AllTheTopTab, Has.Member("�����")); // �������� ������ � ������ ��������� (��� �� �� ��������) ������� Empty           
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
            Assert.That(homePage.TabsInformationBottom, Has.Member("�����")); // �������� ��� ����� "�����" ������������
            
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

            Assert.IsTrue(webdriver.FindElement(By.Id("register_button")).Enabled); // ��� ����� ��� ������ ����� ������� 

        }

        [Test]
        public void CheckEnterInAccount()
        {
            var homePage = new HomePage(webdriver);
            homePage
                .EntryInAccount();
            Assert.IsTrue(webdriver.FindElement(By.XPath("//a [@name='profile']")).Displayed);
            Assert.IsTrue(webdriver.FindElement(By.CssSelector("li a[class='xhr']")).Displayed);
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
            Assert.IsTrue(webdriver.FindElement(By.CssSelector("li a[class='xhr']")).Displayed);

        }
         [Test]
         public void CheckFieldSearch()
         {          
            String e = "������Ȼ";
            var homePage = new HomePage(webdriver);
            homePage
                .FieldSearch();
            Assert.AreEqual("������Ȼ", webdriver.FindElement(By.XPath("//span[text()='�������']")).Text); // �������� �� �� �� ��� ����� �������������
            Assert.IsTrue(webdriver.FindElement(By.XPath("//div[@class='row search-results-sort']")).Displayed); // ���� ������ ������������
            //Assert.IsTrue(webdriver.FindElement(By.XPath("//span[text()='�������']")).Text.Contains(e));
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
                .ClickToCatalogAndLure(); // �� ������� ���
            catalogLure
                .PageCatalogLure(); // ������� �� ��� ���������
            pageLure
                .PageWithDifferentProductLure(); // ��� ������� ������� ���������
                
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