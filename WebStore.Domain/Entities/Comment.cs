using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Domain.Entities.Base;

namespace WebStore.Domain.Entities
{
    public class Comment : Entity
    {
        /// <summary>
        /// Id записи.
        /// </summary>
        public int PostId { get; set; }

        /// <summary>
        /// Id автора комментария
        /// </summary>
        public int AuthorId { get; set; } // Id автора комментария. Миграция будет после появления класса пользователей.

        /// <summary>
        /// Имя автора
        /// </summary>
        public string Autor { get; set; }

        /// <summary>
        /// Электронная почта автора
        /// </summary>
        public string AutorEmail { get; set; }

        /// <summary>
        /// Вэб-сайт автора
        /// </summary>
        public string AutorURL { get; set; }

        /// <summary>
        /// IP автора
        /// </summary>
        public string AutorIP { get; set; }

        /// <summary>
        /// Дата комментария
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Дата комментария по гринвичу.
        /// </summary>
        public DateTime DateGMT { get; set; }

        /// <summary>
        /// Родительский комментарий.
        /// </summary>
        public int? ParentId { get; set; }
    }
}
