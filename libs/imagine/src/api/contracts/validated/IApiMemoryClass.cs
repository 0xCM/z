//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;
    using K = ApiMemoryClass;

    /// <summary>
    /// Characterizes a system operation classifier
    /// </summary>
    [Free]
    public interface IApiMemoryClass : IApiClass<K>
    {
        new ApiMemoryClass Kind {get;}

        K IApiClass<K>.Kind
            => Kind;
    }
}