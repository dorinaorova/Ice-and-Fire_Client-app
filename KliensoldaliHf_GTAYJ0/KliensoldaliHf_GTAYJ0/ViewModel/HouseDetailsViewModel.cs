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
    public class HouseDetailsViewModel : ViewModelBase
    {
        private House house;
        public House House { 
            get { return house; } 
            set
            {
                house = value;
                OnPropertyChanged(nameof(House));
            }
        }
        //navigate back to house list
        public ICommand BackCommand { get; }
        public HouseDetailsViewModel(INavigation navigation, string url) : base(navigation)
        {
            loadHouseAsync(url);
            BackCommand = new Command(BackCommandExecute);
            
        }
        //load house list
        public async void loadHouseAsync(string url)
        {
            var h = await HouseService.Instance.GetHouseAsync(url); //get all houses
            if(h != null)
            {
                if (h.name.Equals("")) h.name = "?";
                //load current lord
                if (!h.currentLord.Equals(""))
                {
                    var lord = await CharacterService.Instance.GetCharacterAsync(h.currentLord); //get current lord character
                    if(lord != null)
                    {
                        if(lord.Name.Equals("")) lord.Name = "?";
                        var newLord = lord;
                        h.currentLorChar = newLord;
                    }
                }

                //load members
                h.swornMembersList = new ObservableCollection<Character>();
                foreach(var s in h.swornMembers)        //get all sworn member character
                {
                    var smember = await CharacterService.Instance.GetCharacterAsync(s); 
                    if(smember != null)
                    {
                        if(smember.Name.Equals("")) smember.Name = "?";
                        var newMember = smember;
                        h.swornMembersList.Add(newMember);
                    }
                }
                var newHouse = h;
                House = newHouse;
            }
        }
        //navigate back to house lsit view
        private async void BackCommandExecute()
        {
            await Navigation.PushAsync(new HouseList(), true);
        }
        public override void OnAppearing()
        {
            base.OnAppearing();
            OnPropertyChanged(nameof(House));
        }
    }
}

