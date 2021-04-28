using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Domain.Entities
{
    [Table("Brands")] // Указываем явно название таблицы, при отсутсвии атрибута, название таблицы формируется из названия класса в множественно числе.
    public class Brand : NamedEntity, IOrderedEntity
    {
        [Column("Order")] // Указываем явно название столбца таблицы, при отсутсвии атрибут называется, аналогично названию свойству.
        public int Order { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
