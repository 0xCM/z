//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IMethodIdentity : IIdentification
    {
        IdentityTargetKind IIdentification.TargetKind
            => IdentityTargetKind.Method;
    }

    [Free]
    public interface IMethodIdentity<T> : IMethodIdentity, IIdentification<T>
        where T : IMethodIdentity<T>
    {

    }
}