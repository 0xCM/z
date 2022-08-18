//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = ApiComparisonClass;
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    /// <summary>
    /// Characterizes a bitshift operation classifier
    /// </summary>
    [Free]
    public interface IApiComparisonClass : IApiClass<K>
    {
        new K Kind {get;}

        K IApiClass<K>.Kind
            => Kind;
    }
}