//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
global using System;
global using System.Collections.Generic;
global using System.Collections.Concurrent;
global using System.Collections;
global using System.IO;
global using System.Diagnostics;

global using System.Reflection;
global using System.Reflection.Metadata;
global using System.Runtime.Intrinsics;
global using System.Runtime.CompilerServices;
global using System.Runtime.InteropServices;

global using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;
global using CallerName = System.Runtime.CompilerServices.CallerMemberNameAttribute;
global using CallerFile = System.Runtime.CompilerServices.CallerFilePathAttribute;
global using CallerLine = System.Runtime.CompilerServices.CallerLineNumberAttribute;

global using static Z0.LiteralGroups;
global using static Z0.NumericBaseKind;
global using static Root;

global using NBK = Z0.NumericBaseKind;

global using CC = System.Runtime.InteropServices.CallingConvention;

//global using static System.Runtime.InteropServices.CallingConvention;

global using Fp = System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute;

[assembly: PartId(PartId.Interop)]

class Root
{
    public const string EmptyString = "";


    public const string windows = nameof(windows);

    public const string coff = nameof(coff);

    public const string images = nameof(images);
}