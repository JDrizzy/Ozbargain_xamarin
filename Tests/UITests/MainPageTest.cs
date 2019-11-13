using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using UITest;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class MainPageTest
    {
        IApp app;
        Platform platform;

        public MainPageTest(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
        }

        [Test]
        public void Sync()
        {
            app.Tap(e => e.All().Property("text", "Sync"));
        }
    }
}
