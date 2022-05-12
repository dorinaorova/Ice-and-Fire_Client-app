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
    public partial class HouseDetails : ContentPage
    {
        public HouseDetails(string house)
        {
            InitializeComponent();
            this.BindingContext = new HouseDetailsViewModel(Navigation, house);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (this.BindingContext as HouseDetailsViewModel).OnAppearing();
        }
        //navigate to Character Details page
        private async void HandleCharacterTapped(object sender, EventArgs e)
        {
            var item = ((TappedEventArgs)e).Parameter as string;
            await Navigation.PushAsync(new CharacterDetails(item));

        }
        //naviagte to Character Details page from listview
        private async void HandleCharacterItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedItem = e.Item as Character;
            await Navigation.PushAsync(new CharacterDetails(selectedItem.Url));
            ((ListView)sender).SelectedItem = null;
        }
    }
}