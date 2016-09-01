using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Vizr.API.Extensions
{
    public static class Extensions
    {
        /// <summary>
        /// Get all inner exceptions as IEnumerable<System.Exception> including itself
        /// </summary>
        public static IEnumerable<Exception> GetDescendantExceptionsAndSelf(this Exception target)
        {
            yield return target;

            var current = target.InnerException;

            while (current != null)
            {
                yield return current;
                current = current.InnerException;
            }
        }

        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> target, Action<T> action)
        {
            foreach (var item in target)
            {
                action(item);
                yield return item;
            }
        }

        public static string Join(this IEnumerable<string> target, string delimiter)
        {
            return string.Join(delimiter, target);
        }
    }
}
