using KliensoldaliHf_GTAYJ0.Model;
using KliensoldaliHf_GTAYJ0.Serives;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace KliensoldaliHf_GTAYJ0.ViewModel
{
    
    public class BookDetailsViewModel : ViewModelBase //Viewmodel for Book Details view
    {
        private Book book;
        public Book Book { get { return book; }  //public property for binding
            set
            {
                book = value;
                OnPropertyChanged(nameof(Book));
            }
        }

        public ICommand BackCommand { get; } //command for navigate back to Book List view
        public BookDetailsViewModel(INavigation navigation, string bookUrl) : base(navigation)
        {
            loadBookAsync(bookUrl); //load book objects
            BackCommand = new Command(BackCommandExecute);
        }

        public async void loadBookAsync(string Url)
        {
            var b = await BookService.Instance.GetBookAsync(Url); //get all books
            if (b != null)
            {
                if (b.Name.Equals("")) b.Name = "?"; //there is no name property for book --> ?
                //load character objects
                b.characterNames = new ObservableCollection<Character>(); 
                foreach (var c in b.characters)
                {
                    var character = await CharacterService.Instance.GetCharacterAsync(c);
                    if (character != null)
                    {
                        var newchar = character;
                        b.characterNames.Add(newchar);
                    }
                }
                var newBook = b;
                Book = newBook;
            }
        }

        //navigate back to book list view
        private async void BackCommandExecute()
        {
            await Navigation.PushAsync(new BookList(), true);
        }
        public override void OnAppearing()
        {
            base.OnAppearing();
            OnPropertyChanged(nameof(Book));
        }
    }
}
