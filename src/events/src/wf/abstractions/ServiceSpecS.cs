//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public abstract record class ServiceSpec<S> : ServiceSpec
    where S : IAppService
{
    protected ServiceSpec(Type host, MethodInfo[] factories)
        : base(host, factories)
    {

    }
}
