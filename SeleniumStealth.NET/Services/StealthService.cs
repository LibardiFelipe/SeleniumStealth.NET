using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium.Chrome;
using SeleniumStealth.NET.Clients.Enums;
using SeleniumStealth.NET.Clients.Models;
using SeleniumStealth.NET.Models;
using SeleniumStealth.NET.Resources;

namespace SeleniumStealth.NET.Services
{
    internal static class StealthService
    {
        public static ChromeDriver ApplyStealth(
            ChromeOptions? chromeOptions,
            StealthInstanceSettings? instanceSettings)
        {
            instanceSettings ??= new StealthInstanceSettings();
            chromeOptions ??= new ChromeOptions();

            var driver = string.IsNullOrWhiteSpace(instanceSettings?.ChromeDriverPath)
                ? new ChromeDriver(chromeOptions)
                : new ChromeDriver(instanceSettings.ChromeDriverPath, chromeOptions);

            switch (instanceSettings!.Mode)
            {
                case EStealthMode.SeleniumStealth:
                    {
                        /* Required */
                        EvaluateOnNewDocument(driver, JsFunctions.SeleniumStealth_RequiredUtilityPack);

                        if (instanceSettings.FakeChromeApp)
                            EvaluateOnNewDocument(driver, JsFunctions.SeleniumStealth_FakeChromeApp);

                        if (instanceSettings.FakeChromeRuntime.FakeIt)
                            EvaluateOnNewDocument(driver,
                                JsFunctions.SeleniumStealth_FakeChromeRuntime,
                                instanceSettings.FakeChromeRuntime.RunOnInsercureOrigins);

                        if (instanceSettings.IFrameProxy)
                            EvaluateOnNewDocument(driver, JsFunctions.SeleniumStealth_iFrameProxy);

                        if (instanceSettings.FakeCanPlayType)
                            EvaluateOnNewDocument(driver, JsFunctions.SeleniumStealth_FakeCanPlayType);

                        if (instanceSettings.FakePluginsAndMimeTypes)
                            EvaluateOnNewDocument(driver, JsFunctions.SeleniumStealth_FakePluginsAndMimes);

                        if (instanceSettings.FakeWindowOuterDimensions)
                            EvaluateOnNewDocument(driver, JsFunctions.SeleniumStealth_FakeWindowOuterDimensions);

                        if (instanceSettings.HideWebDriver)
                            EvaluateOnNewDocument(driver, JsFunctions.SeleniumStealth_HideWebDriver);
                        break;
                    }
                default:
                    {
                        EvaluateOnNewDocument(driver, JsFunctions.UndetectedChromeDriver);
                        break;
                    }
            }

            /* Required */
            EvaluateOnNewDocument(driver, JsFunctions.FakeMouseMovement);

            if (instanceSettings.RandomUserAgent)
            {
                var navInfo = new NavigatorInfo();
                driver.ExecuteCdpCommand("Network.setUserAgentOverride", new Dictionary<string, object> { { "userAgent", navInfo.UserAgent } });
                EvaluateOnNewDocument(driver, JsFunctions.NavigatorVendor, navInfo.Vendor);
            }

            if (instanceSettings.RemoveCDCVariables)
                EvaluateOnNewDocument(driver, JsFunctions.RemoveCdcVariables);

            if (instanceSettings.FixHairline)
                EvaluateOnNewDocument(driver, JsFunctions.FixHairline);

            if (instanceSettings.FakeLoadingTimes)
                EvaluateOnNewDocument(driver, JsFunctions.FakeLoadingTimes);

            return driver;
        }

        private static void EvaluateOnNewDocument(ChromeDriver driver, string jsFunction, params object[] @params)
        {
            var jsCode = EvaluateString(jsFunction, @params);
            driver.ExecuteCdpCommand("Page.addScriptToEvaluateOnNewDocument",
                new Dictionary<string, object> { { "source", jsCode } });
        }

        private static string EvaluateString(string jsFunction, params object[] @params)
        {
            var args = string.Join("', '", @params.Select(x => $"{x ?? "undefined"}"))
                .Replace("True", "true").Replace("False", "false");

            return $"({jsFunction})('{args}')";
        }
    }
}
