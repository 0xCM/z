//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AppCommands : IAppCommands
    {
        internal readonly Dictionary<string,IAppCmdRunner> Lookup;

        readonly ReadOnlySeq<AppCmdDef> CmdDefs;

        internal AppCommands(Dictionary<string,IAppCmdRunner> src)
        {
            Lookup = src;
            CmdDefs = src.Values.Map(x => x.Def).ToSeq();
        }

        public bool Find(string spec, out IAppCmdRunner runner)
            => Lookup.TryGetValue(spec, out runner);

        public IEnumerable<string> Specs
        {
            [MethodImpl(Inline)]
            get => Lookup.Keys;
        }

        public ICollection<IAppCmdRunner> Invokers
            => Lookup.Values;

        public ref readonly ReadOnlySeq<AppCmdDef> Defs
        {
            [MethodImpl(Inline)]
            get => ref CmdDefs;
        }
    }
}