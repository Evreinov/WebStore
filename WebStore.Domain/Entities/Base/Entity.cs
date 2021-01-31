using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Domain.Entities.Base
{
    public abstract class Entity : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Указываем, что поле является первичным ключем и уникальным (параметр не требуется, если поле называется Id)
        public int Id { get; set; }
    }
}
