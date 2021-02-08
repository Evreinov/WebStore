using System;
using System.Collections.Generic;
using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Domain.Entities
{
    /// <summary>
    /// Запись блога
    /// </summary>
    public class Post : NamedEntity, IOrderedEntity
    {
        /// <summary>
        /// Порядковое значение блога, для добавления в компоненты.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Id автора поста
        /// </summary>
        public int AuthorId { get; set; } // Id автора поста. Миграция будет после появления класса пользователей.

        /// <summary>
        /// Дата создания записи.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Дата создания записи по гринвичу.
        /// </summary>
        public DateTime DateGMT { get; set; }

        /// <summary>
        /// Дата последнего изменения записи.
        /// </summary>
        public DateTime Modified { get; set; }

        /// <summary>
        /// Дата помледнего изменения записи по гринвичу.
        /// </summary>
        public DateTime ModifiedGMT { get; set; }

        /// <summary>
        /// Тело записи.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Аннотация к записи.
        /// </summary>
        public string Excerpt { get; set; }

        /// <summary>
        /// Статус записи.
        /// </summary>
        public PostStatus Status { get; set; }

        /// <summary>
        /// Возможность комментирования записи
        /// </summary>
        public CommentStatus CommentStatus { get; set; } 

        /// <summary>
        /// Комментарии к посту.
        /// </summary>
        public IEnumerable<Comment> Comments { get; set; }
        /// <summary>
        /// Количество комментариев
        /// </summary>
        public int CommentCount { get; set; }

        /// <summary>
        /// Адрес заглавной картинки записи
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Райтинг записи
        /// </summary>
        public IEnumerable<Rate> Rate { get; set; }
    }
}
