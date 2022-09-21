//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class t_classify : t_inx<t_classify>
    {
        public static void classify_vector()
        {
            NumericClaims.eq(VK.kind(typeof(Vector128<byte>)), NativeVectorKind.v128x8u);
            NumericClaims.eq(VK.kind(typeof(Vector128<sbyte>)), NativeVectorKind.v128x8i);
            NumericClaims.eq(VK.kind(typeof(Vector128<ushort>)), NativeVectorKind.v128x16u);
            NumericClaims.eq(VK.kind(typeof(Vector128<short>)), NativeVectorKind.v128x16i);
            NumericClaims.eq(VK.kind(typeof(Vector128<uint>)), NativeVectorKind.v128x32u);
            NumericClaims.eq(VK.kind(typeof(Vector128<int>)), NativeVectorKind.v128x32i);
            NumericClaims.eq(VK.kind(typeof(Vector128<ulong>)), NativeVectorKind.v128x64u);
            NumericClaims.eq(VK.kind(typeof(Vector128<long>)), NativeVectorKind.v128x64i);
            NumericClaims.eq(VK.kind(typeof(Vector128<float>)), NativeVectorKind.v128x32f);
            NumericClaims.eq(VK.kind(typeof(Vector128<double>)), NativeVectorKind.v128x64f);

            NumericClaims.eq(VK.kind(typeof(Vector256<byte>)), NativeVectorKind.v256x8u);
            NumericClaims.eq(VK.kind(typeof(Vector256<sbyte>)), NativeVectorKind.v256x8i);
            NumericClaims.eq(VK.kind(typeof(Vector256<ushort>)), NativeVectorKind.v256x16u);
            NumericClaims.eq(VK.kind(typeof(Vector256<short>)), NativeVectorKind.v256x16i);
            NumericClaims.eq(VK.kind(typeof(Vector256<uint>)), NativeVectorKind.v256x32u);
            NumericClaims.eq(VK.kind(typeof(Vector256<int>)), NativeVectorKind.v256x32i);
            NumericClaims.eq(VK.kind(typeof(Vector256<ulong>)), NativeVectorKind.v256x64u);
            NumericClaims.eq(VK.kind(typeof(Vector256<long>)), NativeVectorKind.v256x64i);
            NumericClaims.eq(VK.kind(typeof(Vector256<float>)), NativeVectorKind.v256x32f);
            NumericClaims.eq(VK.kind(typeof(Vector256<double>)), NativeVectorKind.v256x64f);
        }

        public static void classify_vector_type()
        {
            NumericClaims.eq(VK.kind(typeof(Vector128<sbyte>)), NativeVectorKind.v128x8i);
            NumericClaims.eq(VK.kind(typeof(Vector128<byte>)), NativeVectorKind.v128x8u);

            NumericClaims.eq(VK.kind(typeof(Vector128<short>)), NativeVectorKind.v128x16i);
            NumericClaims.eq(VK.kind(typeof(Vector128<ushort>)), NativeVectorKind.v128x16u);

            NumericClaims.eq(VK.kind(typeof(Vector128<int>)), NativeVectorKind.v128x32i);
            NumericClaims.eq(VK.kind(typeof(Vector128<uint>)), NativeVectorKind.v128x32u);
            NumericClaims.eq(VK.kind(typeof(Vector128<float>)), NativeVectorKind.v128x32f);

            NumericClaims.eq(VK.kind(typeof(Vector128<ulong>)), NativeVectorKind.v128x64u);
            NumericClaims.eq(VK.kind(typeof(Vector128<long>)), NativeVectorKind.v128x64i);
            NumericClaims.eq(VK.kind(typeof(Vector128<double>)), NativeVectorKind.v128x64f);

            NumericClaims.eq(VK.kind(typeof(Vector256<sbyte>)), NativeVectorKind.v256x8i);
            NumericClaims.eq(VK.kind(typeof(Vector256<byte>)), NativeVectorKind.v256x8u);

            NumericClaims.eq(VK.kind(typeof(Vector256<short>)), NativeVectorKind.v256x16i);
            NumericClaims.eq(VK.kind(typeof(Vector256<ushort>)), NativeVectorKind.v256x16u);

            NumericClaims.eq(VK.kind(typeof(Vector256<int>)), NativeVectorKind.v256x32i);
            NumericClaims.eq(VK.kind(typeof(Vector256<uint>)), NativeVectorKind.v256x32u);
            NumericClaims.eq(VK.kind(typeof(Vector256<float>)), NativeVectorKind.v256x32f);

            NumericClaims.eq(VK.kind(typeof(Vector256<ulong>)), NativeVectorKind.v256x64u);
            NumericClaims.eq(VK.kind(typeof(Vector256<long>)), NativeVectorKind.v256x64i);
            NumericClaims.eq(VK.kind(typeof(Vector256<double>)), NativeVectorKind.v256x64f);
        }
    }
}