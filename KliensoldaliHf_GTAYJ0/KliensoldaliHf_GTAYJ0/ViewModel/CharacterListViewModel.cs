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
    public  class CharacterListViewModel :ViewModelBase
    {
        private ObservableCollection<Character> characters;
        public ObservableCollection<Character> Characters
        {
            get { return characters; }
            set
            {
                characters = value;
                OnPropertyChanged(nameof(Characters));
            }
        }
        //navigate to book list
        public ICommand BookCommand { get; }
        //navigate to house list
        public ICommand HouseCommand { get; }
        public CharacterListViewModel(INavigation navigation) : base(navigation)
        {
            loadCharactersAsync(); //load all characters
            BookCommand = new Command(BookCommandExecute);
            HouseCommand = new Command(HouseCommandExecute);
        }
        public async void loadCharactersAsync()
        {
            var list = await CharacterService.Instance.GetCharacters(); //get all characters

            var characterList = new ObservableCollection<Character>();
            foreach (var c in list)
            {
                if (c.Name.Equals("")) c.Name = "?";
                characterList.Add(c);
            }
            Characters = characterList;
        }
        //navigate to book lost view
        private async void BookCommandExecute(object obj)
        {
            await Navigation.PushAsync(new BookList(), true);
        }
        //navigate to house list view
        private async void HouseCommandExecute(object obj)
        {
            await Navigation.PushAsync(new HouseList(), true);
        }

        public override void OnAppearing()
        {
            base.OnAppearing();
            OnPropertyChanged(nameof(Characters));
        }

    }
}
