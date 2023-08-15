//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class SpanBlockChecks : Checker<SpanBlockChecks>
    {
        public static void classify_numeric_width()
        {
            NumericClaims.eq(NativeTypeWidth.W8, NumericKind.U8.TypeWidth());
            NumericClaims.eq(NativeTypeWidth.W8, NumericKind.I8.TypeWidth());
            NumericClaims.eq(NativeTypeWidth.W16, NumericKind.U16.TypeWidth());
            NumericClaims.eq(NativeTypeWidth.W16, NumericKind.I16.TypeWidth());
            NumericClaims.eq(NativeTypeWidth.W32, NumericKind.U32.TypeWidth());
            NumericClaims.eq(NativeTypeWidth.W32, NumericKind.I32.TypeWidth());
            NumericClaims.eq(NativeTypeWidth.W32, NumericKind.F32.TypeWidth());
            NumericClaims.eq(NativeTypeWidth.W64, NumericKind.I64.TypeWidth());
            NumericClaims.eq(NativeTypeWidth.W64, NumericKind.U64.TypeWidth());
            NumericClaims.eq(NativeTypeWidth.W64, NumericKind.F64.TypeWidth());
        }

        public static void check_numeric_identity()
        {
            NumericClaims.eq(ScalarKind.U8, NumericKind.U8.ApiKind());
            NumericClaims.eq(ScalarKind.I8, NumericKind.I8.ApiKind());
            NumericClaims.eq(ScalarKind.U16, NumericKind.U16.ApiKind());
            NumericClaims.eq(ScalarKind.I16, NumericKind.I16.ApiKind());
            NumericClaims.eq(ScalarKind.U32, NumericKind.U32.ApiKind());
            NumericClaims.eq(ScalarKind.I32, NumericKind.I32.ApiKind());
            NumericClaims.eq(ScalarKind.U64, NumericKind.U64.ApiKind());
            NumericClaims.eq(ScalarKind.I64, NumericKind.I64.ApiKind());
            NumericClaims.eq(ScalarKind.F32, NumericKind.F32.ApiKind());
            NumericClaims.eq(ScalarKind.F64, NumericKind.F64.ApiKind());
        }

        public static void classify_block_segment_16()
        {
            // NumericClaims.eq(NativeTypes.numkind(typeof(SpanBlock16<byte>)), NumericKind.U8);
            // NumericClaims.eq(NativeTypes.numkind(typeof(SpanBlock16<sbyte>)), NumericKind.I8);
            // NumericClaims.eq(NativeTypes.numkind(typeof(SpanBlock16<ushort>)), NumericKind.U16);
            // NumericClaims.eq(NativeTypes.numkind(typeof(SpanBlock16<short>)), NumericKind.I16);
        }

        public static void classify_block_segment_64()
        {
            // NumericClaims.eq(NativeTypes.numkind(typeof(SpanBlock64<byte>)), NumericKind.U8);
            // NumericClaims.eq(NativeTypes.numkind(typeof(SpanBlock64<sbyte>)), NumericKind.I8);
            // NumericClaims.eq(NativeTypes.numkind(typeof(SpanBlock64<ushort>)), NumericKind.U16);
            // NumericClaims.eq(NativeTypes.numkind(typeof(SpanBlock64<short>)), NumericKind.I16);
            // NumericClaims.eq(NativeTypes.numkind(typeof(SpanBlock64<uint>)), NumericKind.U32);
            // NumericClaims.eq(NativeTypes.numkind(typeof(SpanBlock64<int>)), NumericKind.I32);
            // NumericClaims.eq(NativeTypes.numkind(typeof(SpanBlock64<ulong>)), NumericKind.U64);
            // NumericClaims.eq(NativeTypes.numkind(typeof(SpanBlock64<long>)), NumericKind.I64);
            // NumericClaims.eq(NativeTypes.numkind(typeof(SpanBlock64<float>)), NumericKind.F32);
            // NumericClaims.eq(NativeTypes.numkind(typeof(SpanBlock64<double>)), NumericKind.F64);
        }

        public static void classify_block_segment_128()
        {
            // NumericClaims.eq(NativeTypes.numkind(typeof(SpanBlock128<byte>)), NumericKind.U8);
            // NumericClaims.eq(NativeTypes.numkind(typeof(SpanBlock128<sbyte>)), NumericKind.I8);
            // NumericClaims.eq(NativeTypes.numkind(typeof(SpanBlock128<ushort>)), NumericKind.U16);
            // NumericClaims.eq(NativeTypes.numkind(typeof(SpanBlock128<short>)), NumericKind.I16);
            // NumericClaims.eq(NativeTypes.numkind(typeof(SpanBlock128<uint>)), NumericKind.U32);
            // NumericClaims.eq(NativeTypes.numkind(typeof(SpanBlock128<int>)), NumericKind.I32);
            // NumericClaims.eq(NativeTypes.numkind(typeof(SpanBlock128<ulong>)), NumericKind.U64);
            // NumericClaims.eq(NativeTypes.numkind(typeof(SpanBlock128<long>)), NumericKind.I64);
            // NumericClaims.eq(NativeTypes.numkind(typeof(SpanBlock128<float>)), NumericKind.F32);
            // NumericClaims.eq(NativeTypes.numkind(typeof(SpanBlock128<double>)), NumericKind.F64);
        }

        public static void classify_block_width()
        {
            NumericClaims.eq(NativeTypeWidth.W16, Widths.segmented(typeof(SpanBlock16<byte>)));
            NumericClaims.eq(NativeTypeWidth.W32, Widths.segmented(typeof(SpanBlock32<byte>)));
            NumericClaims.eq(NativeTypeWidth.W64, Widths.segmented(typeof(SpanBlock64<byte>)));
            NumericClaims.eq(NativeTypeWidth.W128, Widths.segmented(typeof(SpanBlock128<byte>)));
            NumericClaims.eq(NativeTypeWidth.W256, Widths.segmented(typeof(SpanBlock256<byte>)));
            NumericClaims.eq(NativeTypeWidth.W512, Widths.segmented(typeof(SpanBlock512<byte>)));

            NumericClaims.eq(NativeTypeWidth.W16, Widths.segmented(typeof(SpanBlock16<>)));
            NumericClaims.eq(NativeTypeWidth.W32, Widths.segmented(typeof(SpanBlock32<>)));
            NumericClaims.eq(NativeTypeWidth.W64, Widths.segmented(typeof(SpanBlock64<>)));
            NumericClaims.eq(NativeTypeWidth.W128, Widths.segmented(typeof(SpanBlock128<>)));
            NumericClaims.eq(NativeTypeWidth.W256, Widths.segmented(typeof(SpanBlock256<>)));
            NumericClaims.eq(NativeTypeWidth.W512, Widths.segmented(typeof(SpanBlock512<>)));
        }

       static bool blocked(Type t)
            => t.IsSpanBlock();

        public static void test_generic_blocks()
        {
            Require.invariant(blocked(typeof(SpanBlock16<>)));
            Require.invariant(blocked(typeof(SpanBlock32<>)));
            Require.invariant(blocked(typeof(SpanBlock64<>)));
            Require.invariant(blocked(typeof(SpanBlock128<>)));
            Require.invariant(blocked(typeof(SpanBlock256<>)));
            Require.invariant(blocked(typeof(SpanBlock512<>)));
        }

        public static void test_block_16()
        {
            Require.invariant(blocked(typeof(SpanBlock16<byte>)));
            Require.invariant(blocked(typeof(SpanBlock16<sbyte>)));
            Require.invariant(blocked(typeof(SpanBlock16<ushort>)));
            Require.invariant(blocked(typeof(SpanBlock16<short>)));
        }

        public static void test_block_32()
        {
            Require.invariant(blocked(typeof(SpanBlock32<byte>)));
            Require.invariant(blocked(typeof(SpanBlock32<sbyte>)));
            Require.invariant(blocked(typeof(SpanBlock32<ushort>)));
            Require.invariant(blocked(typeof(SpanBlock32<short>)));
            Require.invariant(blocked(typeof(SpanBlock32<int>)));
            Require.invariant(blocked(typeof(SpanBlock32<uint>)));
            Require.invariant(blocked(typeof(SpanBlock32<float>)));
        }

        public static void test_block_64()
        {
            Require.invariant(blocked(typeof(SpanBlock64<byte>)));
            Require.invariant(blocked(typeof(SpanBlock64<sbyte>)));
            Require.invariant(blocked(typeof(SpanBlock64<ushort>)));
            Require.invariant(blocked(typeof(SpanBlock64<short>)));
            Require.invariant(blocked(typeof(SpanBlock64<int>)));
            Require.invariant(blocked(typeof(SpanBlock64<uint>)));
            Require.invariant(blocked(typeof(SpanBlock64<long>)));
            Require.invariant(blocked(typeof(SpanBlock64<ulong>)));
            Require.invariant(blocked(typeof(SpanBlock64<float>)));
            Require.invariant(blocked(typeof(SpanBlock64<double>)));
        }

        public static void test_block_128()
        {
            Require.invariant(blocked(typeof(SpanBlock128<byte>)));
            Require.invariant(blocked(typeof(SpanBlock128<sbyte>)));
            Require.invariant(blocked(typeof(SpanBlock128<ushort>)));
            Require.invariant(blocked(typeof(SpanBlock128<short>)));
            Require.invariant(blocked(typeof(SpanBlock128<int>)));
            Require.invariant(blocked(typeof(SpanBlock128<uint>)));
            Require.invariant(blocked(typeof(SpanBlock128<long>)));
            Require.invariant(blocked(typeof(SpanBlock128<ulong>)));
            Require.invariant(blocked(typeof(SpanBlock128<float>)));
            Require.invariant(blocked(typeof(SpanBlock128<double>)));
        }

        public static void classify_block_16()
        {
            // NumericClaims.eq(NativeTypes.segkind(typeof(SpanBlock16<byte>)), NativeSegKind.Seg16x8u);
            // NumericClaims.eq(NativeTypes.segkind(typeof(SpanBlock16<sbyte>)), NativeSegKind.Seg16x8i);
            // NumericClaims.eq(NativeTypes.segkind(typeof(SpanBlock16<ushort>)), NativeSegKind.Seg16u);
            // NumericClaims.eq(NativeTypes.segkind(typeof(SpanBlock16<short>)), NativeSegKind.Seg16i);
        }

        static void classify_block_32()
        {
            NumericClaims.eq(NativeSigs.segkind(typeof(SpanBlock32<byte>)), NativeSegKind.Seg32x8u);
            NumericClaims.eq(NativeSigs.segkind(typeof(SpanBlock32<sbyte>)), NativeSegKind.Seg32x8i);
            NumericClaims.eq(NativeSigs.segkind(typeof(SpanBlock32<ushort>)), NativeSegKind.Seg32x16u);
            NumericClaims.eq(NativeSigs.segkind(typeof(SpanBlock32<short>)), NativeSegKind.Seg32x16i);
            NumericClaims.eq(NativeSigs.segkind(typeof(SpanBlock32<uint>)), NativeSegKind.Seg32u);
            NumericClaims.eq(NativeSigs.segkind(typeof(SpanBlock32<int>)), NativeSegKind.Seg32i);
            NumericClaims.eq(NativeSigs.segkind(typeof(SpanBlock32<float>)), NativeSegKind.Seg32f);
        }

        static void classify_block_64()
        {
            NumericClaims.eq(NativeSigs.segkind(typeof(SpanBlock64<byte>)), NativeSegKind.Seg64x8u);
            NumericClaims.eq(NativeSigs.segkind(typeof(SpanBlock64<sbyte>)), NativeSegKind.Seg64x8i);
            NumericClaims.eq(NativeSigs.segkind(typeof(SpanBlock64<ushort>)), NativeSegKind.Seg64x16u);
            NumericClaims.eq(NativeSigs.segkind(typeof(SpanBlock64<short>)), NativeSegKind.Seg64x16i);
            NumericClaims.eq(NativeSigs.segkind(typeof(SpanBlock64<uint>)), NativeSegKind.Seg64x32u);
            NumericClaims.eq(NativeSigs.segkind(typeof(SpanBlock64<int>)), NativeSegKind.Seg64x32i);
            NumericClaims.eq(NativeSigs.segkind(typeof(SpanBlock64<ulong>)), NativeSegKind.Seg64u);
            NumericClaims.eq(NativeSigs.segkind(typeof(SpanBlock64<long>)), NativeSegKind.Seg64i);
            NumericClaims.eq(NativeSigs.segkind(typeof(SpanBlock64<float>)), NativeSegKind.Seg64x32f);
            NumericClaims.eq(NativeSigs.segkind(typeof(SpanBlock64<double>)), NativeSegKind.Seg64f);
        }

        static void classify_block_128()
        {
            NumericClaims.eq(NativeSigs.segkind(typeof(SpanBlock128<byte>)), NativeSegKind.Seg128x8u);
            NumericClaims.eq(NativeSigs.segkind(typeof(SpanBlock128<sbyte>)), NativeSegKind.Seg128x8i);
            NumericClaims.eq(NativeSigs.segkind(typeof(SpanBlock128<ushort>)), NativeSegKind.Seg128x16u);
            NumericClaims.eq(NativeSigs.segkind(typeof(SpanBlock128<short>)), NativeSegKind.Seg128x16i);
            NumericClaims.eq(NativeSigs.segkind(typeof(SpanBlock128<uint>)), NativeSegKind.Seg128x32u);
            NumericClaims.eq(NativeSigs.segkind(typeof(SpanBlock128<int>)), NativeSegKind.Seg128x32i);
            NumericClaims.eq(NativeSigs.segkind(typeof(SpanBlock128<ulong>)), NativeSegKind.Seg128x64u);
            NumericClaims.eq(NativeSigs.segkind(typeof(SpanBlock128<long>)), NativeSegKind.Seg128x64i);
            NumericClaims.eq(NativeSigs.segkind(typeof(SpanBlock128<float>)), NativeSegKind.Seg128x32f);
            NumericClaims.eq(NativeSigs.segkind(typeof(SpanBlock128<double>)), NativeSegKind.Seg128x64f);
        }

        static void classify_block_256()
        {
            NumericClaims.eq(NativeSigs.segkind(typeof(SpanBlock256<byte>)), NativeSegKind.Seg256x8u);
            NumericClaims.eq(NativeSigs.segkind(typeof(SpanBlock256<sbyte>)), NativeSegKind.Seg256x8i);
            NumericClaims.eq(NativeSigs.segkind(typeof(SpanBlock256<ushort>)), NativeSegKind.Seg256x16u);
            NumericClaims.eq(NativeSigs.segkind(typeof(SpanBlock256<short>)), NativeSegKind.Seg256x16i);
            NumericClaims.eq(NativeSigs.segkind(typeof(SpanBlock256<uint>)), NativeSegKind.Seg256x32u);
            NumericClaims.eq(NativeSigs.segkind(typeof(SpanBlock256<int>)), NativeSegKind.Seg256x32i);
            NumericClaims.eq(NativeSigs.segkind(typeof(SpanBlock256<ulong>)), NativeSegKind.Seg256x64u);
            NumericClaims.eq(NativeSigs.segkind(typeof(SpanBlock256<long>)), NativeSegKind.Seg256x64i);
            NumericClaims.eq(NativeSigs.segkind(typeof(SpanBlock256<float>)), NativeSegKind.Seg256x32f);
            NumericClaims.eq(NativeSigs.segkind(typeof(SpanBlock256<double>)), NativeSegKind.Seg256x64f);
        }

    }
}