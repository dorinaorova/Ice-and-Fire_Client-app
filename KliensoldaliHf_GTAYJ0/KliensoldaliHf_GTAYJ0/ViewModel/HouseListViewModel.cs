using KliensoldaliHf_GTAYJ0.Model;
using KliensoldaliHf_GTAYJ0.Serives;
using KliensoldaliHf_GTAYJ0.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace KliensoldaliHf_GTAYJ0.ViewModel
{
    public class HouseListViewModel :ViewModelBase
    {
        private ObservableCollection<House> houses;
        public ObservableCollection<House> Houses
        {
            get { return houses; }
            set
            {
                houses = value;
                OnPropertyChanged(nameof(Houses));
            }
        }
        //navigate to character list
        public ICommand CharacterCommand { get; }
        //navigate to book list
        public ICommand BookCommand { get; }
        public HouseListViewModel(INavigation navigation) : base(navigation)
        {
            loadHousesAsync();
            CharacterCommand = new Command(CharacterCommandExecute);
            BookCommand = new Command(BookCommandExecute);
        }
        //load house list
        public async void loadHousesAsync()
        {
            var list = await HouseService.Instance.GetHouses(); //get all houses

            var houseList = new ObservableCollection<House>();
            foreach (var house in list)
            {
                if (house.name.Equals("")) house.name = "?";
                houseList.Add(house);
            }
            Houses = houseList;
        }
        public override void OnAppearing()
        {
            base.OnAppearing();
            OnPropertyChanged(nameof(Houses));
        }
        //navigate to character list view
        private async void CharacterCommandExecute()
        {
            await Navigation.PushAsync(new CharacterList(), true);
        }
        //navigate to book list view
        private async void BookCommandExecute()
        {
            await Navigation.PushAsync(new BookList(), true);
        }

    }
}
