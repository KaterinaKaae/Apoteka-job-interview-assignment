
using OpenQA.Selenium;


namespace TestApotec.Tests
{
    public class LoginHelper
    {
        private readonly IWebDriver driver;

        public LoginHelper(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Login(string username, string password)
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
            usernameField.SendKeys(username);
            Console.WriteLine("Enter username Successful!");

            IWebElement passwordField = driver.FindElement(By.Id("password"));
            passwordField.SendKeys(password);
            Console.WriteLine("Enter password Successful!");

            // Find and click on the login button
            IWebElement loginButton = driver.FindElement(By.Id("login-submit"));
            loginButton.Click();
            Console.WriteLine("Submit login Successful!");

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

           
        }    
        
    }
}
