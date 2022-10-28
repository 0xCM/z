//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AppCommands : IAppCommands
    {
        readonly Dictionary<string,IWfCmdRunner> Lookup;

        readonly ReadOnlySeq<WfCmdMethod> CmdDefs;

        internal AppCommands(Dictionary<string,IWfCmdRunner> src)
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

        public ref readonly ReadOnlySeq<WfCmdMethod> Defs
        {
            [MethodImpl(Inline)]
            get => ref CmdDefs;
        }
    }
}