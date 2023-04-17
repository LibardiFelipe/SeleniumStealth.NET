namespace SeleniumStealth.NET.Models
{
    public class ApplyStealthSettings
    {
        public bool DisableAutomationControlled { get; set; } = true;
        public bool NoSandBox { get; set; } = true;
        public bool DisableInfoBars { get; set; } = true;
        public bool DisableDevShmUsage { get; set; } = true;
        public bool DisableGpu { get; set; } = true;
        public bool DisableExtensions { get; set; } = true;
        public bool DisableWebSecurity { get; set; } = true;
        public bool DisableBrowserSideNavigation { get; set; } = true;
        public bool DisableVizDisplayCompositor { get; set; } = true;
        public bool DisableRendererBackgrounding { get; set; } = true;
    }
}
