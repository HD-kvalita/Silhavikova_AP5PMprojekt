using JikanDotNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AP5PM_projekt
{
    public partial class MainPage : ContentPage
    {
        public long MangaID { get; set; }
        public string HledanaManga { get; set; }
        List<Model> Models = new List<Model>();

        //konstruktor
        public MainPage()
        {
            InitializeComponent();
            Title = "Search Page";
            //_ = GetMangaSearch(); //_ = asynchronní metoda
        }

        //metoda, která otevře detail písničky při stisknutí tlačítka na hlavní stránce
        private async void NavigateButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DetailBookPage(MangaID));
        }

        //metoda, která přepne na detail knihy, pokud na ni uživatel klikne
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (Model)e.SelectedItem;

            await Navigation.PushAsync(new DetailBookPage(item.ID));
        }

        //metoda spouštěná změnou textu v SearchBaru
        private async void OnTextChanged(object sender, EventArgs e)
        {
            SearchBar searchBar = (SearchBar)sender;
            //Debug.WriteLine(searchBar.Text);
            await Task.Delay(5000);
            HledanaManga = searchBar.Text;
            _ = GetMangaSearch();
        }

        //metoda, která načte data dle výsledku vyhledávání
        public async Task GetMangaSearch()
        {
            IJikan jikan = new Jikan();

            if (HledanaManga.Length > 3)
            {
                MangaSearchResult mangaSearchResult = await jikan.SearchManga(HledanaManga); //zavolám vyhledávací funkci na mangu 
                List<MangaSearchEntry> entries = mangaSearchResult.Results.ToList(); //převedu výstup na List, protože přes ICollection nejde for cyklus

                for (int i = 0; i < entries.Count; i++)
                {
                    // Debug.WriteLine(entries[i].Title); //vypíšu všechny názvy 
                    Model m = new Model();
                    long id = entries[i].MalId;
                    string title = entries[i].Title;
                    string type = entries[i].Type;
                    string imageurl = entries[i].ImageURL;

                    m.ID = id;
                    m.Title = title;
                    m.Type = type;
                    m.Image_URL = imageurl;
                    Models.Add(m);
                }

                testListView.ItemsSource = Models;
            }
        }
    }
}
