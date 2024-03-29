﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Domain.Entities
{
    public class Section : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }

        public int? ParentId { get; set; }

        [ForeignKey(nameof(ParentId))] // Указываем вручную первичный ключ
        public virtual Section Parent { get; set; } // Свойство зависимости

        public virtual ICollection<Product> Products { get; set; } 
    }
}
