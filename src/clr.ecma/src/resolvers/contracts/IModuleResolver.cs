//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IModuleResolver
    {
        IBinaryModule Resolve(IDependency dependency);
    }

    public interface IModuleResolver<D,M> : IModuleResolver
        where M : IBinaryModule
    {        
        M Resolve(D dependency);

        IBinaryModule IModuleResolver.Resolve(IDependency dependency)
            => Resolve((D)dependency);
    }
}