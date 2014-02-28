using System;
using System.Collections.Generic;
#if EF5
using System.Data.Objects;
#elif EF6 || EF61
using System.Data.Entity.Core.Objects;
#endif
using System.Linq;
using System.Text;

namespace EntityFramework.Mapping
{
    /// <summary>
    /// An interface defining a provider to get entity mapping data.
    /// </summary>
    public interface IMappingProvider
    {
        /// <summary>
        /// Gets the <see cref="EntityMap"/> for the specified <typeparamref name="TEntity"/>.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="query">The query to use to help load the mapping data.</param>
        /// <returns>An <see cref="EntityMap"/> with the mapping data.</returns>
        EntityMap GetEntityMap<TEntity>(ObjectQuery query);
    }
}
