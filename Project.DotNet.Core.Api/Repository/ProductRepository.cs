using Microsoft.Extensions.Configuration;
using Project.DotNet.Core.Api.Entity;

namespace Project.DotNet.Core.Api.Repository
{
    public class ProductRepository : RepositoryBase<Product>
    {
        public ProductRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
