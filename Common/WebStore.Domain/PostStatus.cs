using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Domain
{
    /// <summary>
    /// Текущее состояние записи.
    /// </summary>
    public enum PostStatus 
    {
        Черновик,
        Опубликован,
        Приватный,
        Корзина
    }
}
