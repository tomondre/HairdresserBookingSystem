using System.Collections.Generic;
using System.Linq;

namespace API.Persistence
{
    public abstract class PaginationHelper
    {
        public static IList<T> Page<T>(IEnumerable<T> items, int page, int size)
        {
            var list = items.ToList();
            return list.Skip((page - 1) * size).Take(size).ToList();
        }
    }
}