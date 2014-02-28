using System;
#if EF5
using System.Data.Objects;
#elif EF6 || EF61
using System.Data.Entity.Core.Objects;
#endif

namespace EntityFramework.Future
{
    /// <summary>
    /// The command plan for a future query.
    /// </summary>
    public class FuturePlan
    {
        /// <summary>
        /// Gets or sets the command text.
        /// </summary>
        /// <value>
        /// The command text.
        /// </value>
        public string CommandText { get; set; }
        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        /// <value>
        /// The parameters.
        /// </value>
        public ObjectParameterCollection Parameters { get; set; }
    }
}