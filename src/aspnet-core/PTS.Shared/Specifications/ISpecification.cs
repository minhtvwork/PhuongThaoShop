using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace App.Shared.Core.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        List<string> IncludeStrings { get; }
        Expression<Func<T, object>> OrderBy { get; }
        Expression<Func<T, object>> OrderByDescending { get; }

        int PageSize { get; }
        int PageNumber { get; }
        bool isPagingEnabled { get; }
        void AddInclude(Expression<Func<T, object>> includeExpression);
        void AddInclude(string includeString);
        void ApplyPaging(int pageSize, int pageNumber);
        void ApplyOrderBy(Expression<Func<T, object>> orderByExpression);
        void ApplyOrderByDescending(Expression<Func<T, object>> orderByDescendingExpression);
    }
}
