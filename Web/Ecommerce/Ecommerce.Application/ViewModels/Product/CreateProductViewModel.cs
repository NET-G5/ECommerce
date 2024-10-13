using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Application.ViewModels.Product
{
    public class CreateProductViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        [Required]
        public byte[] ImageUrl { get; set; }
        public DateTime AddedDate { get; set; }
        public int CategoryId { get; set; }
    }
}
