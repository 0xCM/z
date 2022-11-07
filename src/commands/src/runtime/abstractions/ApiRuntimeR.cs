//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public abstract class ApiRuntime<R> : IApiRuntime<R>
        where R: ApiRuntime<R>
    {
        protected static Type[] SvcHostTypes(Assembly src)
            => src.GetTypes().Where(t => t.Tagged<FunctionalServiceAttribute>());

        [Op]
        protected static Index<Type> ApiHostTypes(Assembly src)
            => src.GetTypes().Where(IsApiHost);

        [Op]
        protected static bool IsApiHost(Type src)
            => src.Tagged<ApiHostAttribute>();

        [Op]
        protected static Dictionary<string,MethodInfo> index(Index<MethodInfo> src)
        {
            var index = new Dictionary<string, MethodInfo>();
            iter(src, m => index.TryAdd(ApiIdentity.identify(m).IdentityText, m));
            return index;
        }

        protected const string InitializingRuntime = "Initializing runtime";
        
        protected static RenderPattern<Duration> InitializedRuntime => "Initialized runtime:{0}";

        protected static RenderPattern<LogSettings> ConfiguredAppLogs => "Configured app logs:{0}";

        protected static RenderPattern<IWfEmissions> ConfiguredEmissionLogs => "Configured emisson logs:{0}";
    }
}