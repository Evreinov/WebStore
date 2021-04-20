using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Domain.Entities.Base
{
    /// <summary>
    /// Теги записи
    /// </summary>
    public class Tag : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
    }
}
