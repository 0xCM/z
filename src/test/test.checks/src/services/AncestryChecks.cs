//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public sealed class AncestryChecks : Checker<AncestryChecks>
    {
        [CmdOp("native/checks")]
        void RunNativeChecks()
        {
            var t0 = NativeTypes.seg(NativeSegKind.Seg128x16i);
            Write(t0.Format());

            var t1 = NativeTypes.seg(NativeSegKind.Seg16u);
            Write(t1.Format());

            CheckNativeAlloc();
        }

        void CheckNativeAlloc()
        {
            var n = n16;
            var count = Numbers.count(n);
            byte length = (byte)n;
            var result = Outcome.Success;
            using var native = NativeCells.alloc<string>(count, out var id);
            var bits = PolyBits.bitstrings(n);
            for(var i=0u; i<count; i++)
            {
                var offset = i*n;
                native.Content(i) = new string(slice(bits, offset, n));
            }
        }

        [CmdOp("check/parsers")]
        public void CheckParser()
        {
            const string Case0 = "a -> b -> c -> d -> e";
            const string Case1 = "f -> g -> h -> i -> j -> k -> l -> m";
            const string Case2 = "n -> o -> p -> q -> r -> s -> t";
            const string Case3 = "u -> v -> w -> x -> y -> z";

            using var dispenser = Dispense.labels();
            var ancestors = Ancestors.create(dispenser);

            ancestors.Parse(Case0, out var @case0);
            ancestors.Parse(Case1, out var @case1);
            ancestors.Parse(Case2, out var @case2);
            ancestors.Parse(Case3, out var @case3);

            RequireEq(@case0.Format(), Case0);
            RequireEq(@case1.Format(), Case1);
            RequireEq(@case2.Format(), Case2);
            RequireEq(@case3.Format(), Case3);
        }
    }
}