//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ApiCmdMethods : IDisposable
    {
        readonly Dictionary<string,ApiCmdMethod> Lookup;

        readonly ReadOnlySeq<ApiCmdMethod> CmdDefs;

        readonly ReadOnlySeq<IApiService> Services;

        public ApiCmdMethods(ReadOnlySeq<IApiService> services, Dictionary<string,ApiCmdMethod> src)
        {
            Lookup = src;
            Services = services;
            CmdDefs = src.Values.ToSeq();
        }

        public bool Find(string spec, out ApiCmdMethod runner)
            => Lookup.TryGetValue(spec, out runner);

        public void Dispose()
        {
            foreach(var svc in Services)
            {
                try
                {
                    svc.Dispose();
                }
                catch(Exception e)
                {
                    term.error(e);
                }
            }
        }

        public ref readonly ReadOnlySeq<ApiCmdMethod> Defs
        {
            [MethodImpl(Inline)]
            get => ref CmdDefs;
        }
    }
}