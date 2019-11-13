using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using ozbargain.Models;
using ozbargain.ModelViews;
using ozbargain.Persistance;
using SQLite;

namespace UnitTests
{
    [TestFixture]
    public class MainPageViewModelTest
    {
        private MainPageViewModel _viewModel;
        private Mock<IPageService> _pageService;
        private SQLiteAsyncConnection _connection;

        [SetUp]
        public void Setup()
        {
            _pageService = new Mock<IPageService>();
            _connection = new SQLiteAsyncConnection("file::memory:?cache=shared", true);
            _viewModel = new MainPageViewModel(_pageService.Object, _connection);
        }

        [Test]
        public async Task ItemSelected_WhenCalled_NavigatesToDetailPage()
        {
            var item = new Mock<Item>();
            await _viewModel.ItemSelected(item.Object);
            _pageService.Verify(ps => ps.NavigateToDetailPage(item.Object), Times.Once);
        }

        [Test]
        public async Task FetchDatabaseList_WhenCalled_ReturnsOneItem()
        {
            var itemRepository = new ItemRepository(_connection);
            await itemRepository.Insert(new Item
            {
                Id = 1,
                Title = "New Item",
                Summary = "Item Summary",
                Url = "www.something.com/1/1"
            });

            await _viewModel.FetchDatabaseList();
            Assert.Greater(_viewModel.ItemCount, 0);
        }

        [Test]
        public async Task RefreshListAsync_WhenCalled_ReturnsItems()
        {
            await _viewModel.RefreshListAsync();
            Assert.Greater(_viewModel.ItemCount, 0);
        }
    }
}
