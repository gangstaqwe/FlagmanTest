using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading.Tasks;

namespace FlagmanShop_Test
{
    public static class TypeOfWait
    {

        public static void ShouldLocate(IWebDriver webDriver, string location)
        {
            try
            {
                new WebDriverWait(webDriver, TimeSpan.FromSeconds(2)).Until(ExpectedConditions.UrlContains(location));
            }
            catch (WebDriverTimeoutException ex)
            {
                throw new NotFoundException($"Cannot find out this URL location:{location}", ex);
            }
        }

        public static void WaitInterval(int second = 3) // указываем время ожидание
        {
            Task.Delay(TimeSpan.FromSeconds(second)).Wait();
        }

        public static void WaitElement(IWebDriver webDriver, By locator, int second = 2)
        {
            new WebDriverWait(webDriver, TimeSpan.FromSeconds(second)).Until(ExpectedConditions.ElementIsVisible(locator)); // проверка стал ли видим едемент за 2 с
            new WebDriverWait(webDriver, TimeSpan.FromSeconds(second)).Until(ExpectedConditions.ElementToBeClickable(locator));// проверка стал ли кликабелен еемент за 2 с

        }
        
    }
}