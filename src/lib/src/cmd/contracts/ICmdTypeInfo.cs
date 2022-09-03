//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ICmdTypeInfo
    {
        Name CmdName {get;}

        Type Source {get;}

        Index<CmdField> Fields {get;}
    }
}