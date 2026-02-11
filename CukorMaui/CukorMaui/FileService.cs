using CukorMaui.Models;

namespace CukorMaui
{
    public class FileService
    {
        public List<Candy> ReadCandyFile()
        {
            var candyRows = File.ReadLines("candy.csv");
            var candys = new List<Candy>();

            foreach (var row in candyRows.Skip(1))
            {
                var data = row.Split(',');
                candys.Add(new Candy
                {
                    Id = int.Parse(data[0]),
                    Name = data[1],
                    Price = int.Parse(data[2]),
                    Stock = int.Parse(data[3]),
                });
            }
            return candys;
        }
        public List<Sale> ReadSaleFile()
        {
            var saleRows = File.ReadLines("sale.csv");
            var sales = new List<Sale>();

            foreach (var row in saleRows.Skip(1))
            {
                var data = row.Split(",");
                sales.Add(new Sale
                {
                    Id = int.Parse(data[0]),
                    CandyId = int.Parse(data[1]),
                    Quantity = int.Parse(data[2]),
                    Sum = int.Parse(data[3]),
                });
            }
            return sales;
        }
    }
}
