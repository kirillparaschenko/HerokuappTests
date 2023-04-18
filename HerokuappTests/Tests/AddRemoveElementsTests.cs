using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HerokuappTests.Tests
{
    [TestFixture]
    public class AddRemoveElementsTests
    {
        WebDriver ChromeDriver { get; set; }

        [SetUp]
        public void Setup()
        {
            ChromeDriver = new ChromeDriver();
            ChromeDriver.Manage().Window.Maximize();
            ChromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            ChromeDriver.Navigate().GoToUrl("http://the-internet.herokuapp.com/add_remove_elements/");
        }

        [Test]
        public void AddingAndRemovingElements()
        {
            ChromeDriver.FindElement(By.XPath("//button[text()='Add Element']")).Click();
            ChromeDriver.FindElement(By.XPath("//button[text()='Add Element']")).Click();
            ChromeDriver.FindElement(By.XPath("//button[text()='Delete']")).Click();

            var elementCounter = ChromeDriver.FindElements(By.XPath("//button[text()='Delete']")).Count;
            Assert.That(elementCounter, Is.EqualTo(1));
        }

        [TearDown]
        public void TearDown()
        {
            ChromeDriver.Quit();
        }
    }
}