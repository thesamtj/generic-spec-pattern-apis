using spec_generic_repo_pattern_api.Entity;

namespace spec_generic_repo_pattern_api.Specifications
{
    public class Productsbynameorderbydescsepc : BaseSpecification<Product>
    {
        public Productsbynameorderbydescsepc(string name)
            : base(x => x.ProductName.Contains(name))
        {
            ApplyOrderByDescending(x => x.ProductName);
        }
    }
}
