using KliensoldaliHf_GTAYJ0.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KliensoldaliHf_GTAYJ0
{
    public partial class BookList : ContentPage
    {
        public BookList()
        {
            InitializeComponent();
            this.BindingContext = new BookListViewModel(Navigation); //binding - BookListViewModel
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            (this.BindingContext as BookListViewModel).OnAppearing();
        }

        //navigate to Book Details page
        private async void HandleItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedItem = e.Item as Book;
            await Navigation.PushAsync(new BookDetails(selectedItem.Url));
            ((ListView)sender).SelectedItem = null;
        }

    }
}
