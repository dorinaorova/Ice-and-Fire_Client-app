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
    public partial class CharacterList : ContentPage
    {
        public CharacterList()
        {
            InitializeComponent();
            this.BindingContext = new CharacterListViewModel(Navigation);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            (this.BindingContext as CharacterListViewModel).OnAppearing();
        }
        //navigate to Character Details page
        private async void HandleItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedItem = e.Item as Character;
            await Navigation.PushAsync(new CharacterDetails(selectedItem.Url));
            ((ListView)sender).SelectedItem = null;
        }
    }
}