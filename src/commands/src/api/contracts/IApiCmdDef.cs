//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IApiCmdDef
    {
        @string CmdName {get;}

        Type Source {get;}

        ReadOnlySeq<CmdField> Fields {get;}
    }
}