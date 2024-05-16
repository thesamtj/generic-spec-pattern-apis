namespace expression_generic_repo_pattern_api.Entity
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }

        // Foreign key
        public int ProductId { get; set; }

        // Navigation property
        public Product Product { get; set; }


    }
}
