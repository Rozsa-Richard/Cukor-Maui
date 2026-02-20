using CukorMaui.Models;

namespace CukorMaui.Pages;

public partial class EditPage : ContentPage
{
    public FileService Service { get; }
    public Candy Candy { get; set; }
    public EditPage(FileService fileService, Candy candy)
	{
		InitializeComponent();
        Service = fileService;
        Candy = candy;
        CandyName.Text = candy.Name;
        CandyPrice.Text = candy.Price.ToString();
        CandyStock.Text = candy.Stock.ToString();
    }

    private void ModifyCandy(object sender, EventArgs e)
    {
        Service.Candies.Add(new Candy {Id= Candy.Id, Name = CandyName.Text, Price = int.Parse(CandyPrice.Text), Stock = int.Parse(CandyStock.Text) });
        Service.Candies.Remove(Candy);
        Navigation.PopAsync();
    }
}