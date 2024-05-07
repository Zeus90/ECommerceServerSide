using Core.Models;
using Core.Specifications;
using Infrastructure.Data.Repositorys;

namespace ECommerceServerSide.Helpers.Pagination
{
    public class ProductSpecsWithFilter : BaseSpecification<Product>
    {
        public ProductSpecsWithFilter(ProductSpecsParams specsParams)
            : base(x => (string.IsNullOrEmpty(specsParams.Search) || x.Name.ToLower().Contains(specsParams.Search)) &&
            (!specsParams.TypeId.HasValue || x.ProductTypeId == specsParams.TypeId) && (
            !specsParams.BrandId.HasValue || x.ProductBrandId == specsParams.BrandId))
        {
        }
    }
}
