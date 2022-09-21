//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.Intrinsics;

    using static Root;
    using static core;

    public class t_cell_type : t_inx<t_cell_type>
    {
        public void check_cell_types()
        {
            var v128 = VK.Types128();
            var v256 = VK.Types256();
            iter(v128, t => check_cell_type(t, w128));
            iter(v256, t => check_cell_type(t, w256));
        }

        void check_cell_type(Type tVector, W128 w)
        {
            var kVector = VK.kind(tVector);
            Claim.yea(kVector != 0);
            var tCell = kVector.CellType();

            if(TraceDetailEnabled)
            {
                Notify($"tVector := {tVector.DisplayName()}");
                Notify($"kVector := {kVector}");
                Notify($"tCell := {tCell.Name}");
            }

            Claim.require(tCell.IsNonEmpty());

            if(tVector == typeof(Vector128<sbyte>))
            {
                Claim.require(tCell == typeof(sbyte));
                Claim.eq(NativeVectorKind.v128x8i, kVector);
            }
            else if(tVector == typeof(Vector128<byte>))
            {
                Claim.require(tCell == typeof(byte));
                Claim.eq(NativeVectorKind.v128x8u, kVector);
            }
            else if(tVector == typeof(Vector128<short>))
            {
                Claim.require(tCell == typeof(short));
                Claim.eq(NativeVectorKind.v128x16i, kVector);
            }
            else if(tVector == typeof(Vector128<ushort>))
            {
                Claim.require(tCell == typeof(ushort));
                Claim.eq(NativeVectorKind.v128x16u, kVector);
            }
            else if(tVector == typeof(Vector128<int>))
            {
                Claim.require(tCell == typeof(int));
                Claim.eq(NativeVectorKind.v128x32i, kVector);
            }
            else if(tVector == typeof(Vector128<uint>))
            {
                Claim.require(tCell == typeof(uint));
                Claim.eq(NativeVectorKind.v128x32u, kVector);
            }
            else if(tVector == typeof(Vector128<long>))
            {
                Claim.require(tCell == typeof(long));
                Claim.eq(NativeVectorKind.v128x64i, kVector);
            }
            else if(tVector == typeof(Vector128<ulong>))
            {
                Claim.require(tCell == typeof(ulong));
                Claim.eq(NativeVectorKind.v128x64u, kVector);
            }
            else if(tVector == typeof(Vector128<float>))
            {
                Claim.require(tCell == typeof(float));
                Claim.eq(NativeVectorKind.v128x32f, kVector);
            }
            else if(tVector == typeof(Vector128<double>))
            {
                Claim.require(tCell == typeof(double));
                Claim.eq(NativeVectorKind.v128x64f, kVector);
            }
            else
            {
                Notify($"{tVector.DisplayName()} is not a recognized 128-bit vector type");
                Claim.fail();
            }
        }

        void check_cell_type(Type tVector, N256 w)
        {
            var kVector = VK.kind(tVector);
            Claim.yea(kVector != 0);

            var tCell = kVector.CellType();

            if(TraceDetailEnabled)
            {
                Notify($"tVector := {tVector.DisplayName()}");
                Notify($"kVector := {kVector}");
                Notify($"tCell := {tCell.Name}");
            }

            Claim.require(tCell.IsNonEmpty());

            if(tVector == typeof(Vector256<sbyte>))
            {
                Claim.require(tCell == typeof(sbyte));
                Claim.eq(NativeVectorKind.v256x8i, kVector);
            }
            else if(tVector == typeof(Vector256<byte>))
            {
                Claim.require(tCell == typeof(byte));
                Claim.eq(NativeVectorKind.v256x8u, kVector);
            }
            else if(tVector == typeof(Vector256<short>))
            {
                Claim.require(tCell == typeof(short));
                Claim.eq(NativeVectorKind.v256x16i, kVector);
            }
            else if(tVector == typeof(Vector256<ushort>))
            {
                Claim.require(tCell == typeof(ushort));
                Claim.eq(NativeVectorKind.v256x16u, kVector);
            }
            else if(tVector == typeof(Vector256<int>))
            {
                Claim.require(tCell == typeof(int));
                Claim.eq(NativeVectorKind.v256x32i, kVector);
            }
            else if(tVector == typeof(Vector256<uint>))
            {
                Claim.require(tCell == typeof(uint));
                Claim.eq(NativeVectorKind.v256x32u, kVector);
            }
            else if(tVector == typeof(Vector256<long>))
            {
                Claim.require(tCell == typeof(long));
                Claim.eq(NativeVectorKind.v256x64i, kVector);
            }
            else if(tVector == typeof(Vector256<ulong>))
            {
                Claim.require(tCell == typeof(ulong));
                Claim.eq(NativeVectorKind.v256x64u, kVector);
            }
            else if(tVector == typeof(Vector256<float>))
            {
                Claim.require(tCell == typeof(float));
                Claim.eq(NativeVectorKind.v256x32f, kVector);
            }
            else if(tVector == typeof(Vector256<double>))
            {
                Claim.require(tCell == typeof(double));
                Claim.eq(NativeVectorKind.v256x64f, kVector);
            }
            else
            {
                Notify($"{tVector.DisplayName()} is not a recognized 256-bit vector type");
                Claim.fail();
            }
        }
    }
}