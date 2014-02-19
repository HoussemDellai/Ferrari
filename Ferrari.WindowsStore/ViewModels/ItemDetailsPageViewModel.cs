using System.Collections.Generic;
using System.Windows.Input;
using Ferrari.Contracts;
using Ferrari.Models;
using Ferrari.Utilities;
using Microsoft.Practices.Unity;

namespace Ferrari.ViewModels
{
    public class ItemDetailsPageViewModel : BaseViewModel
    {
        private readonly ILiveTileService _liveTileService;
        private readonly ISharingService _sharingService;
        private ICommand _goBackItemCommand;
        private ICommand _goNextItemCommand;
        private List<Item> _itemsCollection;
        private Item _selectedItem;

        public ItemDetailsPageViewModel(IPageNavigationService pageNavigationService,
            ISharingService sharingService,
            List<Item> items,
            Item selectedItem,
            IUnityContainer unityContainer,
            ILiveTileService liveTileService)
            : base(sharingService, pageNavigationService, unityContainer)
        {
            _sharingService = sharingService;
            _liveTileService = liveTileService;

            ItemsCollection = items;
            SelectedItem = selectedItem;
        }

        public Item SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged();

                _sharingService.RegisterForShare(_selectedItem.Title, _selectedItem.Description, _selectedItem.ImageUrl);
                _liveTileService.TryUpdateLiveTileAsync(_selectedItem.Title, _selectedItem.ImageUrl);
            }
        }

        public List<Item> ItemsCollection
        {
            get
            {
                //#if debug
                //				if (_itemscollection == null)
                //				{
                //					item item = new item
                //						{
                //							title = "a royal summit in the south african savannah",
                //							description = "maranello - there was a regal spectacle at the bobbejaansberg nature reserve, near johannesburg.",
                //							publishdate = "thu, 05 dec 2013 19:30:00 gmt",
                //							imageurl = "http://www.ferrari.com/site_collection_image_260x200/131205_130170car_savana_260x200.jpg",
                //							textnews = "there was a regal spectacle at the bobbejaansberg nature reserve, near johannesburg. it was an unusual part of the launch of the 458 speciale, which was making its debut in south africa. at the presentation to a select group of prancing horse customers, there were two guests that were unexpected to say the least: a pair of lions that are part of the ‘kevin richardson wildlife sanctuary’s’ colony of big cats, which is run by a man know the world over as ‘the lion whisperer.’ the kings of the savannah therefore got a close up view of a queen of the road, even if, in order not to disturb them in this close encounter, the v8 in this latest creation from maranello, did not roar as loudly as it could.there was a regal spectacle at the bobbejaansberg nature reserve, near johannesburg. it was an unusual part of the launch of the 458 speciale, which was making its debut in south africa. at the presentation to a select group of prancing horse customers, there were two guests that were unexpected to say the least: a pair of lions that are part of the ‘kevin richardson wildlife sanctuary’s’ colony of big cats, which is run by a man know the world over as ‘the lion whisperer.’ the kings of the savannah therefore got a close up view of a queen of the road, even if, in order not to disturb them in this close encounter, the v8 in this latest creation from maranello, did not roar as loudly as it could.",
                //						};
                //					itemscollection = new list<item>
                //				{
                //					item, item, item
                //				};
                //				}
                //#endif
                return _itemsCollection;
            }
            set
            {
                _itemsCollection = value;
                OnPropertyChanged();
            }
        }

        public ICommand GoNextItemCommand
        {
            get
            {
                if (_goNextItemCommand == null)
                {
                    _goNextItemCommand = new RelayCommand(() =>
                    {
                        SelectedItem = PreviousAndNextFromListUtilities<Item>.GetNextObjectFromCollection(SelectedItem,
                            ItemsCollection);
                    });
                }

                return _goNextItemCommand;
            }
        }

        public ICommand GoBackItemCommand
        {
            get
            {
                if (_goBackItemCommand == null)
                {
                    _goBackItemCommand = new RelayCommand(() =>
                    {
                        SelectedItem =
                            PreviousAndNextFromListUtilities<Item>.GetPreviousObjectFromCollection(SelectedItem,
                                ItemsCollection);
                    });
                }

                return _goBackItemCommand;
            }
        }
    }
}