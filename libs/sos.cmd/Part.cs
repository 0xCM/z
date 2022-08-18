//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
global using System.IO;
global using Microsoft.DiaSymReader;
global using Microsoft.CodeAnalysis;
//global using Microsoft.DiaSymReader.PortablePdb;
global using Microsoft.Diagnostics.Symbols;
//global using Microsoft.DiaSymReader.Tools;

[assembly: PartId(PartId.SosCmd)]

namespace Z0.Parts
{
    public sealed class SosCmd : Part<SosCmd>
    {

    }
}
