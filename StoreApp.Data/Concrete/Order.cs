public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public string Name { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string AdressLine { get; set; } = null!;
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>(); 
}

public class OrderItem
{
    public int Id { get; set; }
    public int OrderId { get; set; }           // FK
    public int ProductId { get; set; }
    public decimal Price { get; set; }         // para: decimal
    public int Quantity { get; set; }
    public Order Order { get; set; } = null!;
}
