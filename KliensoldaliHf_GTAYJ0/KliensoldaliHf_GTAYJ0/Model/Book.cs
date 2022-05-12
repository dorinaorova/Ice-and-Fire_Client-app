using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KliensoldaliHf_GTAYJ0.Model
{
    public class Book
    {
            public string Url { get; set; }
            public string Name { get; set; }
            public string Isbn { get; set; }
            public List<string> authors { get; set; }
            public int numberOfPages { get; set; }
            public string publisher { get; set; }
            public string country { get; set; }
            public string mediaType { get; set; }
            public DateTime released { get; set; }
            public List<string> characters { get; set; }
            public ObservableCollection<Character> characterNames { get; set; }
            public List<string> povCharacters { get; set; }
            public ObservableCollection<Character> PovCharacterList { get; set; }
    }

}
