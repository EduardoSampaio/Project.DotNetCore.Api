using System.ComponentModel.DataAnnotations;

namespace Project.DotNet.Core.Api.Entity
{
    public class Category
    {

        public virtual int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public virtual string Name { get; set; }

        
    }
}
