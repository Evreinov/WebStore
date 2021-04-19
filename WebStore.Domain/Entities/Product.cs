using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Domain.Entities
{
    public class Product : NamedEntity, IOrderedEntity
    {
        /// <summary>
        /// Порядковый номер
        /// </summary>
        public int Order { get; set; }
        /// <summary>
        /// Номер секции
        /// </summary>
        public int SectionId { get; set; }
        [ForeignKey(nameof(SectionId))]
        public virtual Section Section { get; set; }
        /// <summary>
        /// Номер бренда
        /// </summary>
        public int? BrandId { get; set; }
        [ForeignKey(nameof(BrandId))]
        public virtual Brand Brand { get; set; }
        /// <summary>
        /// Адрес картинки
        /// </summary>
        public string ImageUrl { get; set; }
        /// <summary>
        /// Цена
        /// </summary>
        [Column(TypeName = "decimal(18,2)")] // точность decimal в базе данных
        public decimal Price { get; set; }
    }
}
