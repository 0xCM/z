//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IProcessor
    {

    }

    public interface IProcessor<S,T> : IProcessor
    {
        Task Process(S src, T dst, CancellationToken cancel);

        void Process(S src, T dst);
    }
}