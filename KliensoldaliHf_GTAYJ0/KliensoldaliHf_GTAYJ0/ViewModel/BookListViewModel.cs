using KliensoldaliHf_GTAYJ0.Model;
using KliensoldaliHf_GTAYJ0.Serives;
using KliensoldaliHf_GTAYJ0.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace KliensoldaliHf_GTAYJ0
{
    public class BookListViewModel : ViewModelBase
    {
        private ObservableCollection<Book> books;
        public ObservableCollection<Book> Books { get { return books; }
                                                  set { books = value;
                                                        OnPropertyChanged(nameof(Books));
                                                   } }

        public ICommand CharacterCommand { get; } //navigate to character list view
        public ICommand HouseCommand { get; }   //navigate to house list view
        public BookListViewModel(INavigation navigation) : base(navigation)
        {
            loadBooksAsync(); //load books
            CharacterCommand = new Command(CharacterCommandExecute);
            HouseCommand = new Command(HouseCommandExecute);
        }
        public async override void OnAppearing()
        {
            base.OnAppearing();
            OnPropertyChanged(nameof(Books));
        }
        public async void loadBooksAsync()
        {
            var list = await BookService.Instance.GetBooks(); //get all books

            var bookList = new ObservableCollection<Book>();
            foreach(var book in list)
            {
                if (book.Name == "") book.Name = "?";
                bookList.Add(book);
            }
            Books=bookList; 
        }

        //navigate to character list
        private async void CharacterCommandExecute()
        {
            await Navigation.PushAsync(new CharacterList(), true);
        }
        //navigate to character list
        private async void HouseCommandExecute()
        {
            await Navigation.PushAsync(new HouseList(), true);
        }


    }
}
