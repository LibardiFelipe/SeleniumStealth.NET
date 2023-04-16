using OpenQA.Selenium.Chrome;
using SeleniumStealth.NET.Models;

namespace SeleniumStealth.NET.Clients.Extensions
{
    public static class ChromeOptionsExtensions
    {
        public static ChromeOptions ApplyStealth(
            this ChromeOptions chromeOptions,
            ApplyStealthSettings? settings = null)
        {
            settings ??= new ApplyStealthSettings();

            if (settings.Headless)
                chromeOptions.AddArgument("--headless");
            if (settings.AutomationControlled)
                chromeOptions.AddArgument("--disable-blink-features=AutomationControlled");
            if (settings.SandBox)
                chromeOptions.AddArgument("--no-sandbox");
            if (settings.InfoBars)
                chromeOptions.AddArgument("--disable-infobars");
            if (settings.DevShmUsage)
                chromeOptions.AddArgument("--disable-dev-shm-usage");
            if (settings.Gpu)
                chromeOptions.AddArgument("--disable-gpu");
            if (settings.Extensions)
                chromeOptions.AddArgument("--disable-extensions");
            if (settings.WebSecurity)
                chromeOptions.AddArgument("--disable-web-security");
            if (settings.BrowserSideNavigation)
                chromeOptions.AddArgument("--disable-browser-side-navigation");
            if (settings.VizDisplayCompositor)
                chromeOptions.AddArgument("--disable-features=VizDisplayCompositor");
            if (settings.RendererBackgrounding)
                chromeOptions.AddArgument("--disable-renderer-backgrounding");

            return chromeOptions;
        }
    }
}
