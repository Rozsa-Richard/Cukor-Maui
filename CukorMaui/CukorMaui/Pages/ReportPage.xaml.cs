namespace CukorMaui.Pages;

public partial class ReportPage : ContentPage
{
    public FileService Service { get; }
    public ReportPage(FileService fileService)
	{
		InitializeComponent();
        Service = fileService;
        mostSold.Text = Service.MostSoldCandy();
        income.Text = Service.AllIncome();
    }

    private void SaveToCsv(object sender, EventArgs e)
    {
        Service.WriteCandyFile();
        Service.WriteSaleFile();
        DisplayAlert("Info", "Mentés sikeresen befejezõdött", "Ok");
    }
}