using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace LinqExcersize {
    public class ModelQueryProvider : IQueryProvider {
        IQueryable IQueryProvider.CreateQuery(Expression expression) {
            Type elementType = TypeSystem.GetElementType(expression.Type);
            try {
                Type type = typeof(QueryableModel<>).MakeGenericType(elementType);
                return (IQueryable)Activator.CreateInstance(type, new object[] { this, expression });
            } catch(TargetInvocationException ex) {
                throw ex.InnerException;
            }
        }

        IQueryable<TElement> IQueryProvider.CreateQuery<TElement>(Expression expression) {
            return new QueryableModel<TElement>(this, expression);
        }

        object IQueryProvider.Execute(Expression expression) {
            throw new System.NotImplementedException();
        }

        TResult IQueryProvider.Execute<TResult>(Expression expression) {
            throw new System.NotImplementedException();
        }
    }
}
