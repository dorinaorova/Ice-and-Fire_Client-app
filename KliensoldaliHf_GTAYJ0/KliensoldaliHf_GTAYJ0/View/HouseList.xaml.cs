using KliensoldaliHf_GTAYJ0.Model;
using KliensoldaliHf_GTAYJ0.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KliensoldaliHf_GTAYJ0.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HouseList : ContentPage
    {
        public HouseList()
        {
            InitializeComponent();
            this.BindingContext = new HouseListViewModel(Navigation);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            (this.BindingContext as HouseListViewModel).OnAppearing();
        }
        //naviagte to House Details page
        private async void HandleItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedItem = e.Item as House;
            await Navigation.PushAsync(new HouseDetails(selectedItem.url));
            ((ListView)sender).SelectedItem = null;
        }
    }
}