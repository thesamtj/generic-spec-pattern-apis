using spec_generic_repo_pattern_api.Entity;

namespace spec_generic_repo_pattern_api.Specifications
{
    public class ProductByNamespec : BaseSpecification<Product>
    {
        public ProductByNamespec(string proudctName)
            : base(x => x.ProductName.Contains(proudctName))
        {

        }
    }
}
