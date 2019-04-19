using Dapper.FluentMap.Dommel.Mapping;
using Project.DotNet.Core.Api.Entity;

namespace Project.DotNet.Core.Api.Mapping
{
    public class ProductMap : DommelEntityMap<Product>
    {
        public ProductMap()
        {
            ToTable("PRODUCTS");
            Map(x => x.Id).ToColumn("ProductId");
            Map(x => x.Name).ToColumn("NAME");
            Map(x => x.CategoryId).ToColumn("CategoryId");
            Map(x => x.Price).ToColumn("PRICE");
        }
    }
}
