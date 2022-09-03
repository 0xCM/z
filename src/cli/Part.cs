//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
global using Microsoft.CodeAnalysis;
global using Microsoft.CodeAnalysis.CSharp;
global using Microsoft.CodeAnalysis.Emit;

global using ClrMd = Microsoft.Diagnostics.Runtime;

[assembly: PartId(PartId.Cli)]

namespace Z0.Parts
{
    public sealed partial class Cli : Part<Cli>
    {

    }
}
