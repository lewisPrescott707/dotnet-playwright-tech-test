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
            
            await Page.ClickAsync("[href='https://www.ceracare.co.uk/jobs/care/']");
            await Page.FillAsync("id=searchLocation", "Manchester");
            await Page.ClickAsync("[type='submit']");

            var listItem = await Page.QuerySelectorAsync(".jobs-list li");
            var text = await listItem.TextContentAsync();

            Assert.IsTrue(text.Equals("Manchester"));
        }

        // Task 2
        //[Test]
        //public async Task SearchNegativeTest(){}
    }
}