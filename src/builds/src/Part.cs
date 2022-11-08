//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
global using NuGet.Packaging;
global using NuGet.Packaging.Core;
global using NuGet.Protocol;
global using NuGet.Protocol.Core.Types;
global using NuGet.Versioning;
global using System.Text.Json;
global using System.Text.Json.Nodes;
global using System.Text.Json.Serialization;

global using BuildTask = Microsoft.Build.Utilities.Task;

[assembly: PartId(PartId.Builds)]
namespace Z0.Parts
{
    public sealed class Builds : Part<Builds>
    {

    }
}