using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;

// Directive for the data model.
using RCmechanics.Model;
using System;
using System.Linq.Expressions;
using System.Windows.Input;
using System.Windows.Navigation;

namespace RCmechanics.ViewModel
{ 
    public class ToDoViewModel : INotifyPropertyChanged
    {
        // LINQ to SQL data context for the local database.
        public ToDoDataContext toDoDB;
        // public NavigationService Navigation {get; set;}
        // Class constructor, create the data context object.
        public ToDoViewModel(string toDoDBConnectionString)
        {
            toDoDB = new ToDoDataContext(toDoDBConnectionString);
        }

        // All to-do items.
        private ObservableCollection<ToDoItem> _allToDoItems;
        public ObservableCollection<ToDoItem> AllToDoItems
        {
            get { return _allToDoItems; }
            set
            {
                _allToDoItems = value;
                NotifyPropertyChanged("AllToDoItems");
            }
        }
        
        private ObservableCollection<ToDoItem> _favoriteToDoItems;
        public ObservableCollection<ToDoItem> FavoriteToDoItems 
        {
            get { return _favoriteToDoItems; }
            set 
            {
                _favoriteToDoItems = value;
                NotifyPropertyChanged("FavoriteToDoItems");
            }
        }

        private ObservableCollection<ToDoItem> _searchResult;
        public ObservableCollection<ToDoItem> SearchResult 
        {
            get { return _searchResult; }
            set 
            {
                _searchResult = value;
                NotifyPropertyChanged("SearchResult");
            }
        }

        private ObservableCollection<ToDoItem> _searchFavoriteResult;
        public ObservableCollection<ToDoItem> SearchFavoriteResult
        {
            get { return _searchFavoriteResult; }
            set
            {
                _searchFavoriteResult = value;
                NotifyPropertyChanged("SearchFavoriteResult");
            }
        }

        public event Action<int> ItemSelected;
        private ToDoItem _selected;
        public ToDoItem SelectedItem
        {
            get { return _selected; }
            set 
            { 
                if (value != null) 
            {
                _selected = value;
                if (ItemSelected != null) 
                {
                    ItemSelected(_selected.ToDoItemId);
                }
            }
            }
        }
        
        // Query database and load the collections and list used by the pivot pages.
        public void LoadCollectionsFromDatabase()
        {
            
            // Specify the query for all to-do items in the database.
            var toDoItemsInDB = from ToDoItem todo in toDoDB.Items
                                select todo;
            // Specify the query for all fav items where favorite = 1 in the database.
            var favItemsInDB = from ToDoItem state in toDoDB.Items 
                               where state.Favorite == "1"
                               select state;

            // Query the database and load all to-do items.
            AllToDoItems = new ObservableCollection<ToDoItem>(toDoItemsInDB);

            // Query the database and load all fav items.
            FavoriteToDoItems = new ObservableCollection<ToDoItem>(favItemsInDB);

            if (AllToDoItems.Count == 0) 
            {
                this.IsDataLoaded = true;
            }

            if (FavoriteToDoItems.Count == 0)
            {
                this.IsFavDataLoaded = true;
            }

         }
   
        // Add a to-do item to the database and collections.
        public void AddToDoItem(ToDoItem newToDoItem)
        {
            // Add a to-do item to the data context.
            toDoDB.Items.InsertOnSubmit(newToDoItem);

            // Save changes to the database.
            toDoDB.SubmitChanges();

            // Add a to-do item to the "all" observable collection.
            AllToDoItems.Add(newToDoItem);

            //Update ListBox message state.
            this.IsDataLoaded = false;

        }

        // Remove a to-do task item from the database and collections.
        public void DeleteToDoItem(ToDoItem toDoForDelete)
        {

            // Remove the to-do item from the "all" observable collection.
            AllToDoItems.Remove(toDoForDelete);
            FavoriteToDoItems.Remove(toDoForDelete);
            SearchResult.Remove(toDoForDelete);

            // Remove the to-do item from the data context.
            toDoDB.Items.DeleteOnSubmit(toDoForDelete);

            // Save changes to the database.
            toDoDB.SubmitChanges();

            if (AllToDoItems.Count == 0)
            {
                this.IsDataLoaded = true;
            }

            if (FavoriteToDoItems.Count == 0) 
            {
                this.IsFavDataLoaded = true;
            }
        }

        public void SaveChangesToDB()
        {
            toDoDB.SubmitChanges();
        }

        public NavigationService Navigation {get; set;}

        #region Loaded Data messages
        private bool _IsDataLoaded;
        public bool IsDataLoaded 
        {
            get 
            {
                return _IsDataLoaded;
            }
            set 
            {
                _IsDataLoaded = value;
                if (PropertyChanged != null) 
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("IsDataLoaded"));
                    PropertyChanged(this, new PropertyChangedEventArgs("EmptyMessage"));
                }
            }
        }
        public string EmptyMessage 
        {
            get 
            {
                if (IsDataLoaded)
                {
                    return "No setup sheets yet. Lets add some and get you started.";
                }
                else 
                {
                    return "";
                }
            }
            set { }
        }
        private bool _IsFavDataLoaded;
        public bool IsFavDataLoaded
        {
            get
            {
                return _IsFavDataLoaded;
            }
            set
            {
                _IsFavDataLoaded = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("IsFavDataLoaded"));
                    PropertyChanged(this, new PropertyChangedEventArgs("EmptyFavMessage"));
                }
            }
        }
        public string EmptyFavMessage
        {
            get
            {
                if (IsFavDataLoaded)
                {
                    return "No favorites added yet.";
                }
                else
                {
                    return "";
                }
            }
            set { }
        }
        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

    }
}