using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace TestApotec.Tests
{
    public class LoginTestFirefox //Login Test on Firefox with correct credentials
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            // Initialize FirefoxDriver
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void TestLogin()
        {


            // Navigate to the apopro.dk website

            driver.Navigate().GoToUrl("https://apopro.dk");

            // Wait for the page to load after login
            System.Threading.Thread.Sleep(3000);

            // Find and click on the cookies "Accepter alle"
            IWebElement cookies = driver.FindElement(By.XPath("//button[@aria-label='Accepter alle']"));
            cookies.Click();

            // Wait for the page to load after login
            System.Threading.Thread.Sleep(3000);

            // Find and click on the login link
            IWebElement loginLink = driver.FindElement(By.CssSelector("a[href='/Account/Login']"));
            loginLink.Click();

            // Find the username and password fields and enter credentials
            IWebElement usernameField = driver.FindElement(By.Id("Email"));
            usernameField.SendKeys("jekaterina@mail.dk");

            IWebElement passwordField = driver.FindElement(By.Id("password"));
            passwordField.SendKeys("Bluehouse24");

            // Find and click on the login button
            IWebElement loginButton = driver.FindElement(By.Id("login-submit"));
            loginButton.Click();

            // Wait for the page to load after login
            System.Threading.Thread.Sleep(5000); 

            // Verify if the login was successful by checking for "Profil for jekaterina@mail.dk" element on the logged-in page
            try
            {
                IWebElement loggedInMessage = driver.FindElement(By.CssSelector("h1[class='col-sm-12']"));
                Console.WriteLine("Login Successful!"); 
              
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Login Failed!");
            }

            // Close the browser
            driver.Quit();
        }
            [TearDown]
            public void TearDown()
            {
                // Dispose of the driver object
                driver.Dispose();
            }
        
    }
}
