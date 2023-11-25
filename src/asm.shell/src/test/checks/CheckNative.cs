//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

sealed class CheckNative : Checker<CheckNative>
{
    [CmdOp("native/checks")]
    void RunNativeChecks()
    {
        var t0 = NativeTypes.seg(NativeSegKind.Seg128x16i);
        Channel.Write(t0.Format());

        var t1 = NativeTypes.seg(NativeSegKind.Seg16u);
        Channel.Write(t1.Format());
    }

    [CmdOp("check/ancestry/parsers")]
    public void CheckAncestryParsers()
    {
        const string LineFormat = "{0,-32} {1}";
        const string Case0 = "a -> b -> c -> d -> e";
        const string Case1 = "f -> g -> h -> i -> j -> k -> l -> m";
        const string Case2 = "n -> o -> p -> q -> r -> s -> t";
        const string Case3 = "u -> v -> w -> x -> y -> z";

        var dst = text.emitter();
        using var dispenser = Dispense.labels();
        var ancestors = Ancestors.create(dispenser);

        ancestors.Parse(Case0, out var @case0);
        RequireEq(@case0.Format(), Case0);
        dst.AppendLineFormat(LineFormat, nameof(CheckAncestryParsers), $"'{Case0}' == '{@case0}'");

        ancestors.Parse(Case1, out var @case1);
        RequireEq(@case1.Format(), Case1);
        dst.AppendLineFormat(LineFormat, nameof(CheckAncestryParsers), $"'{Case1}' = '{@case1}'");

        ancestors.Parse(Case2, out var @case2);
        RequireEq(@case2.Format(), Case2);
        dst.AppendLineFormat(LineFormat, nameof(CheckAncestryParsers), $"'{Case2}' = '{@case2}'");

        ancestors.Parse(Case3, out var @case3);
        RequireEq(@case3.Format(), Case3);
        dst.AppendLineFormat(LineFormat, nameof(CheckAncestryParsers), $"'{Case3}' = '{@case3}'");

        Channel.Row(dst.Emit());
    }
}
