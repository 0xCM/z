//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface IApiEvalExecutor
    {
        TimedEval ExecAction(Action action, _OpUri f, _OpUri g);
    }
}