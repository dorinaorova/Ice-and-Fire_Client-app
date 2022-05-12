using KliensoldaliHf_GTAYJ0.Model;
using KliensoldaliHf_GTAYJ0.View;
using KliensoldaliHf_GTAYJ0.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KliensoldaliHf_GTAYJ0
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookDetails : ContentPage
    {
        public BookDetails(string book)
        {
            InitializeComponent();

            this.BindingContext = new BookDetailsViewModel(Navigation,book);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (this.BindingContext as BookDetailsViewModel).OnAppearing();
        }
        //navigate to Character Details page
        private async void HandleCharacterItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedItem = e.Item as Character;
            await Navigation.PushAsync(new CharacterDetails(selectedItem.Url));
            ((ListView)sender).SelectedItem = null;
        }
    }
}