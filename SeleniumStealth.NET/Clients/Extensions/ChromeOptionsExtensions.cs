using OpenQA.Selenium.Chrome;
using SeleniumStealth.NET.Clients.Models;

namespace SeleniumStealth.NET.Clients.Extensions
{
    public static class ChromeOptionsExtensions
    {
        public static ChromeOptions ApplyStealth(
            this ChromeOptions chromeOptions,
            bool headless = false, ApplyStealthSettings? settings = null)
        {
            settings ??= new ApplyStealthSettings();

            if (headless)
                chromeOptions.AddArgument("--headless");
            if (settings.DisableAutomationControlled)
                chromeOptions.AddArgument("--disable-blink-features=AutomationControlled");
            if (settings.NoSandBox)
                chromeOptions.AddArgument("--no-sandbox");
            if (settings.DisableInfoBars)
                chromeOptions.AddArgument("--disable-infobars");
            if (settings.DisableDevShmUsage)
                chromeOptions.AddArgument("--disable-dev-shm-usage");
            if (settings.DisableGpu)
                chromeOptions.AddArgument("--disable-gpu");
            if (settings.DisableExtensions)
                chromeOptions.AddArgument("--disable-extensions");
            if (settings.DisableWebSecurity)
                chromeOptions.AddArgument("--disable-web-security");
            if (settings.DisableBrowserSideNavigation)
                chromeOptions.AddArgument("--disable-browser-side-navigation");
            if (settings.DisableVizDisplayCompositor)
                chromeOptions.AddArgument("--disable-features=VizDisplayCompositor");
            if (settings.DisableRendererBackgrounding)
                chromeOptions.AddArgument("--disable-renderer-backgrounding");

            return chromeOptions;
        }
    }
}
