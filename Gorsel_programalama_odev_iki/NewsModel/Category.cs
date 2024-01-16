using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gorsel_programalama_odev_iki.NewsModel
{
    public class Category
    {

        public string Tittle { get; set; }
        public string Link { get; set; }

        public static List<Category> CategoryList = new List<Category>()
        {
            new Category() { Tittle = "Manşet", Link = "https://www.trthaber.com/manset_articles.rss"},
            new Category() { Tittle = "Son Dakika", Link = "https://www.trthaber.com/sondakika_articles.rss"},
            new Category() { Tittle = "Gündem", Link = "https://www.trthaber.com/gundem_articles.rss"},
            new Category() { Tittle = "Ekonomi", Link = "https://www.trthaber.com/ekonomi_articles.rss"},
            new Category() { Tittle = "Spor", Link = "https://www.trthaber.com/spor_articles.rss"},
            new Category() { Tittle = "Bilim Teknoloji", Link = "https://www.trthaber.com/bilim_teknoloji_articles.rss"},
            new Category() { Tittle = "Güncel", Link = "https://www.trthaber.com/guncel_articles.rss"},
            new Category() { Tittle = "Eğitim", Link = "https://www.trthaber.com/egitim_articles.rss"},
        };

    }
}
