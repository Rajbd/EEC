using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace EEC
{
    public class Home
    {
        public static HomePage HomePage
        {
            get
            {
                var homepage = new HomePage();
                PageFactory.InitElements(Browser.Driver, homepage);
                return homepage;
            
            }
            
        }
    }
    public class HomePage
    {
        string Url = "http://192.168.3.7/qaeec/";
        string Title = "Home";
        //Login
        [FindsBy(How = How.Id, Using = "lytA_ctl53_UserName")]
        public IWebElement UserNameBox;
        [FindsBy(How = How.Id, Using = "lytA_ctl53_Password")]
        public IWebElement PasswordBox;
        [FindsBy(How = How.Id, Using = "lytA_ctl53_btnLogin")]
        public IWebElement LoginButton;
        //Search
        [FindsBy(How = How.Id, Using = "lytA_ctl11_txt_3")]
        public IWebElement SearchBox;
        [FindsBy(How = How.Id, Using = "lytA_ctl11_btnSageSearch")]
        public IWebElement SearchButton;
        public void GoTo()
        {
            Browser.GoTo(Url);
        }
        public bool IsAt()
        {
            return Browser.Title == Title;
        }
        
        public void LogIn(string Username, string Password)
        {
            UserNameBox.Click();
            UserNameBox.Clear();
            UserNameBox.SendKeys(Username);
            PasswordBox.Click();
            PasswordBox.Clear();
            PasswordBox.SendKeys(Password);
            LoginButton.Click();
        }
       
          public void Menu(int n)
            {
                var ID = Browser.Driver.FindElement(By.Id("divNav_48"));
                var Title = ID.FindElement(By.TagName("ul"));
                var Menu = Title.FindElements(By.TagName("li"));
                var Link = Menu[n].FindElement(By.TagName("a"));
                Thread.Sleep(3000);
                Link.Click();
            }
          /*     public void SubCategoryMenu(int m, int n)
             {
                 var ID = Browser.Driver.FindElement(By.Id("divNav_48"));
                 var Title = ID.FindElement(By.TagName("ul"));
                 var Menu = Title.FindElements(By.TagName("li"));
                 var Links = Menu[m].FindElement(By.TagName("ul"));
                 var Lists = Links.FindElements(By.TagName("li"));
                 var Category = Lists[n].FindElement(By.TagName("a"));
                 Category.Click();
             }*/
        public void Search(string searchtext)
        {
            SearchBox.Click();
            SearchBox.Clear();
            SearchBox.SendKeys(searchtext);
            SearchButton.Click(); 
        }
        public void SwitchResources(int n)
        {
            var ID = Browser.Driver.FindElement(By.Id("ulTabcontent"));
            var List = ID.FindElements(By.TagName("li"))[n];
            var Link = List.FindElement(By.TagName("a"));
            Link.Click();
        }
        public void ViewResources(int n)
        {
            var ID = Browser.Driver.FindElement(By.Id("ulResourcelist"));
            var List = ID.FindElements(By.TagName("li"))[n];
            var Link = List.FindElements(By.TagName("div"))[1];
            var Resource = Link.FindElement(By.TagName("h3"));
            var ResourceLink = Resource.FindElement(By.TagName("a"));
            ResourceLink.Click(); 
        }
        public void ViewEvents(int n)
        {
            var ID = Browser.Driver.FindElement(By.Id("sfEvent"));
            var List = ID.FindElement(By.TagName("div"));
            var Link = List.FindElement(By.TagName("div"));
            var Events = Link.FindElement(By.TagName("div"));
            var EventLink = Events.FindElement(By.TagName("ul"));
            var EventList = EventLink.FindElements(By.TagName("li"))[n];
            var ListEvent = EventList.FindElement(By.TagName("div"));
            var Event = ListEvent.FindElement(By.TagName("a"));
            Event.Click();
        }
        public void DownLoadTools(int n)
        {
            var ID = Browser.Driver.FindElement(By.Id("sfTools"));
            var List = ID.FindElement(By.TagName("div"));
            var Link = List.FindElement(By.TagName("div"));
            var Tools = Link.FindElement(By.TagName("div"));
            var ToolLink = Tools.FindElement(By.TagName("ul"));
            var ToolList = ToolLink.FindElements(By.TagName("li"))[n];
            var ListTool = ToolList.FindElement(By.TagName("div"));
            var LinkTool = ListTool.FindElement(By.TagName("div"));
            var Tool = LinkTool.FindElement(By.TagName("a"));
            Tool.Click();
        }
    }
}
