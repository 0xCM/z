//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ApiOps : IApiOps
    {
        readonly Dictionary<string,ApiOp> Lookup;

        readonly ReadOnlySeq<ApiOp> CmdDefs;

        internal ApiOps(Dictionary<string,ApiOp> src)
        {
            Lookup = src;
            CmdDefs = src.Values.ToSeq();
        }

        public bool Find(string spec, out ApiOp runner)
            => Lookup.TryGetValue(spec, out runner);

        public ref readonly ReadOnlySeq<ApiOp> Defs
        {
            [MethodImpl(Inline)]
            get => ref CmdDefs;
        }
    }
}