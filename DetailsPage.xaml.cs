
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

using RCmechanics.Model;
using RCmechanics.ViewModel;
using Microsoft.Phone.Shell;
using System.ComponentModel;

namespace RCmechanics
{
    public partial class DetailsPage : PhoneApplicationPage
    {
        public DetailsPage()
        {
            InitializeComponent();
        }

        string selectedIndex = "";
        string selectedIndexFavorite = "";
        string selectedIndexFavoriteSearch = "";
        string selectedIndexSearch = "";
        
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            
            if (NavigationContext.QueryString.TryGetValue("itemId", out selectedIndex))
            {
                //int index = int.Parse(selectedIndex);
                //DataContext = App.ViewModel.AllToDoItems[index];

                int id = int.Parse(selectedIndex);
                DataContext = GetById(id);
            }

            if (NavigationContext.QueryString.TryGetValue("selectedItemFavorite", out selectedIndexFavorite)) 
            {
                int indexFavorite = int.Parse(selectedIndexFavorite);
                DataContext = App.ViewModel.FavoriteToDoItems[indexFavorite];
            }

            if (NavigationContext.QueryString.TryGetValue("selectedItemSearch", out selectedIndexSearch))
            {
                int id = int.Parse(selectedIndexSearch);
                DataContext = GetById(id);
            }

            if (NavigationContext.QueryString.TryGetValue("selectedItemFavoriteSearch", out selectedIndexFavoriteSearch))
            {
                int id = int.Parse(selectedIndexFavoriteSearch);
                DataContext = GetByFavId(id);
            }

        }


    public ToDoItem GetById(int id)
    {
 	    for(int i = 0; i < App.ViewModel.AllToDoItems.Count; i++)
        {
            if (App.ViewModel.AllToDoItems[i].ToDoItemId == id)
                return App.ViewModel.AllToDoItems[i];
        }
        return null;
    }

    public ToDoItem GetByFavId(int id)
    {
        for (int i = 0; i < App.ViewModel.FavoriteToDoItems.Count; i++)
        {
            if (App.ViewModel.FavoriteToDoItems[i].ToDoItemId == id)
                return App.ViewModel.FavoriteToDoItems[i];
        }
        return null;
    }

        public void favoriteState()
        {
            var ItemID = int.Parse(ID.Text);
            IQueryable<ToDoItem> favoriteQuery = from c in App.ViewModel.toDoDB.Items where c.ToDoItemId == ItemID select c;

            ToDoItem favoriteToUpdate = favoriteQuery.FirstOrDefault();

            // update the city by changing its name
            favoriteToUpdate.Favorite = "1";
            
            // save changes to the database
            App.ViewModel.SaveChangesToDB();
            App.ViewModel.LoadCollectionsFromDatabase();
            App.ViewModel.IsFavDataLoaded = false;
            
        }
        
        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/EditSheet.xaml?selectedItem=" + selectedIndex, UriKind.Relative));
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            favoriteState();

            if (NavigationService.CanGoBack)
            {
                ApplicationBar.IsVisible = true;
                NavigationService.GoBack();
            }
        }

        string favstateResource;
        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (FavoriteState.Text == "1")
            {
                favstateResource = "AppBar2";
            }
            else 
            {
                favstateResource = "AppBar";
            }
            ApplicationBar = (ApplicationBar)Resources[favstateResource];
        }

        private void ApplicationBarIconButton_Click_2(object sender, EventArgs e)
        {
            var ItemID = int.Parse(ID.Text);
            IQueryable<ToDoItem> favoriteQuery = from c in App.ViewModel.toDoDB.Items where c.ToDoItemId == ItemID select c;

            ToDoItem favoriteToUpdate = favoriteQuery.FirstOrDefault();

            // update the city by changing its name
            favoriteToUpdate.Favorite = "0";

            // save changes to the database
            App.ViewModel.SaveChangesToDB();
            App.ViewModel.LoadCollectionsFromDatabase();
            //App.ViewModel.IsFavDataLoaded = false;
            favstateResource = "AppBar";
            ApplicationBar = (ApplicationBar)Resources[favstateResource];

            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }
        

    }
}