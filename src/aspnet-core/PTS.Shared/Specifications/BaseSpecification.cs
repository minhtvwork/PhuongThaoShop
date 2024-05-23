using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace App.Shared.Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        
        public Expression<Func<T, bool>> Criteria { get; private set; }
        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();
        public List<string> IncludeStrings { get; } = new List<string>();
        public Expression<Func<T, object>> OrderBy { get; private set; }
        public Expression<Func<T, object>> OrderByDescending { get; private set; }

        public int PageSize { get; private set; }
        public int PageNumber { get; private set; }
        public bool isPagingEnabled { get; private set; } = false;

        public virtual void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
        public virtual void AddInclude(string includeString)
        {
            IncludeStrings.Add(includeString);
        }
        public virtual void ApplyPaging(int pageSize, int pageNumber)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
            isPagingEnabled = true;
        }
        public virtual void ApplyCriteria(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
        public virtual void ApplyOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }
        public virtual void ApplyOrderByDescending(Expression<Func<T, object>> orderByDescendingExpression)
        {
            OrderByDescending = orderByDescendingExpression;
        }
    }
}
