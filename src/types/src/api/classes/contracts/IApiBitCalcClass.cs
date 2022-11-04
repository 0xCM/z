//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = ApiBitCalcClass;

    /// <summary>
    /// Characterizes a bitfunction classifier
    /// </summary>
    [Free]
    public interface IApiBitCalcClass : IApiClass<K>
    {
        new ApiBitCalcClass Kind {get;}

        K IApiClass<K>.Kind
            => Kind;
    }
}