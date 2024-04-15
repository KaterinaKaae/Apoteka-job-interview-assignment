using com.sun.xml.@internal.bind.v2.model.core;
using com.sun.xml.@internal.bind.v2.schemagen.xmlschema;
using javax.swing.text.html;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestApotec.Tests
{
    public class BasketTest1Chrome //Basket Test on Chrome 
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            // Initialize ChromeDriver with options
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void TestLogin()
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

            IWebElement passwordField = driver.FindElement(By.Id("password"));
            passwordField.SendKeys("Bluehouse24");

            // Find and click on the login button
            IWebElement loginButton = driver.FindElement(By.Id("login-submit"));
            loginButton.Click();

            // Wait for the page to load after login
            System.Threading.Thread.Sleep(4000); 

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

            // Find and click on the haandkoebsmedicin link
            IWebElement haandkoebsmedicinLink = driver.FindElement(By.CssSelector("div[role='navigation'] li:nth-child(3) a:nth-child(1) span:nth-child(1)"));
            haandkoebsmedicinLink.Click();

            // Find and click on the link "Se al håndkøbsmedicin"
            IWebElement counterLink = driver.FindElement(By.PartialLinkText("Se al håndkøbsmedicin"));
            counterLink.Click();

            // Find and click on the link "Børnemedicin"
            IWebElement boernemedicinLink = driver.FindElement(By.PartialLinkText("Børnemedicin"));
            boernemedicinLink.Click();
            Console.WriteLine("Børnemedicin link Successful!");


            // Wait for the page to load 
           // System.Threading.Thread.Sleep(1000);

            // Find and click on the link "Panodil Junior 125mg"
            IWebElement panodil125mgLink = driver.FindElement(By.CssSelector("a.product-link[data-product-id=\"550731\"]"));
            panodil125mgLink.Click();                                         
            Console.WriteLine("Panodil Junior 125mg link Successful!");

            // Wait for the page to load 
            //System.Threading.Thread.Sleep(1000);

            // Find and click on the link "Læg i kurv"
            IWebElement leagikurvLink = driver.FindElement(By.CssSelector("a[class='btn btn-primary btn-lg'] span[class='enable-add']"));
            leagikurvLink.Click();
            Console.WriteLine("Læg i kurv Link Successful!");

            // Wait for the page to load 
            System.Threading.Thread.Sleep(3000);

            // Find and click on the link "Gå til kurv"
            IWebElement gotilkurvLink = driver.FindElement(By.CssSelector("#addToCart > div > div > div.modal-body > div > div.col-xs-12.col-sm-5 > div > div:nth-child(3) > p:nth-child(1) > a"));
            gotilkurvLink.Click();
            Console.WriteLine("Gå til kurv Link Successful!");


            // Check for the product in the basket
            try
            {
                IWebElement CartEmptyMessage = driver.FindElement(By.CssSelector("a[href = '/panodil-junior-125-mg-10-stk-suppositorier-550731']"));
                Console.WriteLine("Selected product is in the basket!"); 

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Selected product is not in the basket!");
            }

            // Wait for the page to load 
            System.Threading.Thread.Sleep(3000);

            // Find and click on the link "Empty basket"
            IWebElement emptybasketLink = driver.FindElement(By.CssSelector("a[title='Fjern fra kurv']"));
            emptybasketLink.Click(); 
            Console.WriteLine("Empty basket Link Successful!");

            // Wait for the page to load 
            System.Threading.Thread.Sleep(3000);

            // Verify that the basket is empty
            IWebElement emptyBasketMessage = driver.FindElement(By.XPath("//h3[normalize-space()='Din kurv er tom']"));
            if (emptyBasketMessage.Enabled)
            {
                Console.WriteLine("Din kurv er tom, test pass."); 
            }
            else
            {
                Console.WriteLine("Din kurv er ikke tom, test failed.");
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
