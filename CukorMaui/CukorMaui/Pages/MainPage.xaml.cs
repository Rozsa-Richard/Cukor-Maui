using CukorMaui.Models;

namespace CukorMaui
{
    public partial class MainPage : ContentPage
    {
        public FileService Service { get; }
        public MainPage(FileService fileService)
        {
            InitializeComponent();
            Service = fileService;
            Service.ReadCandyFile();
            Service.ReadSaleFile();
            BindingContext = Service;
        }

        private void DeleteCandy(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button?.BindingContext is Candy candyToDelete)
            {
                Service.Candies.Remove(candyToDelete);
            }
        }

        private void CreateCandy(object sender, EventArgs e)
        {
            var id = 1;
            if (Service.Candies.Count > 0)
                id = Service.Candies.Max(x => x.Id) + 1;
            var name = CandyName.Text;
            var price = CandyPrice.Text;
            var stock = CandyStock.Text;
            Service.Candies.Add(new Candy
            {
                Id = id,
                Name = name, 
                Price = int.Parse(price),
                Stock = int.Parse(stock)
            });
            CandyName.Text = string.Empty;
            CandyPrice.Text = string.Empty;
            CandyStock.Text = string.Empty;
        }
    }
}
