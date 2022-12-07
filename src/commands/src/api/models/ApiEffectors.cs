//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ApiEffectors : IApiEfectors
    {
        readonly Dictionary<string,ApiEffector> Lookup;

        readonly ReadOnlySeq<ApiEffector> CmdDefs;

        internal ApiEffectors(Dictionary<string,ApiEffector> src)
        {
            Lookup = src;
            CmdDefs = src.Values.ToSeq();
        }

        public bool Find(string spec, out ApiEffector runner)
            => Lookup.TryGetValue(spec, out runner);

        public ref readonly ReadOnlySeq<ApiEffector> Defs
        {
            [MethodImpl(Inline)]
            get => ref CmdDefs;
        }
    }
}