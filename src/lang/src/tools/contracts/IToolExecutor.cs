//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IToolExecutor
    {
        Task<ExecToken> Execute(ToolExecSpec context, ICmd command);
    }
}