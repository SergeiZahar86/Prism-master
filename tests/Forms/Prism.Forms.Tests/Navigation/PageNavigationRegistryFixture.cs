using System;
using System.Reflection;
using Prism.Forms.Tests.Mocks.Views;
using Prism.Navigation;
using Xunit;

namespace Prism.Forms.Tests.Navigation
{
    [Collection(nameof(PageNavigation))]
    public class PageNavigationRegistryFixture : IDisposable
    {
        [Fact]
        public void RegisterPageForNavigation()
        {
            PageNavigationRegistry.ClearRegistrationCache();

            var name = "MainPage";
            var type = typeof(PageMock);
            PageNavigationRegistry.Register(name, type);

            var info = PageNavigationRegistry.GetPageNavigationInfo(name);

            Assert.NotNull(info);
        }

        [Fact]
        public void NavigationInfoIsNullForUnregisteredPage()
        {
            var name = "UnRegisteredPage";
            var info = PageNavigationRegistry.GetPageNavigationInfo(name);

            Assert.Null(info);
        }

        [Fact]
        public void GetPageType()
        {
            PageNavigationRegistry.ClearRegistrationCache();

            var name = "MainPage";
            var type = typeof(PageMock);
            PageNavigationRegistry.Register(name, type);

            var infoType = PageNavigationRegistry.GetPageType(name);

            Assert.Equal(type, infoType);
        }

        [Fact]
        public void PageTypeIsNullForUnregisteredPage()
        {
            var name = "UnRegisteredPage";
            var infoType = PageNavigationRegistry.GetPageType(name);

            Assert.Null(infoType);
        }

        public void Dispose()
        {
            PageNavigationRegistry.ClearRegistrationCache();
        }
    }
}
