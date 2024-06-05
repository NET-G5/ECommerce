namespace ECommerce.Models;

public class Reviews
{
    public int Id { get; set; }
    public string Review { get; set; }

    public UserAccount UserAccount { get; set; }
    public int UserAccountId { get; set; }

    public Product Product { get; set; }
    public int ProductId { get; set; }
}
