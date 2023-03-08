using Stor.Models;

namespace Blog.Models
{
    public class product
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? price { get; set; }
        public int? categoryId { get; set; }
        public Category? Category { get; set; }
    }
}