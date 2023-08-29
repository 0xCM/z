//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public interface IApiCmdRunner : IDisposable
{
    ExecToken RunCommand(ApiCommand spec);
    
    ExecToken RunCommand(string action);

    ExecToken RunScript(FilePath src);

    ApiCmdCatalog CmdCatalog {get;}        
}    
