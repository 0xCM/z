//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Microsoft.Extensions.Hosting;

    public abstract class Worker<W> : BackgroundService
        where W : Worker<W>
    {

    }
}
