//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class WfOps : IApiOps
    {
        readonly Dictionary<string,IApiCmdMethod> Lookup;

        readonly ReadOnlySeq<ApiOp> CmdDefs;

        internal WfOps(Dictionary<string,IApiCmdMethod> src)
        {
            Lookup = src;
            CmdDefs = src.Values.Map(x => x.Def).ToSeq();
        }

        public bool Find(string spec, out IApiCmdMethod runner)
            => Lookup.TryGetValue(spec, out runner);

        public IEnumerable<string> Specs
        {
            [MethodImpl(Inline)]
            get => Lookup.Keys;
        }

        public ICollection<IApiCmdMethod> Invokers
            => Lookup.Values;

        public ref readonly ReadOnlySeq<ApiOp> Defs
        {
            [MethodImpl(Inline)]
            get => ref CmdDefs;
        }
    }
}