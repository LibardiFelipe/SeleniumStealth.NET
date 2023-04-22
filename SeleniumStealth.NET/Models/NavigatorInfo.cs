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
            MemorySize = GetRandomMemorySize();
            (WebGLVendor, WebGLRenderer) = GetWebGlInfo(Vendor);
        }

        public string Vendor { get; set; }
        public string UserAgent { get; set; }
        public string WebGLVendor { get; set; }
        public string WebGLRenderer { get; set; }
        public int MemorySize { get; set; }
        
        private static int GetRandomMemorySize()
        {
            int[] sizes = { 4, 8, 16, 32 };
            return sizes[_rnd.Next(sizes.Length)];
        }

        private static string GetRandomNavigatorVendor()
        {
            string[] vendors = { "Google Inc.", "Microsoft Corporation",
                "Mozilla Foundation", "Apple Inc.", "Opera Software" };

            return vendors[_rnd.Next(vendors.Length)];
        }

        private static string GetUserAgent(string vendor)
        {
            return vendor switch
            {
                "Google Inc." => $"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/{_rnd.Next(80, 100)}.0.{_rnd.Next(1000, 9999)}.{_rnd.Next(1, 200)} Safari/537.36",
                "Microsoft Corporation" => $"Mozilla/5.0 (Windows NT 10.0; Win64; x64; Trident/7.0; rv:{_rnd.Next(10, 13)}.0) like Gecko",
                "Apple Inc." => $"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_{_rnd.Next(12, 16)}_{_rnd.Next(1, 9)}) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/{_rnd.Next(11, 15)}.0 Safari/605.1.15",
                "Opera Software" => $"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/{_rnd.Next(60, 80)}.0.{_rnd.Next(1000, 9999)}.{_rnd.Next(1, 200)} Safari/537.36 OPR/{_rnd.Next(40, 60)}.0.{_rnd.Next(1000, 9999)}.{_rnd.Next(1, 200)}",
                _ => $"Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:{_rnd.Next(50, 100)}.0) Gecko/20100101 Firefox/{_rnd.Next(70, 100)}.0",
            };
        }

        private static (string, string) GetWebGlInfo(string navVendor)
        {
            string webGLRenderer = navVendor switch
            {
                "Google Inc." => $"ANGLE (Intel(R) HD Graphics {_rnd.Next(600, 700)} Direct3D11 vs_5_0 ps_5_0)",
                "Microsoft Corporation" => "Microsoft Basic Render Driver",
                "Apple Inc." => $"Apple GPU {_rnd.Next(1, 5)}",
                "Opera Software" => $"ANGLE (NVIDIA GeForce {_rnd.Next(900, 1000)} GT {_rnd.Next(1, 10)} Direct3D11 vs_5_0 ps_5_0)",
                _ => $"ANGLE (AMD Radeon R{_rnd.Next(5, 9)} {_rnd.Next(300, 400)} Direct3D11 vs_5_0 ps_5_0)"
            };

            return (navVendor.Replace("Google Inc.", "Intel Inc."), webGLRenderer);
        }
    }
}
