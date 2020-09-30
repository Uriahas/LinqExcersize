using System;
using System.Linq;
using System.Linq.Expressions;

namespace LinqExcersize {
    public static class Extensions {
        /// <summary>
        /// Adds WHERE to a query expression
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="filter">
        /// An array of filter caluses.
        /// Each fitler clause consists of three objects:
        /// 0. A property name.
        /// 1. A value.
        /// 2. An operation.
        /// An operation can take the following string values: 'equal', 'not equal', 'less', 'greater', 'less or equal', 'greater or equal', 'starts with', 'ends with', 'contains'
        /// </param>
        /// <returns></returns>
        public static IQueryable<T> ApplyMyFilter<T>(this IQueryable<T> query, object[][] filter) {
            // your code goes here
        }
    }
}
