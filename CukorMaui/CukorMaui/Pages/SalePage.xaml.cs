using CukorMaui.Models;

namespace CukorMaui.Pages;

public partial class SalePage : ContentPage
{
    public FileService Service { get; }
    Candy ?selectedCandy = null;
    public SalePage(FileService fileService)
	{
		InitializeComponent();
        Service = fileService;
        BindingContext = Service;
    }

    private void DeleteSale(object sender, EventArgs e)
    {
        var button = sender as Button;
        if (button?.BindingContext is Sale saleToDelete)
            Service.Sales.Remove(saleToDelete);
    }

    private void CreateSale(object sender, EventArgs e)
    {
        if (selectedCandy != null)
        {
            int id = 1;
            if (Service.Sales.Count > 0)
                id = Service.Sales.Max(x => x.Id) + 1;
            int quantity = int.Parse(Quantiy.Text);
            Service.Sales.Add(new Sale
            {
                Id = id,
                CandyId = selectedCandy.Id,
                Quantity = quantity,
                Sum = quantity * selectedCandy.Price,
            });

            Quantiy.Text = string.Empty;
            selectedCandy = null;
            Picker.SelectedIndex = -1;
        }
        else
            DisplayAlert("Hiba", "Nem választottál cukrot", "ok");
    }
    private void OnCandyPickerChanged(object sender, EventArgs e)
    {
        var picker = sender as Picker;
        if (picker?.SelectedItem is Candy pickerCandy)
            selectedCandy = pickerCandy;
    }
}