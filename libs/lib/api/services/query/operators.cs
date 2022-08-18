//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiQuery
    {
        /// <summary>
        /// Queries the host for binary operators belonging to a specified generic partition
        /// </summary>
        /// <param name="g">The generic partition</param>
        [Op]
        public static ApiHostMethods operators(IApiHost host, N1 arity, GenericState g = default)
            => methods(host, methods(host).Storage.MemberOf(g).UnaryOperators());

        /// <summary>
        /// Queries the host for binary operators belonging to a specified generic partition
        /// </summary>
        /// <param name="g">The generic partition</param>
        [Op]
        public static ApiHostMethods operators(IApiHost host, N2 arity, GenericState g = default)
            => methods(host, ApiHostMethods.load(host).Storage.MemberOf(g).BinaryOperators());

        /// <summary>
        /// Queries the host for binary operators belonging to a specified generic partition
        /// </summary>
        /// <param name="g">The generic partition</param>
        [Op]
        public ApiHostMethods operators(IApiHost host, N3 arity, GenericState g = default)
            => methods(host, methods(host).Storage.MemberOf(g).TernaryOperators());
    }
}