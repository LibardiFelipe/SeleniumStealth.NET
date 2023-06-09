# SeleniumStealth .NET

This is the .NET version of the **SeleniumStealth** python library with a few personal tweaks.
It basically injects some javascript code before the page loads up, hiding **almost every trace** of automation that could be found.


# How to use

````
using OpenQA.Selenium.Chrome;
using SeleniumStealth.NET.Clients;
using SeleniumStealth.NET.Clients.Enums;
using SeleniumStealth.NET.Clients.Extensions;
using SeleniumStealth.NET.Clients.Models;

static void Main(string[] args)
{
        var chromeOptions = new ChromeOptions()
                .ApplyStealth();

        var chromeDriver = Stealth.Instantiate(chromeOptions);

        chromeDriver.Navigate().GoToUrl("https://bot.sannysoft.com/");
        chromeDriver.Quit();


        /* You can also choose which options do you want do enable/disable.
        * (As default, everything is enabled) */
        chromeOptions = new ChromeOptions()
                .ApplyStealth(
                        headless: true,
                        settings: new ApplyStealthSettings
                        {
                                DisableAutomationControlled = true,
                                DisableBrowserSideNavigation = true,
                                DisableDevShmUsage = true,
                                DisableExtensions = true,
                                DisableGpu = true,
                                DisableInfoBars = true,
                                DisableRendererBackgrounding = true,
                                DisableVizDisplayCompositor = true,
                                DisableWebSecurity = true,
                                NoSandBox = true
                        });

        chromeDriver = Stealth.Instantiate(chromeOptions, new StealthInstanceSettings
                {
                        ChromeDriverPath = "custom chromedriver path",
                        FakeCanPlayType = true,
                        FakeChromeApp = true,
                        FakeChromeRuntime = new ChromeRuntime
                        {
                                FakeIt = true,
                                RunOnInsercureOrigins = true
                        },
                        FakeLoadingTimes = true,
                        FakePluginsAndMimeTypes = true,
                        FakeWindowOuterDimensions = true,
                        FixHairline = true,
                        HideWebDriver = true,
                        IFrameProxy = true,
                        Mode = EStealthMode.SeleniumStealth, // EStealthMode.UndetectedChromeDriver,
                        RandomUserAgent = true,
                        RemoveCDCVariables = true
                });

        /* Plus:
        /* It simulate mouse cursor movement on the body of the document
        * while waiting. Useful to bypass hCaptcha cursor movement tracking. */
        chromeDriver.SpecialWait(3000);
}
````

