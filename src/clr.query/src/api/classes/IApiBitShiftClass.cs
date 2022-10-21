//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = BitShiftClass;

    /// <summary>
    /// Characterizes a bitshift operation classifier
    /// </summary>
    [Free]
    public interface IApiBitShiftClass : IApiClass<K>
    {
        new BitShiftClass Kind {get;}

        K IApiClass<K>.Kind
            => Kind;
    }
}