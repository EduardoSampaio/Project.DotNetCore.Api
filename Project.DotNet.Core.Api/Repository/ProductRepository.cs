using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;
using Project.DotNet.Core.Api.Entity;

namespace Project.DotNet.Core.Api.Repository
{
    public class ProductRepository : RepositoryBase<Product>
    {
        private readonly string SQL_JOIN_PRODUCTS_CATEGORY = "select * from PRODUCTS p inner join CATEGORIES c on p.CategoryId = c.CategoryId ";

        public ProductRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public override IEnumerable<Product> GetAll()
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                return db.Query<Product, Category, Product>(SQL_JOIN_PRODUCTS_CATEGORY, (product, category) => new Product {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    CategoryId = product.CategoryId,
                    Category = category
                }, splitOn: "CategoryId");
            }
        }
    }
}
