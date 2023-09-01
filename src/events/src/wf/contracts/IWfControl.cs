//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using Microsoft.Extensions.Hosting;

public interface IWfControl : IHostedService
{
    void Run(CancellationToken cancel)
        => StartAsync(cancel).Wait(cancel);        
}
