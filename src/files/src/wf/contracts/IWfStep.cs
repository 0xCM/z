//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IWfStep
    {
        string StepName {get;}

        ExecToken Run(IWfChannel channel);
    }

    public interface IWfStep<T> : IWfStep
    {
        new ExecToken<T> Run(IWfChannel channel);

        ExecToken IWfStep.Run(IWfChannel channel)
            => Run(channel);
    }
}