using ECommerce.Core.Entities;// Using
using System.ComponentModel.DataAnnotations;


namespace ECommerce.Entities.Concrete
{
    public class Setting : IEntity
    {
        //dataanotations Key primary key olduğunu belirtir.
        [Key]
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
