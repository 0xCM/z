//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AppCommands : IAppCommands
    {
        readonly Dictionary<string,IAppCmdRunner> Lookup;

        readonly ReadOnlySeq<AppCmdMethod> CmdDefs;

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

        public ref readonly ReadOnlySeq<AppCmdMethod> Defs
        {
            [MethodImpl(Inline)]
            get => ref CmdDefs;
        }
    }
}