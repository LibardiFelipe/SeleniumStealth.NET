# SeleniumStealth .NET

This is the C# version of the **SeleniumStealth** python library with a few personal tweaks.
It basicly injects some javascript code before the page loads up, hiding **almost every trace** of automation that could be found.


# How to use

````
using SeleniumStealth.NET.Clients;
using SeleniumStealth.NET.Clients.Extensions;

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
                Mode = EStealthMode.SeleniumStealth,// EStealthMode.UndetectedChromeDriver,
                RandomUserAgent = true,
                RemoveCDCVariables = true
            });
        }
````

