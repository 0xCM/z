//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a boolean outcome
    /// </summary>
    public interface IEval
    {
        bit Result {get;}
    }

    /// <summary>
    /// Characterizes a reified boolean outcome
    /// </summary>
    public interface ISeqEval<H,T> : IEval, IIndex<T>
        where H : struct, ISeqEval<H,T>
    {

    }
}