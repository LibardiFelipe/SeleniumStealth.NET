using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumStealth.NET.Extensions;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SeleniumStealth.NET.Tests.Integration.Extensions
{
    public class Extensions
    {
        [Fact]
        public async Task ShouldPassIfElementIdIsBeingDisplayedWhenSimulatingMouseMovementOverIt()
        {
            // given
            using var cd = new ChromeDriver();
            
            cd.Navigate().GoToUrl(Path.Combine(AppContext.BaseDirectory,
                "Resources/mouse_movement_test.html"));

            var ids = cd.FindElements(By.ClassName("element"))
                .Select(x => x.GetAttribute("id")).ToArray();

            // when
            await cd.WaitAndMoveMouseRandomly(600);

            // then
            var output = cd.FindElement(By.Id("output")).Text;
            Assert.Contains(output, string.Join(' ', ids));
        }
    }
}
