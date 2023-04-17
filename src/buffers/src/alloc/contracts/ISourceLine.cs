//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ISourceLine
    {
        LineNumber LineNumber {get;}

        SourceText Source {get;}
    }
}