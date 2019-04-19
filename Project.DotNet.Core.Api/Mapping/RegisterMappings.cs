using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using Microsoft.Extensions.DependencyInjection;

namespace Project.DotNet.Core.Api.Mapping
{
    public static class RegisterMappings
    {
        public static void RegisterMappingsDapper(this IServiceCollection services)
        {

            FluentMapper.Initialize(config =>
            {
                config.AddMap(new CategoryMap());
                config.AddMap(new ProductMap());
                config.ForDommel();
            });

        }
    }
}
