using WebStore.Domain.Entities.Base;

namespace WebStore.Domain.Entities
{
    public class Rate : Entity
    {
        /// <summary>
        /// Оценка
        /// </summary>
        public int Rating { get; set; }

        /// <summary>
        /// IP проголосовавшего
        /// </summary>
        public string IPVoter { get; set; }
    }
}
