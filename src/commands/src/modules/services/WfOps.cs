//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class WfOps : IWfOps
    {
        readonly Dictionary<string,IWfCmdRunner> Lookup;

        readonly ReadOnlySeq<WfOp> CmdDefs;

        internal WfOps(Dictionary<string,IWfCmdRunner> src)
        {
            Lookup = src;
            CmdDefs = src.Values.Map(x => x.Def).ToSeq();
        }

        public bool Find(string spec, out IWfCmdRunner runner)
            => Lookup.TryGetValue(spec, out runner);

        public IEnumerable<string> Specs
        {
            [MethodImpl(Inline)]
            get => Lookup.Keys;
        }

        public ICollection<IWfCmdRunner> Invokers
            => Lookup.Values;

        public ref readonly ReadOnlySeq<WfOp> Defs
        {
            [MethodImpl(Inline)]
            get => ref CmdDefs;
        }
    }
}