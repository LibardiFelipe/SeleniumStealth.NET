using System;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumStealth.NET.Clients.Extensions
{
    public static class WebDriverExtensions
    {
        private static readonly Random _rnd = new();
        private static readonly By _interactableElements = By.CssSelector("input button a");

        public static void SpecialWait(
            this IWebDriver driver, int intervalInMilliseconds)
        {
            if (intervalInMilliseconds > 0)
            {
                var elements = driver.FindElements(_interactableElements);

                if (elements.Any() is false)
                {
                    var interval = intervalInMilliseconds / 5;
                    for (int i = 0; i < 5; i++)
                    {
                        ((IJavaScriptExecutor)driver).ExecuteScript("simulateRandomMouseMove(arguments[0])", interval);
                        Task.Delay(interval).Wait();
                    }

                    return;
                }

                var intervalPerIteration = intervalInMilliseconds / elements.Count;
                foreach (var element in elements)
                {
                    ((IJavaScriptExecutor)driver).ExecuteScript(
                        "moveMouseCursorToElement(arguments[0], arguments[1])", element, intervalPerIteration);
                    Task.Delay(intervalPerIteration).Wait();
                }
            }
        }

        public static void SpecialWait(
            this IWebDriver driver, int minIntervalInMilliseconds, int maxIntervalInMilliseconds)
        {
            var intervalInMilliseconds = _rnd.Next(minIntervalInMilliseconds, maxIntervalInMilliseconds);

            if (intervalInMilliseconds > 0)
            {
                var elements = driver.FindElements(_interactableElements);

                if (elements.Any() is false)
                {
                    var interval = intervalInMilliseconds / 5;
                    for (int i = 0; i < 5; i++)
                    {
                        ((IJavaScriptExecutor)driver).ExecuteScript("simulateRandomMouseMove(arguments[0])", interval);
                        Task.Delay(interval).Wait();
                    }

                    return;
                }

                var intervalPerIteration = intervalInMilliseconds / elements.Count;
                foreach (var element in elements)
                {
                    ((IJavaScriptExecutor)driver).ExecuteScript(
                        "moveMouseCursorToElement(arguments[0], arguments[1])", element, intervalPerIteration);
                    Task.Delay(intervalPerIteration).Wait();
                }
            }
        }
    }
}
