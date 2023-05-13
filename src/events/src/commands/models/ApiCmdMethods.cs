//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ApiCmdMethods
    {
        readonly Dictionary<string,ApiCmdMethod> Lookup;

        readonly ReadOnlySeq<ApiCmdMethod> CmdDefs;

        public ApiCmdMethods(Dictionary<string,ApiCmdMethod> src)
        {
            Lookup = src;
            CmdDefs = src.Values.ToSeq();
        }

        public bool Find(string spec, out ApiCmdMethod runner)
            => Lookup.TryGetValue(spec, out runner);

        public ref readonly ReadOnlySeq<ApiCmdMethod> Defs
        {
            [MethodImpl(Inline)]
            get => ref CmdDefs;
        }
    }
}