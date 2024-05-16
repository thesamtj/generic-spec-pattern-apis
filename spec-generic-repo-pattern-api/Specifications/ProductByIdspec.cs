﻿using spec_generic_repo_pattern_api.Entity;

namespace spec_generic_repo_pattern_api.Specifications
{
    public class ProductByIdspec : BaseSpecification<Product>
    {
        public ProductByIdspec(int id) : base(x => x.ProductId == id)
        {

        }
    }
}
