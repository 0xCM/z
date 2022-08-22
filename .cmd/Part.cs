//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
global using System;
global using System.Collections.Generic;
global using System.Collections.Concurrent;
global using System.Reflection;
global using System.Runtime.Intrinsics;
global using System.Runtime.CompilerServices;
global using System.Runtime.InteropServices;

global using static Z0.Root;
global using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;
global using SQ = Z0.SymbolicQuery;

[assembly: PartId(PartId.Cmd)]
namespace Z0.Parts
{
    public sealed class Cmd : Part<Cmd>
    {
        [ModuleInitializer]
        internal static void Init()
        {
            //AppData.init();
            NumRender.Service.RegisterFomatters();
        }

    }
}

namespace Z0
{
}