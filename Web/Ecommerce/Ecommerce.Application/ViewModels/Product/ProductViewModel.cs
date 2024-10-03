namespace Ecommerce.Application.ViewModels.Product
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public byte[] ImageUrl { get; set; }
        public DateTime AddedDate { get; set; }
        public int CategoryId { get; set; }

    }
}
