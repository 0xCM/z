//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IToolService : IAppService
    {
        ToolCmdArgs ParseArgs(string src);

        IToolFlow ToolFlow();
    }
}