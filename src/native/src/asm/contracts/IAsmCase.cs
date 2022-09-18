//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IAsmCase : ITextual
    {

    }

    public interface IAsmCase<T> : IAsmCase
        where T : IAsmCase<T>, new()
    {

    }

    public interface IAsmCaseResult : ITextual
    {

    }
}