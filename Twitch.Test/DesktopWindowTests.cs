using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Twitch.Core;

namespace Twitch.Test
{
    [TestClass]
    public class DesktopWindowTests
    {
        [TestMethod]
        public void the_handle_should_not_be_the_default_intptr()
        {
            Assert.AreNotEqual(default(IntPtr), new DesktopWindow().Handle);
        }

        [TestMethod]
        public void Children_should_list_the_application_windows()
        {
            foreach (var child in new DesktopWindow().Children)
            {
                Console.WriteLine(child.Title);
            }
        }
    }
}