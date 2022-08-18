//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct ApiIdentity
    {
        /// <summary>
        /// Closes generic operations over the set of primal types that each operation supports
        /// </summary>
        /// <param name="generics">Metadata for generic operations</param>
        [Op]
        public static Index<ApiMethodClosure> closures(ApiMethodG op)
             => from k in op.Kinds
                let pt = k.ToSystemType().ToOption() where pt.IsSome()
                let id = identify(op.Method, k) where !id.IsEmpty
                select new ApiMethodClosure(op.Host, id, k, op.Method.MakeGenericMethod(pt.Value));
    }
}