//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Hosting;
global using Microsoft.Extensions.Logging;

[assembly: PartId("workers")]

namespace Z0.Parts
{
    public sealed partial class Workers : Part<Workers>
    {

    }
}
