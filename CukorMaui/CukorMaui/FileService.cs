using CukorMaui.Models;
using System.Collections.ObjectModel;

namespace CukorMaui
{
    public class FileService
    {
        public static FileService Instance { get; private set; }
        public FileService()
        {
            Instance = this;
        }
        public ObservableCollection<Candy> Candies { get; set; } = new ObservableCollection<Candy>();
        public ObservableCollection<Sale> Sales { get; set; } = new ObservableCollection<Sale>();
        public void ReadCandyFile()
        {
            var candyRows = File.ReadLines("candy.csv");

            foreach (var row in candyRows.Skip(1))
            {
                var data = row.Split(',');
                Candies.Add(new Candy
                {
                    Id = int.Parse(data[0]),
                    Name = data[1],
                    Price = int.Parse(data[2]),
                    Stock = int.Parse(data[3]),
                });
            }
        }
        public void ReadSaleFile()
        {
            var saleRows = File.ReadLines("sale.csv");

            foreach (var row in saleRows.Skip(1))
            {
                var data = row.Split(",");
                Sales.Add(new Sale
                {
                    Id = int.Parse(data[0]),
                    CandyId = int.Parse(data[1]),
                    Quantity = int.Parse(data[2]),
                    Sum = int.Parse(data[3]),
                });
            }
        }
        public void WriteCandyFile()
        {
            var rows = new List<string>();
            rows.Add("Id,Name,Price,Stock");
            foreach (var item in Candies)
                rows.Add($"{item.Id},{item.Name},{item.Price},{item.Stock}");
            File.WriteAllLines("candy.csv", rows);
        }
        public void WriteSaleFile()
        {
            var rows = new List<string>();
            rows.Add("Id,CandyId,Quantity,Sum");
            foreach (var item in Sales)
                rows.Add($"{item.Id},{item.CandyId},{item.Quantity},{item.Sum}");
            File.WriteAllLines("sale.csv", rows);
        }
        public string MostSoldCandy()
        {
            var soldCandies = Sales.GroupBy(s => s.CandyId, s => s.Quantity, (id, q) => new { Id = id, Q = q.Sum() });
            var mostSold = soldCandies.FirstOrDefault(y => y.Q == soldCandies.Max(x => x.Q));
            return $"A legtöbbet eladott cukor: {Candies.FirstOrDefault(x => x.Id == mostSold.Id).Name ?? "Nem található"} amiből {mostSold.Q} db kelt el";
        }
        public void NotSoldCandies()
        {
            var soldCandies = Sales.Select(s => s.CandyId).Distinct().ToList();
            if (soldCandies.Count() == Candies.Count())
                Console.WriteLine("Minden cukorból adtunk el!");
            else
            {
                Console.Write("Nem eladott cukrok: ");
                //Candies.ForEach(c => { Console.Write(!soldCandies.Contains(c.Id) ? c.Name + " " : ""); });
                Console.WriteLine("");
            }
        }
        public string AllIncome() => $"Összes bevétel: {Sales.Sum(x => x.Sum)} Ft";
    }
}
