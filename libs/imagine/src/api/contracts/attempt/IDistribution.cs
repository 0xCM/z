//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IDistribution<T> : IEnumerable<T>
        where T : unmanaged
    {
        IEnumerable<T> Sample();
    }

    public interface IDistribution<S,T> : IDistribution<T>
        where S : IDistributionSpec
        where T : unmanaged
    {

    }
}