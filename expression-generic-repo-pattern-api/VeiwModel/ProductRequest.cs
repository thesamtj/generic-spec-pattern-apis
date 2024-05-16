namespace expression_generic_repo_pattern_api.VeiwModel
{
    public class ProductRequest
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        //public List<OrderRequest>? Orders { get; set; } = new List<OrderRequest>();

    }
}
