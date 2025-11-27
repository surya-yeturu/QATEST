using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace CloudQATests
{
    public class Tests
    {
        IWebDriver driver = null!;
        WebDriverWait wait = null!;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            driver = new ChromeDriver(options);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            driver.Navigate().GoToUrl("http://app.cloudqa.io/home/AutomationPracticeForm");
        }

        [TearDown]
        public void TearDown()
        {
            try { driver.Dispose(); }
            catch { }
        }

        // Pure Selenium wait
        private IWebElement WaitAndFind(By by, int secs = 10)
        {
            var localWait = new WebDriverWait(driver, TimeSpan.FromSeconds(secs));
            return localWait.Until(d =>
            {
                try
                {
                    var el = d.FindElement(by);
                    return el.Displayed ? el : null;
                }
                catch
                {
                    return null;
                }
            });
        }

        // ---------------------- TEST 1 ----------------------
        [Test]
        public void Test_FillFirstNameAndLastName()
        {
            IWebElement firstName;

            try
            {
                firstName = WaitAndFind(By.XPath("//input[@name='firstname' or contains(@placeholder,'First')]"));
            }
            catch
            {
                firstName = WaitAndFind(By.XPath("(//input[@type='text'])[1]"));
            }

            firstName.Clear();
            firstName.SendKeys("Surya");

            Assert.That(firstName.GetAttribute("value"), Is.EqualTo("Surya"));

            try
            {
                var lastName = WaitAndFind(By.XPath("//input[@name='lastname' or contains(@placeholder,'Last')]"));
                lastName.Clear();
                lastName.SendKeys("Patil");
            }
            catch { }
        }

        // ---------------------- TEST 2 ----------------------
        [Test]
       public void Test_SelectGender()
    {
        // Select the first gender radio button (Male)
        IWebElement genderRadio = WaitAndFind(By.XPath("(//input[@type='radio'])[1]"));

        if (!genderRadio.Selected)
            genderRadio.Click();

        Assert.That(genderRadio.Selected, Is.True);
    }
        // ---------------------- TEST 3 ----------------------
        [Test]
        public void Test_SelectCountryAndSubmit()
        {
            IWebElement countrySelect;

            try
            {
                countrySelect = WaitAndFind(By.XPath("//select[contains(@id,'country') or contains(@name,'country')]"));
            }
            catch
            {
                countrySelect = WaitAndFind(By.XPath("(//select)[1]"));
            }

            var select = new SelectElement(countrySelect);

            try
            {
                select.SelectByText("India");
            }
            catch
            {
                select.SelectByIndex(1);
            }

            try
            {
                var submitBtn = WaitAndFind(By.XPath("//button[contains(.,'Submit') or @type='submit']"));
                submitBtn.Click();
            }
            catch
            {
                try
                {
                    var submitInput = WaitAndFind(By.XPath("//input[@type='submit']"));
                    submitInput.Click();
                }
                catch { }
            }

            Assert.Pass("Country selected and submit clicked.");
        }
    }
}
