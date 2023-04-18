using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HerokuappTests.Tests
{
    [TestFixture]
    public class CheckboxesTests
    {
        WebDriver ChromeDriver { get; set; }

        [SetUp]
        public void Setup()
        {
            ChromeDriver = new ChromeDriver();
            ChromeDriver.Manage().Window.Maximize();
            ChromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            ChromeDriver.Navigate().GoToUrl("http://the-internet.herokuapp.com/checkboxes");
        }

        [Test]
        public void VerifyingChecknoxes()
        {
            var checkboxes = ChromeDriver.FindElements(By.CssSelector("[type = checkbox]"));

            Assert.That(checkboxes[0].GetAttribute("checked"),Is.Null);
            checkboxes[0].Click();
            Assert.That(checkboxes[0].GetAttribute("checked"), Is.EqualTo("true"));

            Assert.That(checkboxes[1].GetAttribute("checked"), Is.EqualTo("true"));
            checkboxes[1].Click();
            Assert.That(checkboxes[1].GetAttribute("checked"), Is.Null);
        }

        [TearDown]
        public void TearDown()
        {
            ChromeDriver.Quit();
        }
    }
}
