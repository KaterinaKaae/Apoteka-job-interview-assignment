using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestApotec.Tests
{
    public class LogTestPassResetChrome //Login Test on Chrome with password recovery
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            // Initialize ChromeDriver
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void TestLoginPReset()
        {


            // Navigate to the apopro.dk website

            driver.Navigate().GoToUrl("https://apopro.dk");

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

            //Enter wrong password
            IWebElement passwordField = driver.FindElement(By.Id("password"));
            passwordField.SendKeys("Bluehouse50");

            // Find and click on the login button
            IWebElement loginButton = driver.FindElement(By.Id("login-submit"));
            loginButton.Click();

            // Wait for the page to load after login
            System.Threading.Thread.Sleep(5000);

            // Verify if the login was not successful by checking for "Forkert brugernavn eller adgangskode" message
            try
            {
                IWebElement loggedInMessage = driver.FindElement(By.XPath("//p[contains(text(),'Forkert brugernavn eller adgangskode. Prøv igen el')]"));
                Console.WriteLine("Login is not Successful with wrong password! Test pass"); 
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Login is Successful with wrong password!Test failed");
            }

            // Find and click on the element "Glemt din adganskode?"
            IWebElement forgotlogin = driver.FindElement(By.XPath("//a[@id='forgot-login']"));
            forgotlogin.Click();
            Console.WriteLine("Fogot Login link Successful");

            // Find the message "Glemt din adganskode?"
            IWebElement forgotloginmsg = driver.FindElement(By.XPath("//h1[normalize-space()='Glemt din adgangskode?']"));
            Console.WriteLine("Fogot Login message presented");

            // Find the username and password fields and enter credentials
            usernameField = driver.FindElement(By.Id("reset-password"));
            usernameField.SendKeys("jekaterina@mail.dk");

            
            // Find and click on the login button
            loginButton = driver.FindElement(By.Id("to-reset-password"));
            loginButton.Click();

            //Message "Vi har sendt en email til user@..." presented   
            IWebElement emailMessage = driver.FindElement(By.XPath("//div[@class='alert alert-success']"));
            if (emailMessage.Enabled)
            {
                Console.WriteLine("Message 'Vi har sendt en email til user@...' presented! Test pass");
            }
            else
            {
                Console.WriteLine("Message 'Vi har sendt en email til user@...' is not presented! Test failed");
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
