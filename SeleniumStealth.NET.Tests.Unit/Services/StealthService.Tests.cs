using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumStealth.NET.Clients;
using SeleniumStealth.NET.Clients.Extensions;
using SeleniumStealth.NET.Models;
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
    }
}
