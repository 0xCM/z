//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IToolCmd : ICmd
    {
        FilePath ToolPath {get;}
        
        ToolCmdArgs Args {get;}
    }
}