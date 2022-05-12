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
    public partial class CharacterDetails : ContentPage
    {
        public CharacterDetails(string selectedItem)
        {
            InitializeComponent();
            this.BindingContext = new CharacterDetailsViewModel(Navigation, selectedItem);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (this.BindingContext as CharacterDetailsViewModel).OnAppearing();
        }
        //navigate to Book Details page
        private async void HandleBookItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedItem = e.Item as Book;
            await Navigation.PushAsync(new BookDetails(selectedItem.Url));
            ((ListView)sender).SelectedItem = null;
        }
        //navigate to House Details page
        private async void HandleHouseItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedItem = e.Item as House;
            await Navigation.PushAsync(new HouseDetails(selectedItem.url));
            ((ListView)sender).SelectedItem = null;
        }

        //navigate to Character Details page
        private async  void HandleCharacterTapped(object sender, EventArgs e)
        {
            var item = ((TappedEventArgs)e).Parameter as string;
            await Navigation.PushAsync(new CharacterDetails(item));

        }
    }
    
}