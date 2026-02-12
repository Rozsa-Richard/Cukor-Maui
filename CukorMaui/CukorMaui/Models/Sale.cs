namespace CukorMaui.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public int CandyId { get; set; }
        public int Quantity { get; set; }
        public int Sum { get; set; }
        public string CandyName => FileService.Instance.Candies.FirstOrDefault(c => c.Id == CandyId)?.Name ?? "Ismeretlen édesség";
    }
}
