using KliensoldaliHf_GTAYJ0.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace KliensoldaliHf_GTAYJ0
{
    public class Character
    {
            public string Url { get; set; }
            public string Name { get; set; }
            public string gender { get; set; }
            public string culture { get; set; }
            public string born { get; set; }
            public string died { get; set; }
            public List<string> titles { get; set; }
            public List<string> aliases { get; set; }
            public string father { get; set; }
            public Character FatherChar { get; set; }   
                public string mother { get; set; }
            public Character MotherChar { get; set; }
            public string spouse { get; set; }
            public Character SpouseChar { get; set; }
            public List<string> allegiances { get; set; }
            public ObservableCollection<House> AllegiancesList { get; set; }
            public List<string> books { get; set; }
            public ObservableCollection<Book> BookList { get; set; }
            public List<string> povBooks { get; set; }
            public ObservableCollection<Book> PovBookList { get; set; }
            public List<string> tvSeries { get; set; }
            public List<string> playedBy { get; set; }
        }
}
