using System;
using System.Collections.Generic;

namespace DotNetCorePOC.Support.Extensions
{
    public static class CollectionExtensions
    {
        public static void Foreach<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (var item in list)
            {
                action(item);
            }
        }

    }
}
