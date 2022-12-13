//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CmdActors : ICmdActors
    {
        readonly Dictionary<string,CmdActor> Lookup;

        readonly ReadOnlySeq<CmdActor> CmdDefs;

        internal CmdActors(Dictionary<string,CmdActor> src)
        {
            Lookup = src;
            CmdDefs = src.Values.ToSeq();
        }

        public bool Find(string spec, out CmdActor runner)
            => Lookup.TryGetValue(spec, out runner);

        public ref readonly ReadOnlySeq<CmdActor> Defs
        {
            [MethodImpl(Inline)]
            get => ref CmdDefs;
        }
    }
}