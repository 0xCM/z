//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IApiCmdRunner
    {
        ExecToken RunCommand(ApiCmdSpec spec);
        
        ExecToken RunCommand(string action);

        ExecToken RunScript(FilePath src);

        ApiCmdCatalog CmdCatalog {get;}        
    }    
}