using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Lesson7.Models;
using System.Collections.ObjectModel;

namespace Lesson7.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        #region Properties

        #region ItemCollection

        /// <summary>
        /// The <see cref="ItemCollection" /> property's name.
        /// </summary>
        public const string ItemCollectionPropertyName = "ItemCollection";

        private ObservableCollection<ItemModel> _itemCollection = new ObservableCollection<ItemModel>();

        /// <summary>
        /// Sets and gets the ItemCollection property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<ItemModel>  ItemCollection
        {
            get
            {
                return _itemCollection;
            }

            set
            {
                if (_itemCollection == value)
                {
                    return;
                }

                _itemCollection = value;
                RaisePropertyChanged(ItemCollectionPropertyName);
            }
        }

        #endregion

        #region ItemSelected

        /// <summary>
        /// The <see cref="ItemSelected" /> property's name.
        /// </summary>
        public const string ItemSelectedPropertyName = "ItemSelected";

        private ItemModel _itemSelected = null;

        /// <summary>
        /// Sets and gets the ItemSelected property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ItemModel ItemSelected
        {
            get
            {
                return _itemSelected;
            }

            set
            {
                if (_itemSelected == value)
                {
                    return;
                }

                _itemSelected = value;
                RaisePropertyChanged(ItemSelectedPropertyName);
            }
        }

        #endregion

        #endregion

        #region Commadns

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            Messenger.Default.Register<string>(this, ClearCollection);
        }

        #endregion

        #region Methods

        private void ClearCollection(string vlaue)
        {
            ItemCollection.Clear();
        }


        #endregion

    }
}