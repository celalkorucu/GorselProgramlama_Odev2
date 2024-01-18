using Gorsel_programalama_odev_iki.RateModel;
using Gorsel_programalama_odev_iki.Services;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Globalization;

namespace Gorsel_programalama_odev_iki;

public partial class Rate : ContentPage
{


    ObservableCollection<RateItem> veriListesi;
    public ObservableCollection<RateItem> RateItems { get; set; }
    public ObservableCollection<RateItem> SalesItems { get; set; }
    public ObservableCollection<RateItem> ChangesItems { get; set; }
    public ObservableCollection<RateItem> YonItems { get; set; }

    




    public Rate()
	{
		InitializeComponent();


        GetList();

        BindingContext = this; 







    }

    public async Task GetList()
    {


        Root root =await GetRates();

        RateItems = new ObservableCollection<RateItem>
        {
            new RateItem { Buying = root.USD.alis},
            new RateItem { Buying =  root.EUR.alis},
            new RateItem { Buying = root.GBP.alis},
            new RateItem { Buying = root.GA.alis},
            new RateItem { Buying = root.C.alis},
            new RateItem { Buying = root.GAG.alis},
            new RateItem { Buying = root.BTC.alis},
            new RateItem { Buying = root.ETH.alis},
            new RateItem { Buying = root.XU100.alis}


        };

        buyingGrid.ItemsSource = RateItems;


        SalesItems = new ObservableCollection<RateItem>
        {
            new RateItem { Sales = root.USD.satis},
            new RateItem { Sales = root.EUR.satis },
            new RateItem { Sales = root.GBP.satis},
            new RateItem { Sales = root.GA.satis},
            new RateItem { Sales = root.C.satis},
            new RateItem { Sales = root.GAG.satis},
            new RateItem { Sales = root.BTC.satis},
            new RateItem { Sales = root.ETH.satis},
            new RateItem { Sales = root.XU100.satis}


        };
        Console.WriteLine("Satýs : "+root.USD.satis);
        salesGrid.ItemsSource = SalesItems;


        ChangesItems = new ObservableCollection<RateItem>
        {
             new RateItem { Change = root.USD.degisim},
            new RateItem { Change = root.EUR.degisim },
            new RateItem { Change = root.GBP.degisim},
            new RateItem { Change = root.GA.degisim},
            new RateItem { Change = root.C.degisim},
            new RateItem { Change = root.GAG.degisim},
            new RateItem { Change = root.BTC.degisim},
            new RateItem { Change = root.ETH.degisim},
            new RateItem { Change = root.XU100.degisim}


        };
        changeGrid.ItemsSource = ChangesItems;


        YonItems = new ObservableCollection<RateItem>
        {
               new RateItem { Yon = root.USD.d_yon},
            new RateItem { Yon = root.EUR.d_yon },
            new RateItem { Yon = root.GBP.d_yon},
            new RateItem { Yon = root.GA.d_yon},
            new RateItem { Yon = root.C.d_yon},
            new RateItem { Yon = root.GAG.d_yon},
            new RateItem { Yon = root.BTC.d_yon},
            new RateItem { Yon = root.ETH.d_yon},
            

        };
      

        yonGrid.ItemsSource = YonItems;


    }

    public async Task<Root> GetRates()
	{

		try
		{
            string json = await RateService.GetAltinDovizGuncelKurlar();
            Console.WriteLine(json);
            if (!string.IsNullOrEmpty(json))
            {
                Root root = JsonConvert.DeserializeObject<Root>(json);
                Console.WriteLine(json);
                
                return root;

				
			}
			else
			{
				Console.WriteLine("json null");
			}
        }
        catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
		
		
		return null;
	}
}

