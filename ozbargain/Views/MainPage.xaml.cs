using AsyncAwaitBestPractices;
using ozbargain.ModelViews;
using ozbargain.Persistance;
using Xamarin.Forms;

namespace ozbargain
{
    public partial class MainPage : ContentPage
    {
        public MainPageViewModel ViewModel
        {
            get { return BindingContext as MainPageViewModel; }
            set { BindingContext = value; }
        }

        public MainPage()
        {
            var pageService = new PageService();
            var connection = Database.Instance.Connection();
            ViewModel = new MainPageViewModel(pageService, connection);
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            //ViewModel.FetchDatabaseList().SafeFireAndForget();
            ViewModel.FetchDatabaseListCommand.Execute(null);
        }

        public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.SelectItemCommand.Execute(e.SelectedItem);
        }
    }
}
