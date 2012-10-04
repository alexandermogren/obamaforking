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

namespace RCmechanics
{
    public partial class EditSheet : PhoneApplicationPage
    {
        public EditSheet()
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            string selectedIndex = ID.Text;
            
            if (NavigationContext.QueryString.TryGetValue("selectedItem", out selectedIndex))
            {
                int index = int.Parse(selectedIndex);
                DataContext = App.ViewModel.AllToDoItems[index];
            }
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            var ItemID = int.Parse(ID.Text);
            IQueryable<ToDoItem> editQuery = from c in App.ViewModel.toDoDB.Items where c.ToDoItemId == ItemID select c;

            ToDoItem itemToUpdate = editQuery.FirstOrDefault();

            // update the city by changing its name
            itemToUpdate.ItemDriver = Driver.Text;
            itemToUpdate.ItemCity = City.Text;
            itemToUpdate.ItemCountry = Country.Text;
            itemToUpdate.ItemEventDate = Date.Text;
            itemToUpdate.ItemEvent = Event.Text;

            // save changes to the database
            App.ViewModel.SaveChangesToDB();

            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }

    }
}