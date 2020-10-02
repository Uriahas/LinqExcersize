using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LinqExcersize {
    public class QueryableModel<TModel> : IOrderedQueryable<TModel> {
        readonly IQueryProvider provider;
        readonly Expression expression;
        public QueryableModel() {
            provider = new ModelQueryProvider();
            expression = Expression.Constant(this);
        }
        internal QueryableModel(ModelQueryProvider provider, Expression expression) {
            if(provider == null)
                throw new ArgumentNullException(nameof(provider));
            if(expression == null)
                throw new ArgumentNullException(nameof(expression));
            if(!typeof(IQueryable<TModel>).IsAssignableFrom(expression.Type))
                throw new ArgumentOutOfRangeException(nameof(expression));
            this.provider = provider;
            this.expression = expression;
        }
        Expression IQueryable.Expression => expression;

        Type IQueryable.ElementType => typeof(TModel);

        IQueryProvider IQueryable.Provider => provider;

        IEnumerator<TModel> IEnumerable<TModel>.GetEnumerator() => provider.Execute<IEnumerable<TModel>>(expression).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => provider.Execute<IEnumerable>(expression).GetEnumerator();
    }
}
