namespace Project.DotNet.Core.Api.Entity
{
    public class Product
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual decimal Price { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}
