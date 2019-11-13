using System;
using ozbargain.Models;
using ozbargain.ModelViews;

namespace ozbargain.ViewModels
{
    public class DetailPageViewModel : BaseViewModel
    {
        private Item _item;
        public Item Item
        {
            get { return _item; }
            set { SetValue(ref _item, value); }
        }

        public DetailPageViewModel(IPageService pageService)
            : base(pageService)
        {
        }
    }
}
