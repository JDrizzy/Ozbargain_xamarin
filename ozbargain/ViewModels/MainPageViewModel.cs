using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using ozbargain.Models;
using ozbargain.Persistance;
using ozbargain.Services;
using SQLite;
using Xamarin.Forms;

namespace ozbargain.ModelViews
{
    public class MainPageViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items
        {
            get;
            private set;
        } = new ObservableCollection<Item>();

        private int _itemCount;
        public int ItemCount
        {
            get { return _itemCount; }
            set { SetValue(ref _itemCount, value); }
        }

        public ICommand SelectItemCommand
        {
            get => new Command<Item>(async (item) => await ItemSelected(item));
        }

        public ICommand FetchDatabaseListCommand
        {
            get => new Command(async () => await FetchDatabaseList());
        }

        public ICommand RefreshListCommand
        {
            get => new Command(async () => await RefreshListAsync());
        }

        public MainPageViewModel(IPageService pageService, SQLiteAsyncConnection connection)
            : base(pageService, connection)
        {

        }

        public async Task<bool> ItemSelected(Item item)
        {
            await _pageService.NavigateToDetailPage(item);

            return true;
        }

        public async Task<bool> FetchDatabaseList()
        {
            var items = await new ItemRepository(_connection).All();
            if (items != null)
            {
                foreach (var item in items)
                {
                    Items.Add(item);
                }
                ItemCount = items.Count;
            }

            return true;
        }

        public async Task<bool> RefreshListAsync()
        {
            var items = OzbargainFetch.Execute();
            foreach (var item in items)
            {
                await new ItemRepository(_connection).Insert(item);
            }
            await FetchDatabaseList();

            return true;
        }
    }
}
