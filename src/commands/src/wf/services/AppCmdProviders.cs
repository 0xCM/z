//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AppCmdProviders
    {
        readonly ReadOnlySeq<AppCmdProvider> Providers;

        ReadOnlySeq<IApiService> _Services;
        
        readonly object Locker = new();
        
        public AppCmdProviders(AppCmdProvider[] src)
        {
            Providers = src;
            _Services = new();
        }

        public ReadOnlySeq<IApiService> Services(IWfRuntime wf)
        {
            lock(Locker)
            {
                if(_Services.IsEmpty)
                {
                    _Services = Providers.Map(x => x.Service(wf));
                }
            }
            return _Services;
        }
        
        public Type[] ServiceTypes() 
            => Providers.Select(x => x.ServiceType).Storage;
        
        public static implicit operator AppCmdProviders(AppCmdProvider[] src)
            => new AppCmdProviders(src);
    }
}