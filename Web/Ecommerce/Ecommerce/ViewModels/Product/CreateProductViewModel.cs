namespace Ecommerce.ViewModels.Product
{
    public class CreateProductViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public byte[] Image { get; set; }
        public DateTime AddedDate { get; set; }
        public int CategoryId { get; set; }
    }
}
