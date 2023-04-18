using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumStealth.NET.Clients;
using SeleniumStealth.NET.Clients.Extensions;
using Xunit;

namespace SeleniumStealth.NET.Tests.Integration.Extensions
{
    public class WebDriver
    {
        [Fact]
        public void ShouldPassIfElementIdIsBeingDisplayedWhenSimulatingMouseMovementOverIt()
        {
            // given
            var options = new ChromeOptions()
                .ApplyStealth(headless: true);

            using var cd = Stealth.Instantiate(options);
            cd.Navigate().GoToUrl(Path.Combine(AppContext.BaseDirectory,
                "Resources/mouse_movement_test.html"));

            // when
            cd.SpecialWait(1000, 3000);

            // then
            var outputText = cd.FindElement(By.Id("mouseMovementStatus"))
                .GetAttribute("value");

            Assert.Contains("detected", outputText);
        }
    }
}
