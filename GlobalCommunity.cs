using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace EEC
{
    public class GlobalCommunity
    {
        public static GlobalCommunityPage GlobalCommunityPage
        {
            get
            {
                var globalcommunitypage = new GlobalCommunityPage();
                PageFactory.InitElements(Browser.Driver, globalcommunitypage);
                return globalcommunitypage;
            }
        }
    }
    public class GlobalCommunityPage
    {
        string Url = "http://192.168.3.7/qaeec/Global-Community.aspx/lan/en-US";
        string Title = "Global Community";
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

            var ID = Browser.Driver.FindElement(By.Id("lytA_ctl44_divViewWrapper"));
            var List = ID.FindElement(By.TagName("ul"));
            var Links = List.FindElements(By.TagName("li"))[n];
            var NavBar = Links.FindElement(By.TagName("a"));
            NavBar.Click();
        }
    }
}
