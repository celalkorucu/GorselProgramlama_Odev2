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
        
        defaultCategory.Tittle = "Man�et";
        defaultCategory.Link = "https://www.trthaber.com/manset_articles.rss";

        GetRoot(defaultCategory);

        BindingContext = this;
        

        newsListView.ItemsSource = FilteredNewsItems;
	}

    public async Task GetRoot(Category category)
    {
        try
        {
            Root root = await NewsService.GetNews(category);
            if (root != null)
            {
                Console.WriteLine("Status: " + root.status);
                // Burada root nesnesinin i�indeki di�er �zelliklere eri�ebilirsiniz.

                FilteredNewsItems.Clear();
                foreach (var news in root.items)
                {

                    FilteredNewsItems.Add(new NewsItem
                    {
                        Title = news.title,
                        ImageUrl = news.enclosure.link,
                        PubDate = news.pubDate,
                        Author = news.author
                        // �htiyaca g�re di�er �zellikleri ekleyebilirsiniz
                    }); ; 
                }

            }
            else
            {
                Console.WriteLine("Failed to fetch news.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private void CategoryButton_Clicked(object sender, EventArgs e)
    {
        if (sender is Button clickedButton)
        {
            string categoryText = clickedButton.Text;


            clickedButton.BackgroundColor = Colors.Red; // De�i�tirmek istedi�iniz rengi kullan�n
           
           
            // Di�er d��mlerin arka plan rengini varsay�lan renge geri y�kleyin
           

            Category selectCategory = new Category();

            for(int i = 0; i<Category.CategoryList.Count; i++)
            {
                if (Category.CategoryList[i].Tittle == categoryText)
                {
                    selectCategory.Tittle = Category.CategoryList[i].Tittle;
                    selectCategory.Link = Category.CategoryList[i].Link;
                }
            }
            //DisplayAlert("Kategori Se�ildi", $"Se�ilen Kategori: {categoryText}", "Tamam");
            
            GetRoot(selectCategory);
        }
    }
}