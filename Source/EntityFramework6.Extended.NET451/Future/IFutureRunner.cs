using System;
using System.Collections.Generic;
#if EF5
using System.Data.Objects;
#elif EF6 || EF61
using System.Data.Entity.Core.Objects;
#endif

namespace EntityFramework.Future
{
    /// <summary>
    /// A interface encapsulating the execution of future queries.
    /// </summary>
    public interface IFutureRunner
    {
        /// <summary>
        /// Executes the future queries.
        /// </summary>
        /// <param name="context">The <see cref="ObjectContext"/> to run the queries against.</param>
        /// <param name="futureQueries">The future queries list.</param>
        void ExecuteFutureQueries(ObjectContext context, IList<IFutureQuery> futureQueries);
    }
}