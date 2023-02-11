//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class CmdDefs : Seq<CmdDefs, CmdDef>
    {
        readonly ConstLookup<@string,CmdDef> Lookup;

        public CmdDefs()
        {
            Lookup = ConstLookup<@string,CmdDef>.Empty;
        }

        internal CmdDefs(CmdDef[] src)
            : base(src)
        {
            Lookup = src.Select(x => (x.Route.Path,x)).ToDictionary();
        }

        public bool Find(@string path, out CmdDef def)
            => Lookup.Find(path, out def);

        public ReadOnlySpan<@string> Paths 
            => Lookup.Keys;
    }
}