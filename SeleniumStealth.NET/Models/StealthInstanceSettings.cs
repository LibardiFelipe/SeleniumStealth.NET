using SeleniumStealth.NET.Clients.Enums;

namespace SeleniumStealth.NET.Models
{
    public class StealthInstanceSettings
    {
        public string? ChromeDriverPath { get; set; }
        public EStealthMode Mode { get; set; } = 0;
        public bool FakeChromeApp { get; set; } = true;
        public ChromeRuntime FakeChromeRuntime { get; set; } = new ChromeRuntime();
        public bool IFrameProxy { get; set; } = true;
        public bool FakeCanPlayType { get; set; } = true;
        public bool FakePluginsAndMimeTypes { get; set; } = true;
        public bool FakeWindowOuterDimensions { get; set; } = true;
        public bool HideWebDriver { get; set; } = true;
        public bool RemoveCDCVariables { get; set; } = true;
        public bool FixHairline { get; set; } = true;
        public bool FakeLoadingTimes { get; set; } = true;
    }

    public class ChromeRuntime
    {
        public bool FakeIt { get; set; } = true;
        public bool RunOnInsercureOrigins { get; set; } = false;
    }
}
