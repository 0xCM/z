//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    public class AppCommands : IAppCommands
    {
        public static AppCommands discover<T>(T src)
        {
            var dst = dict<string,IAppCmdRunner>();
            var methods = typeof(T).DeclaredInstanceMethods().Where(x => x.Tagged<CmdOpAttribute>());
            foreach(var m in methods)
            {
                var tag = m.Tag<CmdOpAttribute>().Require();
                dst.TryAdd(tag.Name, new AppCmdRunner(tag.Name, src, m));
            }
            return new AppCommands(dst);
        }

        internal readonly Dictionary<string,IAppCmdRunner> Lookup;

        readonly ReadOnlySeq<AppCmdDef> CmdDefs;

        internal AppCommands(Dictionary<string,IAppCmdRunner> src)
        {
            Lookup = src;
            CmdDefs = src.Values.Select(x => x.Def).ToSeq();
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