//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.DynamicModels
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using static Root;
    using static core;

    /// <summary>
    /// Collects standard method classifications
    /// </summary>
    public class StandardMethods
    {
        public static IEnumerable<StandardMethod> All
            => array(ThenBy, ThenByDescending, OrderBy, OrderByDescending, Select, Where);

        public static StandardMethod ThenBy
            => new OrderSpecificationMethod(nameof(ThenBy), SortDirection.Ascending, false);

        public static StandardMethod ThenByDescending
            => new OrderSpecificationMethod(nameof(ThenByDescending), SortDirection.Descending, false);

        public static StandardMethod OrderBy
            => new OrderSpecificationMethod(nameof(ThenBy), SortDirection.Ascending, true);

        public static StandardMethod OrderByDescending
            => new OrderSpecificationMethod(nameof(ThenByDescending), SortDirection.Descending, true);

        public static StandardMethod Select
            => new SelectMethod();

        public static StandardMethod Where
            => new WhereMethod();
    }
}