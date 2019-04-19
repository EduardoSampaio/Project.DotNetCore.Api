using Dapper.FluentMap.Dommel.Mapping;
using Project.DotNet.Core.Api.Entity;

namespace Project.DotNet.Core.Api.Mapping
{
    public class CategoryMap : DommelEntityMap<Category>
    {
        public CategoryMap()
        {
            ToTable("CATEGORIES");
            Map(X => X.Id).ToColumn("CategoryId");
            Map(x => x.Name).ToColumn("NAME");
        }
    }
}
