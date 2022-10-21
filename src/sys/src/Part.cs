//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
global using System;
global using System.Collections.Generic;
global using System.Collections;
global using System.Collections.Concurrent;
global using System.Reflection;
global using System.Diagnostics;
global using System.Reflection.Metadata;
global using System.Reflection.Metadata.Ecma335;
global using System.Reflection.PortableExecutable;
global using System.Reflection.Emit;
global using System.Runtime.Intrinsics;
global using System.Runtime.CompilerServices;
global using System.Runtime.InteropServices;
global using System.Threading;
global using System.Threading.Tasks;
global using System.Text;
global using System.IO;

global using CC = System.Runtime.InteropServices.CallingConvention;
global using Fp = System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute;

global using Z0;
global using static Z0.Root;
global using static Z0.ApiAtomic;
global using SQ = Z0.SymbolicQuery;

global using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;
global using CallerName = System.Runtime.CompilerServices.CallerMemberNameAttribute;
global using CallerFile = System.Runtime.CompilerServices.CallerFilePathAttribute;
global using CallerLine = System.Runtime.CompilerServices.CallerLineNumberAttribute;
global using static System.Runtime.InteropServices.CallingConvention;
global using NBK = Z0.NumericBaseKind;

using NK = Z0.NumericKind;


[assembly: PartId(PartId.Sys)]

namespace Z0.Parts
{
    public sealed class Sys : Part<Sys>
    {

    }
}
namespace Z0
{
class SymbolicQuery
{}

}

