using CukorMaui.Models;
using System.Collections.ObjectModel;

namespace CukorMaui
{
    public partial class MainPage : ContentPage
    {
        FileService fileService = new FileService();
        public ObservableCollection<Candy> Candies { get; set; } = new ObservableCollection<Candy>();
        public MainPage()
        {
            InitializeComponent();
            LoadCandy();
            BindingContext = this;
        }

        private void LoadCandy()
        {
            foreach (var item in fileService.ReadCandyFile())
            {
                Candies.Add(item);
            }
        }

        private void DeleteCandy(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button?.BindingContext is Candy candyToDelete)
            {
                Candies.Remove(candyToDelete);
            }
        }

        private void CreateCandy(object sender, EventArgs e)
        {
            var id = Candies.Max(x => x.Id)+1;
            var name = CandyName.Text;
            var price = CandyPrice.Text;
            var stock = CandyStock.Text;
            Candies.Add(new Candy
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
