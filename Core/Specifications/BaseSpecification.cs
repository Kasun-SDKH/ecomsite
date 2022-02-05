using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {
        }

        public BaseSpecification(Expression<Func<T, bool>> citeria)
        {
            Citeria = citeria;
            
        }

        public Expression<Func<T, bool>> Citeria { get;}

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>> ();

        protected void AddInclude(Expression<Func<T, object>> IncludeEpression)
        {
            Includes.Add(IncludeEpression);
        }
    }
}
