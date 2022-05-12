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
    public class CharacterDetailsViewModel :ViewModelBase
    {
        private Character character;
        public Character Character { get { return character; }
                                        set { character = value;
                                            OnPropertyChanged(nameof(Character)); } }

        public ICommand BackCommand { get; }
        public CharacterDetailsViewModel(INavigation navigation, string charUrl) : base(navigation)
        {
            loadCharacterAsync(charUrl);
            BackCommand = new Command(BackCommandExecute);
            
        }
        public async void loadCharacterAsync(string charUrl) //load one character
        {
            var c = await CharacterService.Instance.GetCharacterAsync(charUrl); //get character by url
            if(c!= null)
            {
                if (c.Name.Equals("")) c.Name = "?";  //there is no name property for character --> ?
                //load Father
                if (!c.father.Equals(""))
                {
                    var father = await CharacterService.Instance.GetCharacterAsync(c.father); //get father character
                    if (father != null)
                    {
                        if (father.Name.Equals("")) father.Name = "?";
                        var newFather = father;
                        c.FatherChar = newFather;

                    }
                }
                //loadMother
                if (!c.mother.Equals(""))
                {
                    var mother = await CharacterService.Instance.GetCharacterAsync(c.mother); //get mother caharcter
                    if (mother != null)
                    {
                        if (mother.Name.Equals("")) mother.Name = "?";
                        var newMother = mother;
                        c.MotherChar = newMother;

                    }
                }

                //load Allegiances
                c.AllegiancesList= new ObservableCollection<House>();
                foreach (var h in c.allegiances)
                {
                    var allegianceHouse = await HouseService.Instance.GetHouseAsync(h); //get all allegiance houses
                    if (allegianceHouse != null)
                    {
                        var newHouse = allegianceHouse;
                        c.AllegiancesList.Add(newHouse);
                    }
                }
                //load Books
                c.BookList = new ObservableCollection<Book>();
                foreach(var b in c.books)
                {
                    var books = await BookService.Instance.GetBookAsync(b); //get all books
                    if(books != null)
                    {
                        var newBook = books;
                        c.BookList.Add(newBook);
                    }
                }

                var newChar = c;
                Character = newChar;
            }
        }
        
        //navigate back to character list
        private async void BackCommandExecute()
        {
            await Navigation.PushAsync(new CharacterList(), true);
        }


        public override void OnAppearing()
        {
            base.OnAppearing();
            OnPropertyChanged(nameof(Character));
        }
    }
}
