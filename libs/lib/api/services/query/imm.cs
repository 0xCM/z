//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiQuery
    {
        [Op]
        public static ApiGroupNG[] imm(IApiHost host, ImmRefinementKind kind)
            => from g in GroupNongeneric(host)
                let imm = GroupImm(host, g, kind)
                where !imm.IsEmpty
                select g;

        [Op]
        public static ApiMethodG[] immG(IApiHost host, ImmRefinementKind kind)
            => GroupGeneric(host).Where(op => op.Method.AcceptsImmediate(kind));

        static ApiGroupNG GroupImm(IApiHost host, ApiGroupNG g, ImmRefinementKind kind)
            => new ApiGroupNG(g.GroupId, host,
                g.Members.Storage.Where(m => m.Method.AcceptsImmediate(kind) && m.Method.ReturnsVector()));
    }
}