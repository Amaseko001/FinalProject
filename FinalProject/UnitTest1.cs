using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;

namespace FinalProject
{

    public class Luma
    {
        public IWebDriver wdriver;
        private string url = "https://luma.enablementadobe.com/content/luma/us/en.html";



        [SetUp]
        public void Setup()


        {

            //Setting up WebDriver Manager
            new DriverManager().SetUpDriver(new EdgeConfig());
            wdriver = new EdgeDriver();

            //Navigate to URL
            wdriver.Navigate().GoToUrl(url);
            wdriver.Manage().Window.Maximize();

        }

        private void ScrollToElement(IWebElement element)

        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)wdriver;
            jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }



        [Test]
        public void TestLogin()
        {
            //For waits
            WebDriverWait wait = new WebDriverWait(wdriver, TimeSpan.FromSeconds(10));



            //Action Logging in process
            wdriver.FindElement(By.XPath("//a[contains(text(),'Login')]")).Click();
            IWebElement emailNameField = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@type='text']")));
            emailNameField.SendKeys("ashley.emaseko@gmail.com");
            IWebElement passwordField = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@type='password']")));
            passwordField.SendKeys("Maseko1234");
            wdriver.FindElement(By.XPath("//button[@type='submit']")).Click();
            IWebElement link = wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Men")));
            link.Click();
            IWebElement MenProductsBtn = wdriver.FindElement(By.XPath("//*[@id=\'page-e590d8a77d\']/div[1]/div/div/div[3]/div/div[5]/div/a"));
            //Scroll page down
            ScrollToElement(MenProductsBtn);
            MenProductsBtn.Click();
        }
    }
}