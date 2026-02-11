using CukorMaui.Models;
using System.Collections.ObjectModel;

namespace CukorMaui.Pages;

public partial class SalePage : ContentPage
{
    FileService fileService = new FileService();
    public ObservableCollection<Candy> Candies { get; set; } = new ObservableCollection<Candy>();
    public ObservableCollection<Sale> Sales { get; set; } = new ObservableCollection<Sale>();
    public SalePage()
	{
		InitializeComponent();
        LoadCandy();
        BindingContext = this;

    }
    private void LoadCandy()
    {
        foreach (var item in fileService.ReadCandyFile())
            Candies.Add(item);
        foreach (var item in fileService.ReadSaleFile())
            Sales.Add(item);
    }

    private void DeleteSale(object sender, EventArgs e)
    {
        var button = sender as Button;
        if (button?.BindingContext is Sale saleToDelete)
            Sales.Remove(saleToDelete);
    }

    private void CreateSale(object sender, EventArgs e)
    {

    }
    private void OnCandyPickerChanged(object sender, EventArgs e)
    {
        var picker = sender as Picker;

        // A SelectedItem tartalmazza a TELJES Candy objektumot
        if (picker?.SelectedItem is Candy selectedCandy)
        {
            // Itt már hozzáférsz mindenhez:
            string nev = selectedCandy.Name;
            int keszlet = selectedCandy.Stock;

            DisplayAlert("Kiválasztva", $"A választottad: {nev} ({keszlet} db van készleten)", "OK");
        }
    }
}