//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ToolService]
    public abstract class ToolService<T> : WfSvc<T>, IToolService
        where T : ToolService<T>, new()
    {
        protected virtual ToolCmdArgs ParseArgs(string src)
        {
            return ToolCmdArgs.Empty;
        }


        ToolCmdArgs IToolService.ParseArgs(string src)
            => ParseArgs(src);

        public abstract IToolFlow ToolFlow();
    }
}
