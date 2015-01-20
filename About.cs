using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
namespace EEC
{
    public class About
    {
        public static AboutPage AboutPage
        {
            get
            {
                var aboutpage = new AboutPage();
                PageFactory.InitElements(Browser.Driver, aboutpage);
                return aboutpage;
            }
        }
    }

    public class AboutPage
    {
        string Url = "http://192.168.3.7/qaeec/About-EEC.aspx/lan/en-US";
        string Title = "About EEC";
        public void GoTo()
        {
            Browser.GoTo(Url);
        }
        public bool IsAt()
        {
            return Browser.Title == Title;
        }
        public void Navigator(int n)
        {

            var ID = Browser.Driver.FindElement(By.Id("lytA_ctl26_divViewWrapper"));
            var List = ID.FindElement(By.TagName("ul"));
            var Links = List.FindElements(By.TagName("li"))[n];
            var NavBar = Links.FindElement(By.TagName("a"));
            NavBar.Click();
        }
    }
}
