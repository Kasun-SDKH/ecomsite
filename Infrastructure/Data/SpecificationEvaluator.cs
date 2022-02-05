﻿using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec) 
        {
            var query = inputQuery;

            if(spec.Citeria != null)
            {
                query = query.Where(spec.Citeria);
            }
            query = spec.Includes.Aggregate(query, (current, includes) => current.Include(includes));

            return query;
        }
    }
}
