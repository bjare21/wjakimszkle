using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.DataAccess.CQRS.Queries;
using Wjakimszkle.Shared.Configuration;

namespace Wjakimszkle.DataAccess
{
    public class QueryExecutor:IQueryExecutor
    {
        private readonly LiquorRegisterContext context;

        public QueryExecutor(LiquorRegisterContext context)
        {
            this.context = context;
        }

        public Task<TResult> Execute<TResult>(QueryBase<TResult> query)
        {
            return query.Execute(this.context);
        }
    }
}
