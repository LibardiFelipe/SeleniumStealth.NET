using System;

namespace SeleniumStealth.NET.Models
{
    internal class NavigatorInfo
    {
        private static readonly Random _rnd = new();

        public NavigatorInfo()
        {
            Vendor = GetRandomNavigatorVendor();
            UserAgent = GetUserAgent(Vendor);
            (WebGLVendor, WebGLRenderer) = GetWebGlInfo(Vendor);
        }

        public string Vendor { get; set; }
        public string UserAgent { get; set; }
        public string WebGLVendor { get; set; }
        public string WebGLRenderer { get; set; }

        private static string GetRandomNavigatorVendor()
        {
            string[] vendors = { "Google Inc.", "Microsoft Corporation", "Mozilla Foundation" };
            return vendors[_rnd.Next(vendors.Length)];
        }

        private static string GetUserAgent(string vendor)
        {
            return vendor switch
            {
                "Google Inc." => $"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/{_rnd.Next(80, 100)}.0.{_rnd.Next(1000, 9999)}.{_rnd.Next(1, 200)} Safari/537.36",
                "Microsoft Corporation" => $"Mozilla/5.0 (Windows NT 10.0; Win64; x64; Trident/7.0; rv:{_rnd.Next(10, 13)}.0) like Gecko",
                _ => $"Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:{_rnd.Next(50, 100)}.0) Gecko/20100101 Firefox/{_rnd.Next(70, 100)}.0",
            };
        }

        private static (string, string) GetWebGlInfo(string webGLVendor)
        {
            string webGLRenderer = webGLVendor switch
            {
                "Google Inc." => "ANGLE (Intel(R) HD Graphics 630 Direct3D11 vs_5_0 ps_5_0)",
                "Microsoft Corporation" => "Microsoft Basic Render Driver",
                _ => "ANGLE (AMD Radeon R7 370 Direct3D11 vs_5_0 ps_5_0)",
            };
            return (webGLVendor, webGLRenderer);
        }
    }
}
