//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CmdMethods : ICmdMethods
    {
        readonly Dictionary<string,CmdMethod> Lookup;

        readonly ReadOnlySeq<CmdMethod> CmdDefs;

        public CmdMethods(Dictionary<string,CmdMethod> src)
        {
            Lookup = src;
            CmdDefs = src.Values.ToSeq();
        }

        public bool Find(string spec, out CmdMethod runner)
            => Lookup.TryGetValue(spec, out runner);

        public ref readonly ReadOnlySeq<CmdMethod> Defs
        {
            [MethodImpl(Inline)]
            get => ref CmdDefs;
        }
    }
}