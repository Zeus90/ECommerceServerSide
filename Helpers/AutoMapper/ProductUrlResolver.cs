using AutoMapper;
using Core.Models;
using ECommerceServerSide.Dtos;

namespace ECommerceServerSide.Helpers.AutoMapper
{
    public class ProductUrlResolver : IValueResolver<Product, ProductDto, string>
    {
        private readonly IConfiguration _config;

        public ProductUrlResolver(IConfiguration config)
        {
            this._config = config;
        }
        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            return _config["ApiUrl"] + source.PictureUrl;
        }
    }
}
