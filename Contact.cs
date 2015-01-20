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
    public class Contact
    {
        public static ContactPage ContactPage
        {
            get
            {
                var contactpage = new ContactPage();
                PageFactory.InitElements(Browser.Driver, contactpage);
                return contactpage;
            }
            
        }
    }
    public class ContactPage
    {
        string Url = "http://192.168.3.7/qaeec/Contact-Us.aspx/lan/en-US";
        string Title = "Contact Us";
        [FindsBy(How = How.Id, Using = "txtName")]
        public IWebElement NameBox;
        [FindsBy(How = How.Id, Using = "txtContactEmail")]
        public IWebElement EmailBox;
        [FindsBy(How = How.Id, Using = "txtMessage")]
        public IWebElement MessageBox;
        [FindsBy(How = How.Id, Using = "btnSubmit")]
        public IWebElement SubmitBtn;
        [FindsBy(How = How.Id, Using = "btnReset")]
        public IWebElement ResetBtn;

        public void GoTo()
        {
            Browser.GoTo(Url);
        }
        public bool IsAt()
        {
            return Browser.Title == Title;
        }

        public void Message(string Name, string Email, string Message, int n)
        {
            NameBox.Click();
            NameBox.Clear();
            NameBox.SendKeys(Name);
            EmailBox.Click();
            EmailBox.Clear();
            EmailBox.SendKeys(Email);
            MessageBox.Click();
            MessageBox.Clear();
            MessageBox.SendKeys(Message);
            if (n == 0)
            {
                ResetBtn.Click();
            }
            else
            {
                SubmitBtn.Click();
            }
        }

    }
}
