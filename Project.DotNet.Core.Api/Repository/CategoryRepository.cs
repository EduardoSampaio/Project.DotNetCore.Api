using Microsoft.Extensions.Configuration;
using Project.DotNet.Core.Api.Entity;

namespace Project.DotNet.Core.Api.Repository
{
    public class CategoryRepository : RepositoryBase<Category>
    {
        public CategoryRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
