using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumStealth.NET.Clients;
using SeleniumStealth.NET.Clients.Extensions;
using SeleniumStealth.NET.Clients.Models;
using SeleniumStealth.NET.Tests.Unit.Resources;
using Xunit;

namespace SeleniumStealth.NET.Tests.Unit.Services
{
    public class StealthService
    {
        [Fact]
        public void ShouldPassIfDocumentHasNoCdcVariables()
        {
            // given
            var options = new ChromeOptions()
                .ApplyStealth(headless: true);

            using var cd = Stealth.Instantiate(options, new StealthInstanceSettings
            {
                RemoveCDCVariables = true
            });

            cd.Navigate().GoToUrl("about:blank");

            // when
            var cdcPresence = Convert.ToBoolean(((IJavaScriptExecutor)cd).ExecuteScript(JsFunctions.CheckCdcVarsPresence));

            // then
            Assert.False(cdcPresence);
        }

        [Fact]
        public void ShouldPassIfDisableAutomationControlledIsHidingWebDriver()
        {
            // given
            var options = new ChromeOptions()
                .ApplyStealth(headless: true,
                    settings: new ApplyStealthSettings
                    {
                        DisableAutomationControlled = true
                    });

            using var cd = Stealth.Instantiate(options, new StealthInstanceSettings
            {
                HideWebDriver = false
            });

            cd.Navigate().GoToUrl("about:blank");

            // when
            var webdriverEnabled = Convert.ToBoolean(((IJavaScriptExecutor)cd).ExecuteScript("return navigator.webdriver;"));

            // then
            Assert.False(webdriverEnabled);
        }

        [Fact]
        public void ShouldPassIfHideWebDriverIsHidingWebDriver()
        {
            // given
            var options = new ChromeOptions()
                .ApplyStealth(headless: true,
                    settings: new ApplyStealthSettings
                    {
                        DisableAutomationControlled = false
                    });

            using var cd = Stealth.Instantiate(options, new StealthInstanceSettings
            {
                HideWebDriver = true
            });

            cd.Navigate().GoToUrl("about:blank");

            // when
            var webdriverEnabled = Convert.ToBoolean(((IJavaScriptExecutor)cd).ExecuteScript("return navigator.webdriver;"));

            // then
            Assert.False(webdriverEnabled);
        }

        [Fact]
        public void ShouldPassIfRandomUserAgentIsChangingUserAgentEveryInstance()
        {
            // given
            var options = new ChromeOptions()
                .ApplyStealth(headless: true);

            using var cd1 = Stealth.Instantiate(options, new StealthInstanceSettings
            {
                RandomUserAgent = true
            });

            using var cd2 = Stealth.Instantiate(options, new StealthInstanceSettings
            {
                RandomUserAgent = true
            });

            cd1.Navigate().GoToUrl("about:blank");
            cd2.Navigate().GoToUrl("about:blank");

            // when
            var userAgent1 = ((IJavaScriptExecutor)cd1).ExecuteScript("return navigator.userAgent;").ToString();
            var userAgent2 = ((IJavaScriptExecutor)cd2).ExecuteScript("return navigator.userAgent;").ToString();
 
            // then
            Assert.NotEqual(userAgent1, userAgent2);
        }
    }
}
