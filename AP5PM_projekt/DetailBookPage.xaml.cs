using JikanDotNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AP5PM_projekt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailBookPage : ContentPage
    {
        //full properta pro ID knihy, na kterou se detailní stránka načte
        private long detailID;
        public long DetailID { get => detailID; set => detailID = value; }

        //konstruktor
        public DetailBookPage(long id)
        {
            this.DetailID = id;
            InitializeComponent();
            Title = "Book Detail";
            //((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.Orange;
            //((NavigationPage)Application.Current.MainPage).BarTextColor = Color.White;
            _ = GetMangaDetail();
        }

        //metoda, která při stisknutí tlačítka vrátí uživatele zpět na hlavní stránku
        private async void NavigateButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        //metoda, která načte detailní data o knize podle jejího ID
        public async Task GetMangaDetail()
        {
            IJikan jikan = new Jikan(true);

            Manga mangaDetail = await jikan.GetManga(DetailID);
            Debug.WriteLine(mangaDetail.Title);

            ModelDetail md = new ModelDetail();
            long id = mangaDetail.MalId;
            string title = mangaDetail.Title;
            string imageURL = mangaDetail.ImageURL;
            string synopsis = mangaDetail.Synopsis;
            string type = mangaDetail.Type;
            ICollection<MALSubItem> autor = mangaDetail.Authors;
            ICollection<MALSubItem> genre = mangaDetail.Genres;

            md.ID = id;
            md.Title = title;
            md.Image_URL = imageURL;
            md.Synopsis = synopsis;
            md.Type = type;
            foreach(var v in autor)
            {
                md.Authors = v.Name;
            }
            foreach (var v in genre)
            {
                md.Genre = v.Name;
            }

            testDetail.BindingContext = md;
        }
    }
}