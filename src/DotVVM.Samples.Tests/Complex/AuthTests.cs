﻿using Dotvvm.Samples.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Riganti.Utils.Testing.SeleniumCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotVVM.Samples.Tests.Complex
{
    [TestClass]
    public class AuthTests : SeleniumTestBase
    {
        [TestMethod]
        public void Complex_Auth()
        {
            RunInAllBrowsers(browser =>
            {
                browser.NavigateToUrl(SamplesRouteUrls.ComplexSamples_Auth_Login);

                browser.SendKeys("input[type=text]", "user");
                browser.First("input[type=button]").Click();
                browser.Refresh();
                browser.Wait(2000);
                browser.Last("a").Click();
                browser.Wait(2000);

                browser.SendKeys("input[type=text]", "message");
                browser.First("input[type=button]").Click();

                browser.ElementAt("h1",1)
                    .CheckIfInnerText(
                        s =>
                            s.Contains("DotVVM Debugger: Error 401: Unauthorized"),
                            "User is not in admin role"
                        );

                browser.NavigateToUrl(SamplesRouteUrls.ComplexSamples_Auth_Login);
                
                browser.ClearElementsContent("input[type=text]");
                browser.SendKeys("input[type=text]", "user");
                browser.First("input[type=checkbox]").Click();
                browser.First("input[type=button]").Click();
                browser.Last("a").Click();

                browser.SendKeys("input[type=text]", "message");
                browser.First("input[type=button]").Click();
                browser.First("span").CheckIfInnerText(s => s.Contains("user: message"), "User cant send message");

            });
        }
    }
}
