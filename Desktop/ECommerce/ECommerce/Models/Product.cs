namespace ECommerce.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public int StockQuantity { get; set; }

    public Category Category { get; set; }
    public int CategoryId { get; set; }

    public virtual ICollection<Reviews> Reviews { get; set; }
    public virtual ICollection<Order> Orders { get; set; }

    public Product()
    {
        Reviews = new List<Reviews>();
        Orders = new List<Order>();
    }


}
