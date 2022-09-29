using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;

namespace PlaywrightTests
{
    [TestFixture]
    public class JobSearchTest
    {
        IBrowser Browser;
        IBrowserContext BrowserContext;
        IPage Page;

        [SetUp]
        public async Task SetUp()
        {
            var playwright = await Playwright.CreateAsync();
            Browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions 
            { 
                Headless = false, 
                SlowMo = 100,
            });
            BrowserContext = await Browser.NewContextAsync(new BrowserNewContextOptions
            {
                RecordVideoDir = "../../../videos/"
            });
            Page = await BrowserContext.NewPageAsync();
            Page.SetDefaultTimeout(3000);
        }

        [TearDown]
        public async Task TearDown()
        {
            await BrowserContext.CloseAsync();
            await Browser.CloseAsync();
        }

        [Test]
        public async Task SearchSuccessTest()
        {
            await Page.GotoAsync("https://www.ceracare.co.uk/");
            await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            
            await Page.ClickAsync("[href='/jobs']");
            await Page.ClickAsync("[id='onetrust-accept-btn-handler']");
            await Page.FillAsync(".location-search-input", "Trafford");

            var listElement = Page.Locator("text=Manchester");
            var text = await listElement.TextContentAsync();

            Assert.IsTrue(text.Equals("Manchester"));
        }

        // Task 2
        //[Test]
        //public async Task SearchNegativeTest(){}
    }
}