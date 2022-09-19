//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IMachine : IDisposable
    {
        uint Id {get;}

        void Reset();
    }
    
    public interface IMachine<S> : IMachine
    {
        void Run(S spec);

        Task Start(S spec)
            => sys.start(() => Run(spec));
    }
}