//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public sealed record class AppServiceSpec : ServiceSpec<IAppService>
{
    public AppServiceSpec(Type host, MethodInfo[] factories)
        : base(host, factories)
    {

    }
}
