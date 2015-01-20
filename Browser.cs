using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;


namespace EEC
{
    class Browser
    {
        static IWebDriver webDriver = new FirefoxDriver();
        //static IWebDriver webDriver = new ChromeDriver();
        //static IWebDriver webDriver = new InternetExplorerDriver();
        
        public static string Title
        {
            get { return webDriver.Title; }
        }
        /*  public static string Text
          {
              get { return Login.LoginPage.LoginText.Text; }
          }*/
        public static void GoTo(string url)
        {
            webDriver.Url = url;
        }

        public static ISearchContext Driver
        {
            get { return webDriver; }
        }

    }
}
