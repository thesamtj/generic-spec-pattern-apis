using spec_generic_repo_pattern_api.Entity;

namespace spec_generic_repo_pattern_api.Specifications
{
    public class Productsbynameorderbypagingsepc : BaseSpecification<Product>
    {
        public Productsbynameorderbypagingsepc(string name, int pageNumber, int pageSize)
            : base(x => x.ProductName.Contains(name))
        {
            ApplyOrderBy(x => x.ProductName);
            ApplyPaging(pageNumber, pageSize);

        }
    }
}
