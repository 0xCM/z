//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IXedMachine : IDisposable
    {
        uint MachineId {get;}

        void Reset();
    }
    
    public interface IXedMachine<S> : IXedMachine
    {
        void Run(S spec);

        Task Start(S spec)
            => sys.start(() => Run(spec));
    }
}