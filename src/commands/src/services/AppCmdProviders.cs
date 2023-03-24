//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AppCmdProviders
    {
        static IApiService service(IWfRuntime wf, Type type)
            => (IApiService)type.Method("create").Invoke(null, new object[]{wf});

        readonly ReadOnlySeq<Type> Providers;

        ReadOnlySeq<IApiService> _Services;
        
        readonly object Locker = new();
        
        public AppCmdProviders(Type[] src)
        {
            Providers = src;
            _Services = new();
        }

        public ReadOnlySeq<IApiService> Services(IWfRuntime wf)
        {
            lock(Locker)
            {
                if(_Services.IsEmpty)
                    _Services = Providers.Map(x => service(wf,x));
            }
            return _Services;
        }
        
        public Type[] ServiceTypes() 
            => Providers.Storage;        
    }
}