//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICmdRunner
    {
        ExecToken RunCommand(string[] args);

        ExecToken RunCommand(string action, CmdArgs args);

        ExecToken RunCommand(string action);

        ExecToken RunCommandScript(FilePath src);
        
        CmdCatalog Catalog {get;}       
    }    
}