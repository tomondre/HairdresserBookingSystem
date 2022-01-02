using System.Collections.Generic;
using System.Linq;

namespace API.Persistence
{
    public abstract class PaginationHelper
    {
        public static IList<T> Page<T>(IList<T> items, int page, int size)
        {
            return items.Skip((page - 1) * size).Take(size).ToList();
        }
    }
}