namespace Ecommerce.Domain.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public byte[] ImageUrl { get; set; }
    public DateTime AddedDate { get; set; }

    public virtual OrderItem OrderItem { get; set; }
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }
}