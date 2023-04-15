using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SeleniumStealth.NET.Extensions
{
    public static class WebDriverExtensions
    {
        public static async Task<IWebDriver> WaitAndMoveMouseRandomly(
            this IWebDriver driver, int intervalInMilliseconds)
        {
            if (intervalInMilliseconds > 0)
            {
                var actions = new Actions(driver);
                var elements = driver.FindElements(By.CssSelector("input, button, a"));
                if (elements.Any() is false)
                {
                    await Task.Delay(TimeSpan.FromMilliseconds(intervalInMilliseconds));
                    return driver;
                }

                var loopInterval = intervalInMilliseconds / elements.Count;
                foreach (var element in elements)
                {
                    actions.MoveToElement(element).Perform();
                    await Task.Delay(TimeSpan.FromMilliseconds(loopInterval));
                }
            }

            return driver;
        }
    }
}
