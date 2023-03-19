//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IModuleResolver
    {
        IBinaryModule Resolve(IModuleDependency dependency);
    }

    public interface IModuleResolver<D,M> : IModuleResolver
        where M : IBinaryModule
        where D : IModuleDependency
    {        
        M Resolve(D dependency);

        IBinaryModule IModuleResolver.Resolve(IModuleDependency dependency)
            => Resolve((D)dependency);
    }
}