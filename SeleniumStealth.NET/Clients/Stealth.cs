using OpenQA.Selenium.Chrome;
using SeleniumStealth.NET.Models;
using SeleniumStealth.NET.Services;

namespace SeleniumStealth.NET.Clients
{
    public static class Stealth
    {
        public static ChromeDriver Instantiate(
            ChromeOptions? chromeOptions = null, StealthInstanceSettings? settings = null) =>
                StealthService.ApplyStealth(chromeOptions, settings);
    }
}
