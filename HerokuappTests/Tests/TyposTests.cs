using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerokuappTests.Tests
{
    [TestFixture]
    public class TyposTests
    {
        WebDriver ChromeDriver { get; set; }

        [SetUp]
        public void Setup()
        {
            ChromeDriver = new ChromeDriver();
            ChromeDriver.Manage().Window.Maximize();
            ChromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            ChromeDriver.Navigate().GoToUrl("http://the-internet.herokuapp.com/typos");
        }

        [Test]
        public void VerifyingTypos()
        {
            var sentences = ChromeDriver.FindElements(By.TagName("p"));

            Assert.That(sentences[0].Text, Is.EqualTo("This example demonstrates a typo being introduced. It does it randomly on each page load."));
            Assert.That(sentences[1].Text, Is.EqualTo("Sometimes you'll see a typo, other times you want."));
        }

        [TearDown]
        public void TearDown()
        {
            ChromeDriver.Quit();
        }
    }
}
