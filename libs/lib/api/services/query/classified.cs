//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    partial class ApiQuery
    {
        /// <summary>
        /// Queries the host for operations of specified kind
        /// </summary>
        /// <param name="k">The kind classifier</param>
        /// <typeparam name="K">The kind type</typeparam>
        [Op, Closures(Closure)]
        public static ApiHostMethods classified<K>(IApiHost src, K k)
            where K : unmanaged
                => methods(src,(from m in ApiHostMethods.load(src).Storage.Tagged(typeof(OpKindAttribute))
                let a = m.Tag<OpKindAttribute>().Require()
                where a.ApiClass.ToString() == k.ToString()
                    select m).Array());

        /// <summary>
        /// Queries the host for generic operations of specified kind
        /// </summary>
        /// <param name="k">The kind classifier</param>
        /// <typeparam name="K">The kind type</typeparam>
        [Op, Closures(Closure)]
        public static ApiHostMethods classified<K>(IApiHost host, K k, GenericState g)
            where K : unmanaged
                => methods(host, classified(host,k).Storage.MemberOf(g));
    }
}