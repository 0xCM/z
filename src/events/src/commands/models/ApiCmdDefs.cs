//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public sealed class ApiCmdDefs : Seq<ApiCmdDefs, ApiCmdDef>
    {    
        readonly ConstLookup<@string,ApiCmdDef> Lookup;

        public ApiCmdDefs()
        {
            Lookup = ConstLookup<@string,ApiCmdDef>.Empty;
        }

        public ApiCmdDefs(ApiCmdDef[] src)
            : base(src)
        {
            Lookup = src.Select(x => (x.Route.Path,x)).ToDictionary();
        }

        public bool Find(@string path, out ApiCmdDef def)
            => Lookup.Find(path, out def);

        public ReadOnlySpan<@string> Paths 
            => Lookup.Keys;
    }
}