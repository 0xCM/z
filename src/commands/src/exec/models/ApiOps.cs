//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ApiOps : IApiOps
    {
        readonly Dictionary<string,Effector> Lookup;

        readonly ReadOnlySeq<Effector> CmdDefs;

        internal ApiOps(Dictionary<string,Effector> src)
        {
            Lookup = src;
            CmdDefs = src.Values.ToSeq();
        }

        public bool Find(string spec, out Effector runner)
            => Lookup.TryGetValue(spec, out runner);

        public ref readonly ReadOnlySeq<Effector> Defs
        {
            [MethodImpl(Inline)]
            get => ref CmdDefs;
        }
    }
}