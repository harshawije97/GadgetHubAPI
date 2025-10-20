namespace Shared.DTO
{
    public class OrderCreateDto
    {
        public class OrderItemCreateDto
        {
            public Guid ProductId { get; set; }
            public int Quantity { get; set; }
            public decimal UnitPrice { get; set; }
        }
        public class OrderItemReadDto
        {
            public Guid ProductId { get; set; }
            public int Quantity { get; set; }
            public decimal UnitPrice { get; set; }
        }

        public Guid UserId { get; set; }
        public List<OrderItemCreateDto> Items { get; set; } = new();

        public class OrderReadDto
        {
            public Guid Id { get; set; }
            public DateTime OrderDate { get; set; }
            public string Status { get; set; } = string.Empty;
            public decimal TotalAmount { get; set; }
            public List<OrderItemReadDto> Items { get; set; } = new();
        }
    }
}
