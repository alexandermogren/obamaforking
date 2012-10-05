using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Microsoft.Phone.Controls.Primitives;
using Microsoft.Phone.Tasks;
using System.Windows.Data;
using System.Linq.Expressions;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text.RegularExpressions;
using RCmechanics.Model;
using Microsoft.Phone.Shell;
using System.Windows.Interactivity;


namespace RCmechanics

{
    public partial class MainPage : PhoneApplicationPage
    {
        EmailAddressChooserTask emailAddressChooserTask;
        public MainPage()
        {
            
            InitializeComponent();

            rcmsettings settings = new rcmsettings();

            App.ViewModel.ItemSelected += OnItemSelected;
            App.ViewModel.ItemSelected += OnFavItemSelected;
            
            this.emailAddressChooserTask = new EmailAddressChooserTask();
            this.emailAddressChooserTask.Completed += new EventHandler<EmailResult>(emailAddressChooserTask_Completed);
            this.DataContext = App.ViewModel;
            
        }
            
        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/addsheet.xaml", UriKind.Relative));
        }

        private void deleteTaskButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult m = MessageBox.Show("This setup sheet, plus any information it contains, will be deleted.", "Delete this sheet?", MessageBoxButton.OKCancel);

            if (m == MessageBoxResult.OK) 
            {
                var button = sender as Button;

                if (button != null)
                {
                    // Get a handle for the to-do item bound to the button.
                    ToDoItem toDoForDelete = button.DataContext as ToDoItem;

                    App.ViewModel.DeleteToDoItem(toDoForDelete);
                }
                this.Focus();
            }
            
        }
        
        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            App.ViewModel.SaveChangesToDB();
            if (ApplicationBar.IsVisible == false) 
            {
                ApplicationBar.IsVisible = true;
            }
            App.ViewModel.SearchResult = null;
            App.ViewModel.SearchFavoriteResult = null;
            App.ViewModel.ItemSelected -= OnItemSelected;
            App.ViewModel.ItemSelected -= OnFavItemSelected;

            searchToDoItemsListBox.IsHitTestVisible = false;
            searchToDoItemsListBox.Visibility = Visibility.Collapsed;
            searchFavoriteToDoItemsListBox.IsHitTestVisible = false;
            searchFavoriteToDoItemsListBox.Visibility = Visibility.Collapsed;

            allToDoItemsListBox.IsHitTestVisible = true;
            favoriteToDoItemsListBox.IsHitTestVisible = true;
            searchPopup.IsOpen = false;

            base.OnNavigatedFrom(e);
        }
        
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            DataContext = App.ViewModel;
            valueSearch.Text = "";
            //searchPopup.IsOpen = false;

            App.ViewModel.ItemSelected += OnItemSelected;
            App.ViewModel.ItemSelected += OnFavItemSelected;

            allToDoItemsListBox.Visibility = Visibility.Visible;
            favoriteToDoItemsListBox.Visibility = Visibility.Visible;
        }

        private void allToDoItemsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = allToDoItemsListBox.SelectedItem as ToDoItem;
            if (item != null) 
            {
                var itemId = item.ToDoItemId;
                NavigationService.Navigate(new Uri("/DetailsPage.xaml?itemId" + itemId, UriKind.Relative));
            }
            //if (allToDoItemsListBox.SelectedIndex == -1)
                //return;
            //NavigationService.Navigate(new Uri("/DetailsPage.xaml?selectedItem=" + allToDoItemsListBox.SelectedIndex, UriKind.Relative));
            //allToDoItemsListBox.SelectedIndex = -1;
        }

        private void ApplicationBarMenuItem_Click_1(object sender, EventArgs e)
        {
            MarketplaceReviewTask marketplaceReviewTask = new MarketplaceReviewTask();
            marketplaceReviewTask.Show();
        }

        private void ApplicationBarMenuItem_Click_2(object sender, EventArgs e)
        {
            EmailComposeTask emailComposeTask = new EmailComposeTask();
            emailComposeTask.Subject = "Question/Support request for RC Mechanics";
            emailComposeTask.To = "mogrendevelopment@live.com";
            emailComposeTask.Show();
        }

        private void ApplicationBarMenuItem_Click_3(object sender, EventArgs e)
        {
            try
            {
                emailAddressChooserTask.Show();
            }
            catch(System.InvalidOperationException ex)
            {
                MessageBox.Show("An error occurred");
            }
        }

        void emailAddressChooserTask_Completed(object sender, EmailResult e)
        {
            if (e.TaskResult == TaskResult.OK) 
            {
                //MessageBox.Show("The email for " + e.DisplayName + " is " + e.Email);
                EmailComposeTask emailComposeTask = new EmailComposeTask();
                emailComposeTask.To = e.Email;
                emailComposeTask.Subject = "RC Mechanics";
                emailComposeTask.Body = "RC Mechanics for Windows Phone is awesome! I just wanted to let you know! Go to marketplace and download it TODAY!";
                emailComposeTask.Show();
            }
        }

        private void pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            string pivotResource;
            //switch (pivot.SelectedIndex)
            switch (((Pivot)sender).SelectedIndex)
            {
                case 0:
                    pivotResource = "AppBar";
                    break;

                case 2:
                    pivotResource = "AppBarTwo";
                    break;

                default:
                    pivotResource = "AppBar";
                    break;
                    
                   //throw new ArgumentOutOfRangeException();
            }

            ApplicationBar = (ApplicationBar)Resources[pivotResource];

            if (pivot.SelectedIndex == 0)
            {
                var TotalItemCount = App.ViewModel.AllToDoItems.Count();
                var TotalItemFavCount = App.ViewModel.FavoriteToDoItems.Count();
                Total.Text = TotalItemCount.ToString();
                TotalFav.Text = TotalItemFavCount.ToString();
            }
            if (pivot.SelectedIndex == 1)
            {
                var TotalItemCount = App.ViewModel.AllToDoItems.Count();
                var TotalItemFavCount = App.ViewModel.FavoriteToDoItems.Count();
                Total.Text = TotalItemCount.ToString();
                TotalFav.Text = TotalItemFavCount.ToString();
            }
            if (pivot.SelectedIndex == 2)
            {
                var TotalItemCount = App.ViewModel.AllToDoItems.Count();
                var TotalItemFavCount = App.ViewModel.FavoriteToDoItems.Count();
                //var satan = App.ViewModel.toDoDB.Items.Where(x => x.ItemFinish == "1").Count();
                
                Total.Text = TotalItemCount.ToString();
                TotalFav.Text = TotalItemFavCount.ToString();
                //TotalQ.Text = satan.ToString();
                if (allToDoItemsListBox.Items.Count > 0)
                {
                    StatMessage.Visibility = Visibility.Collapsed;
                    StatGrid.Visibility = Visibility.Visible;
                }
                else
                {
                    StatMessage.Visibility = Visibility.Visible;
                    StatGrid.Visibility = Visibility.Collapsed;
                }
            }
            
        }
        
        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
           
            if (allToDoItemsListBox.Items.Count < 3)
            {
                MessageBoxResult mess = MessageBox.Show("You must have added more than three(3) setup sheets to use this feature, add some sheets and try it out.", "Quick sheet feature!", MessageBoxButton.OK);
            }
            else 
            {
                MessageBoxResult messok = MessageBox.Show("messtext", "big nono", MessageBoxButton.OK);

            }
          
        }

        private void favoriteToDoItemsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (favoriteToDoItemsListBox.SelectedIndex == -1)
                return;
            NavigationService.Navigate(new Uri("/DetailsPage.xaml?selectedItemFavorite=" + favoriteToDoItemsListBox.SelectedIndex, UriKind.Relative));
            favoriteToDoItemsListBox.SelectedIndex = -1;
        }

        
        private void ApplicationBarIconButton_Click_2(object sender, EventArgs e)
        {
            searchPopup.IsOpen = true;
            //LayoutRoot.IsHitTestVisible = false;
            searchToDoItemsListBox.IsHitTestVisible = true;
            searchFavoriteToDoItemsListBox.IsHitTestVisible = true;
            //allToDoItemsListBox.IsHitTestVisible = false;
            ApplicationBar.IsVisible = false;
            valueSearch.Focus();
            App.ViewModel.SearchResult = null;
            App.ViewModel.SearchFavoriteResult = null;
        }

        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            if (searchPopup.IsOpen)
            {
                searchPopup.IsOpen = false;
                //LayoutRoot.IsHitTestVisible = true;
                searchToDoItemsListBox.IsHitTestVisible = false;
                searchFavoriteToDoItemsListBox.IsHitTestVisible = false;
                allToDoItemsListBox.IsHitTestVisible = true;
                favoriteToDoItemsListBox.IsHitTestVisible = true;
                ApplicationBar.IsVisible = true;
                e.Cancel = true;
                DataContext = App.ViewModel;
                valueSearch.Text = "";

                allToDoItemsListBox.Visibility = Visibility.Visible;
                favoriteToDoItemsListBox.Visibility = Visibility.Visible;

                searchToDoItemsListBox.Visibility = Visibility.Collapsed;
                searchFavoriteToDoItemsListBox.Visibility = Visibility.Collapsed;
                
                App.ViewModel.SearchResult = null;
                App.ViewModel.SearchFavoriteResult = null;
                
            }

            base.OnBackKeyPress(e);
        }

        private void valueSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filteredList = App.ViewModel.AllToDoItems.Where(x => x.ItemDriver.StartsWith(valueSearch.Text)).ToList();
            App.ViewModel.SearchResult = new ObservableCollection<ToDoItem>(filteredList);

            var filteredFavoriteList = App.ViewModel.FavoriteToDoItems.Where(x => x.ItemDriver.StartsWith(valueSearch.Text)).ToList();
            App.ViewModel.SearchFavoriteResult = new ObservableCollection<ToDoItem>(filteredFavoriteList);

            if (valueSearch.Text.Length == 0) 
            {
                DataContext = App.ViewModel;
                allToDoItemsListBox.Visibility = Visibility.Visible;
                favoriteToDoItemsListBox.Visibility = Visibility.Visible;
                //App.ViewModel.SearchResult = null;
            }

            allToDoItemsListBox.Visibility = Visibility.Collapsed;
            favoriteToDoItemsListBox.Visibility = Visibility.Collapsed;
            searchToDoItemsListBox.Visibility = Visibility.Visible;
            searchFavoriteToDoItemsListBox.Visibility = Visibility.Visible;
            allToDoItemsListBox.IsHitTestVisible = false;
            favoriteToDoItemsListBox.IsHitTestVisible = false;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void searchResult_Loaded(object sender, RoutedEventArgs e)
        {
            var textBlock = sender as TextBlock;
            if (valueSearch.Text.Length > 0 && textBlock.Text.Length > 0)
            {
                Color currenColorHex = (Color)Application.Current.Resources["PhoneAccentColor"];
                BoldText(ref textBlock, valueSearch.Text,currenColorHex);
            }
        }

        public static void BoldText(ref TextBlock tb, string partToBold, Color color)
        {
            string Text = tb.Text;
            tb.Inlines.Clear();

            Run r = new Run();
            r.Text = Text.Substring(0, Text.IndexOf(partToBold));
            tb.Inlines.Add(r);

            r = new Run();
            r.Text = partToBold;
            r.FontWeight = FontWeights.Bold;
            r.Foreground = new SolidColorBrush(color);
            tb.Inlines.Add(r);

            r = new Run();
            r.Text = Text.Substring(Text.IndexOf(partToBold) + partToBold.Length, Text.Length - (Text.IndexOf(partToBold) + partToBold.Length));
            tb.Inlines.Add(r);
        }

        private void valueSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            //ApplicationBar.IsVisible = true;

        }

        private void valueSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            ApplicationBar.IsVisible = false;
        }



        private void OnItemSelected(int obj)
        {   
            Dispatcher.BeginInvoke( () => {
                NavigationService.Navigate(new Uri("/DetailsPage.xaml?selectedItemSearch=" + obj, UriKind.Relative));
            });
        }

        private void OnFavItemSelected(int obj)
        {
            Dispatcher.BeginInvoke(() =>
            {
                NavigationService.Navigate(new Uri("/DetailsPage.xaml?selectedItemFavoriteSearch=" + obj, UriKind.Relative));
            });
        }

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/settings.xaml", UriKind.Relative));
        }

        private void deleteTaskButtonresult_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult m = MessageBox.Show("This setup sheet, plus any information it contains, will be deleted.", "Delete this sheet?", MessageBoxButton.OKCancel);

            if (m == MessageBoxResult.OK)
            {
                var button = sender as Button;

                if (button != null)
                {
                    // Get a handle for the to-do item bound to the button.
                    ToDoItem toDoForDeleteSR = button.DataContext as ToDoItem;
                    App.ViewModel.DeleteToDoItemSR(toDoForDeleteSR);
                    //App.ViewModel.DeleteToDoItem(toDoForDelete);
                }
                this.Focus();
            }
        }
    }
}
