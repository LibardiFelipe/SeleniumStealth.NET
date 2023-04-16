namespace SeleniumStealth.NET.Models
{
    public class ApplyStealthSettings
    {
        public bool Headless { get; set; } = false;
        public bool AutomationControlled { get; set; } = true;
        public bool SandBox { get; set; } = true;
        public bool InfoBars { get; set; } = true;
        public bool DevShmUsage { get; set; } = true;
        public bool Gpu { get; set; } = true;
        public bool Extensions { get; set; } = true;
        public bool WebSecurity { get; set; } = true;
        public bool BrowserSideNavigation { get; set; } = true;
        public bool VizDisplayCompositor { get; set; } = true;
        public bool RendererBackgrounding { get; set; } = true;
    }
}
