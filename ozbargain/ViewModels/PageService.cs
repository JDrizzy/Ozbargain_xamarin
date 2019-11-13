using System;
using System.Threading.Tasks;
using ozbargain.Models;
using ozbargain.Views;
using Xamarin.Forms;

namespace ozbargain.ModelViews
{
    public interface IPageService
    {
        Task PushAsync(Page page);
        Task DisplayAlert(string title, string message, string ok);
        Task<bool> DisplayAlert(string title, string message, string ok, string cancel);
        Task NavigateToDetailPage(Item item);
    }

    public class PageService : IPageService
    {
        public Task DisplayAlert(string title, string message, string ok)
        {
            return Application.Current.MainPage.DisplayAlert(title, message, ok);
        }

        public Task<bool> DisplayAlert(string title, string message, string ok, string cancel)
        {
            return Application.Current.MainPage.DisplayAlert(title, message, ok, cancel);
        }

        public Task NavigateToDetailPage(Item item)
        {
            return Application.Current.MainPage.Navigation.PushAsync(new DetailPage(item));
        }

        public Task PushAsync(Page page)
        {
            return Application.Current.MainPage.Navigation.PushAsync(page);
        }
    }
}
