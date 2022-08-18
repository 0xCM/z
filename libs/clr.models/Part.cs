//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
global using System.Reflection.Emit;
global using System.Reflection.Metadata;
global using System.Reflection.Metadata.Ecma335;
global using System.Reflection.PortableExecutable;
global using System.Runtime.Intrinsics;
global using System.Runtime.CompilerServices;
global using System.Runtime.InteropServices;
global using System.IO;

[assembly: PartId(PartId.ClrModels)]
namespace Z0.Parts
{
    public sealed class ClrModels : Part<ClrModels>
    {
    }
}
namespace Z0
{
    class SymbolicQuery{}
}
