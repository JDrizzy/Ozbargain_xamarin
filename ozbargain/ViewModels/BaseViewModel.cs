using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SQLite;

namespace ozbargain.ModelViews
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected readonly SQLiteAsyncConnection _connection;
        protected readonly IPageService _pageService;

        public event PropertyChangedEventHandler PropertyChanged;

        public BaseViewModel(IPageService pageService)
        {
            _pageService = pageService;
        }

        public BaseViewModel(IPageService pageService, SQLiteAsyncConnection connection)
        {
            _pageService = pageService;
            _connection = connection;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetValue<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value))
                return;

            backingField = value;

            OnPropertyChanged(propertyName);
        }
    }
}
