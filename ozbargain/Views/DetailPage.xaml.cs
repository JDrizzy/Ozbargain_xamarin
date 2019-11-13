using ozbargain.Models;
using ozbargain.ModelViews;
using ozbargain.ViewModels;
using Xamarin.Forms;

namespace ozbargain.Views
{
    public partial class DetailPage : ContentPage
    {
        public DetailPageViewModel ViewModel
        {
            get { return BindingContext as DetailPageViewModel; }
            set { BindingContext = value; }
        }

        public DetailPage(Item item)
        {
            ViewModel = new DetailPageViewModel(new PageService())
            {
                Item = item
            };
            InitializeComponent();
        }
    }
}
