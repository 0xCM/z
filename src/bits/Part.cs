//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
// global using gcpu = Z0.vgcpu;
// global using cpu = Z0.vcpu;
// global using core = Z0.sys;

[assembly: PartId(PartId.Bits)]
namespace Z0.Parts
{
    public sealed partial class Bits : Part<Bits>
    {
        public static BitsAssets Assets = new();
    }

    public sealed class BitsAssets : Assets<BitsAssets>
    {
        public Asset NumN() => Asset("numN.txt");
    }
}

namespace Z0
{
    [ApiHost]
    public static partial class XTend
    {
        const NumericKind Closure = Root.UnsignedInts;
    }

    partial struct Msg
    {
        const NumericKind Closure = Root.UnsignedInts;
    }
}