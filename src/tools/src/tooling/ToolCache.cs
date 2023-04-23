//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class Tooling
    {
        class ServiceCache : AppServices<ServiceCache>
        {
            
        }

        static readonly ServiceCache ToolServices = new();
    }
}