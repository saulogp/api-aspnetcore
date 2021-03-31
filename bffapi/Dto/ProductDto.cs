namespace bffapi.Dto
{
    public class ProductDto
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Provider Provider { get; set; }
    }
}
