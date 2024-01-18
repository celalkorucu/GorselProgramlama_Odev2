using Gorsel_programalama_odev_iki.NewsModel;
using Gorsel_programalama_odev_iki.Services;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace Gorsel_programalama_odev_iki;

public partial class News : ContentPage
{

    public ObservableCollection<NewsItem> FilteredNewsItems { get; set; }

    public News()
	{
		InitializeComponent();

        FilteredNewsItems = new ObservableCollection<NewsItem>();

        Category defaultCategory = new Category();
        Color selectButtonColor = Color.FromHex("#808080");
        MansetButton.BackgroundColor = selectButtonColor;

        //Default olarak manþet kategorisi için
        defaultCategory.Tittle = "Manþet";
        defaultCategory.Link = "https://www.trthaber.com/manset_articles.rss";

        GetRoot(defaultCategory);

        BindingContext = this;
        

        newsListView.ItemsSource = FilteredNewsItems;
	}

    //Haberimizin getirildiði metod
    public async Task GetRoot(Category category)
    {
        try
        {
            Root root = await NewsService.GetNews(category);
            if (root != null)
            {

                FilteredNewsItems.Clear();
                foreach (var news in root.items)
                {

                    FilteredNewsItems.Add(new NewsItem
                    {
                        Title = news.title,
                        ImageUrl = news.enclosure.link,
                        PubDate = news.pubDate,
                        Author = news.author
                    }); ; 
                }

            }
            else
            {
                Console.WriteLine("Haber getirilirken hata meydana geldi");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Hata : {ex.Message}");
        }
    }

    private void CategoryButton_Clicked(object sender, EventArgs e)
    {
        if (sender is Button clickedButton)
        {
            string categoryText = clickedButton.Text;


            listColorFix();
            
            Color selectButtonColor = Color.FromHex("#808080");
            clickedButton.BackgroundColor = selectButtonColor; 
            
           
           

            Category selectCategory = new Category();

            //Seçilen kategoriyi bulan kod
            for(int i = 0; i<Category.CategoryList.Count; i++)
            {
                if (Category.CategoryList[i].Tittle == categoryText)
                {
                    selectCategory.Tittle = Category.CategoryList[i].Tittle;
                    selectCategory.Link = Category.CategoryList[i].Link;
                }
            }
            //Þeçim yaptýktan sonra listeyi yenilemek içinn
            GetRoot(selectCategory);
        }
    }


    public void listColorFix()
    {


        Color buttonColor = Color.FromHex("#CCCCCC");

        MansetButton.BackgroundColor = buttonColor;
        EkonomiButton.BackgroundColor = buttonColor;
        GundemButton.BackgroundColor = buttonColor;

        EgitimButton.BackgroundColor = buttonColor;

        SporButton.BackgroundColor = buttonColor;
        BilimButton.BackgroundColor = buttonColor;
        SonDakikaButton.BackgroundColor = buttonColor;
        GuncelButton.BackgroundColor = buttonColor;






    }
}