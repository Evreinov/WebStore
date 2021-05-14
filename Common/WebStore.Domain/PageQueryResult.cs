using System.Collections.Generic;

namespace WebStore.Domain
{
    // Пример оболочки для представления больших данных частями.
    class PageQueryResult<T>
    {
        public IEnumerable<T> Items { get; init; }

        public int TotalCount { get; init; }

        //public int Page { get; init; }

        //public int TotalPageCount => (int)Math.Ceiling((double)TotalCount / Items.Count());
    }
}
