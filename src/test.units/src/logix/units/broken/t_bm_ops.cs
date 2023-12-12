//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static BinaryBitLogicKind;

    public class t_bm_ops : t_logix<t_bm_ops>
    {
        public override bool Enabled => false;

        public void bm_not_check()
        {
            bm_not_check<N8,byte>();
            bm_not_check<N16,ushort>();
            bm_not_check<N32,uint>();
            bm_not_check<N64,ulong>();
        }

        public void bm_and_check()
        {
            bm_and_check<N8,byte>();
            bm_and_check<N16,ushort>();
            bm_and_check<N32,uint>();
            bm_and_check<N64,ulong>();
        }

        public void bm_nand_check()
        {
            bm_nand_check<N8,byte>();
            bm_nand_check<N16,ushort>();
            bm_nand_check<N32,uint>();
            bm_nand_check<N64,ulong>();
        }

        public void bm_or_check()
        {
            bm_or_check<N8,byte>();
            bm_or_check<N16,ushort>();
            bm_or_check<N32,uint>();
            bm_or_check<N64,ulong>();
        }

        public void bm_nor_check()
        {
            bm_nor_check<N8,byte>();
            bm_nor_check<N16,ushort>();
            bm_nor_check<N32,uint>();
            bm_nor_check<N64,ulong>();
        }

        public void bm_xor_check()
        {
            bm_xor_check<N8,byte>();
            bm_xor_check<N16,ushort>();
            bm_xor_check<N32,uint>();
            bm_xor_check<N64,ulong>();
        }

        public void bm_xnor_check()
        {
            bm_xnor_check<N8,byte>();
            bm_xnor_check<N16,ushort>();
            bm_xnor_check<N32,uint>();
            bm_xnor_check<N64,ulong>();
        }

        public void bm_imply_check()
        {
            bm_imply_check<N8,byte>();
            bm_imply_check<N16,ushort>();
            bm_imply_check<N32,uint>();
            bm_imply_check<N64,ulong>();
        }

        public void bm_notimply_check()
        {
            bm_notimply_check<N8,byte>();
            bm_notimply_check<N16,ushort>();
            bm_notimply_check<N32,uint>();
            bm_notimply_check<N64,ulong>();
        }

        public void bm_and_bench()
        {
            bm_and_bench<ulong>();
            bm_api_bench<ulong>(And);
            bm_delegate_bench<ulong>(And);
        }

        public void bm_xor_bench()
        {
            bm_xor_bench<ulong>();
            bm_api_bench<ulong>(Xor);
            bm_delegate_bench<ulong>(Xor);
        }

        protected void bm_xor_bench<T>(SystemCounter clock = default)
            where T : unmanaged, IEquatable<T>
        {
            var opname = $"bm_xor_{TypeIdentity.numeric<T>()}";

            var A = Random.BitMatrix<T>();
            var B = Random.BitMatrix<T>();
            var C = Random.BitMatrix<T>();
            var Z = BitMatrix.alloc<T>();
            var opcount = 0;

            clock.Start();

            for(var i=0; i<CycleCount; i++)
            {
                SquareBitLogix.xor(A, B, Z);
                opcount++;
                for(var sample=0; sample< RepCount; sample++)
                {
                    SquareBitLogix.xor(Z, A, Z);
                    SquareBitLogix.xor(B, Z, Z);
                    opcount +=2;
                }
            }

            clock.Stop();

            ReportBenchmark(opname, opcount, clock);
        }

        void bm_and_bench<T>(SystemCounter clock = default)
            where T : unmanaged, IEquatable<T>
        {
            var opname = $"bm_and_{TypeIdentity.numeric<T>()}";

            var A = Random.BitMatrix<T>();
            var B = Random.BitMatrix<T>();
            var C = Random.BitMatrix<T>();
            var Z = BitMatrix.alloc<T>();
            var opcount = 0;

            clock.Start();

            for(var i=0; i<CycleCount; i++)
            {
                SquareBitLogix.and(A, B, Z);
                opcount++;
                for(var sample=0; sample< RepCount; sample++)
                {
                    SquareBitLogix.and(Z, A, Z);
                    SquareBitLogix.and(B, Z, Z);
                    opcount +=2;
                }
            }

            clock.Stop();

            ReportBenchmark(opname, opcount, clock);
        }

         protected void bm_and_check<N,T>(BinaryBitLogicKind op = And)
            where T : unmanaged, IEquatable<T>
            where N : unmanaged, ITypeNat
        {
            var A = Random.BitMatrix<T>();
            var B = Random.BitMatrix<T>();
            var C = BitMatrix.alloc<T>();
            var n = nat32i<N>();

            for(var sample=0; sample<RepCount; sample++)
            {
                SquareBitLogix.eval(op, A, B, C);
                for(var i=0; i<n; i++)
                {
                    var expect = A[i] & B[i];
                    var actual = C[i];
                    Claim.eq(expect, actual);
                }

                Random.BitMatrix(ref A);
                Random.BitMatrix(ref B);
            }
        }

        void bm_xor_check<N,T>(BinaryBitLogicKind op = Xor)
            where T : unmanaged, IEquatable<T>
            where N : unmanaged, ITypeNat
        {
            var A = Random.BitMatrix<T>();
            var B = Random.BitMatrix<T>();
            var C = BitMatrix.alloc<T>();
            var n = nat32i<N>();

            for(var sample=0; sample < RepCount; sample++)
            {
                SquareBitLogix.eval(op, A, B, C);
                for(var i=0; i<n; i++)
                {
                    var expect = A[i] ^ B[i];
                    var actual = C[i];
                    Claim.eq(expect, actual);
                }

                Random.BitMatrix(ref A);
                Random.BitMatrix(ref B);
            }
        }

        void bm_imply_check<N,T>(BinaryBitLogicKind op = Impl)
            where T : unmanaged, IEquatable<T>
            where N : unmanaged, ITypeNat
        {
            var A = Random.BitMatrix<T>();
            var B = Random.BitMatrix<T>();
            var C = BitMatrix.alloc<T>();
            var n = sys.nat32i<N>();

            for(var sample=0; sample < RepCount; sample++)
            {
                SquareBitLogix.eval(op, A, B, C);
                for(var i=0; i<n; i++)
                {
                    var expect = ScalarBits.impl(A[i], B[i]);
                    var actual = C[i];
                    Claim.eq(expect, actual);
                }

                Random.BitMatrix(ref A);
                Random.BitMatrix(ref B);
            }
        }

        void bm_notimply_check<N,T>(BinaryBitLogicKind op = NonImpl)
            where T : unmanaged, IEquatable<T>
            where N : unmanaged, ITypeNat
        {
            var A = Random.BitMatrix<T>();
            var B = Random.BitMatrix<T>();
            var C = BitMatrix.alloc<T>();
            var n = nat32i<N>();

            for(var sample=0; sample < RepCount; sample++)
            {
                SquareBitLogix.eval(op, A, B, C);
                for(var i=0; i<n; i++)
                {
                    var expect = ScalarBits.nonimpl(A[i], B[i]);
                    var actual = C[i];
                    Claim.eq(expect,actual);
                }

                Random.BitMatrix(ref A);
                Random.BitMatrix(ref B);
            }
        }

        void bm_xnor_check<N,T>(BinaryBitLogicKind op = Xnor)
            where T : unmanaged, IEquatable<T>
            where N : unmanaged, ITypeNat
        {
            var A = Random.BitMatrix<T>();
            var B = Random.BitMatrix<T>();
            var C = BitMatrix.alloc<T>();
            var n = nat32i<N>();

            for(var sample=0; sample < RepCount; sample++)
            {
                SquareBitLogix.eval(op, A, B, C);
                for(var i=0; i<n; i++)
                {
                    var expect = BitVectors.xnor(A[i], B[i]);
                    var actual = C[i];
                    Claim.eq(expect, actual);
                }

                Random.BitMatrix(ref A);
                Random.BitMatrix(ref B);
            }
        }

        protected void bm_not_check<N,T>(BinaryBitLogicKind op = LNot)
            where T : unmanaged, IEquatable<T>
            where N : unmanaged, ITypeNat
        {
            var A = Random.BitMatrix<T>();
            var B = Random.BitMatrix<T>();
            var C = BitMatrix.alloc<T>();
            var n = nat32i<N>();

            for(var sample=0; sample < RepCount; sample++)
            {
                SquareBitLogix.eval(op, A, B, C);
                for(var i=0; i<n; i++)
                {
                    var expect = BitVectors.not(A[i]);
                    var actual = C[i];
                    Claim.eq(expect, actual);
                }

                Random.BitMatrix(ref A);
                Random.BitMatrix(ref B);
            }
        }

         protected void bm_nand_check<N,T>(BinaryBitLogicKind op = Nand)
            where T : unmanaged, IEquatable<T>
            where N : unmanaged, ITypeNat
        {
            var A = Random.BitMatrix<T>();
            var B = Random.BitMatrix<T>();
            var C = BitMatrix.alloc<T>();
            var n = nat32i<N>();

            for(var sample=0; sample< RepCount; sample++)
            {
                SquareBitLogix.eval(op, A, B, C);
                for(var i=0; i<n; i++)
                {
                    var expect = ScalarBits.nand(A[i], B[i]);
                    var actual = C[i];
                    Claim.eq(expect, actual);
                }

                Random.BitMatrix(ref A);
                Random.BitMatrix(ref B);
            }
        }


         protected void bm_or_check<N,T>(BinaryBitLogicKind op = Or)
            where T : unmanaged, IEquatable<T>
            where N : unmanaged, ITypeNat
        {
            var A = Random.BitMatrix<T>();
            var B = Random.BitMatrix<T>();
            var C = BitMatrix.alloc<T>();
            var n = nat32i<N>();

            for(var sample=0; sample< RepCount; sample++)
            {
                SquareBitLogix.eval(op, A, B, C);
                for(var i=0; i<n; i++)
                {
                    var expect = A[i] | B[i];
                    var actual = C[i];
                    Claim.eq(expect, actual);
                }

                Random.BitMatrix(ref A);
                Random.BitMatrix(ref B);
            }
        }

         protected void bm_nor_check<N,T>(BinaryBitLogicKind op = Nor)
            where T : unmanaged, IEquatable<T>
            where N : unmanaged, ITypeNat
        {
            var A = Random.BitMatrix<T>();
            var B = Random.BitMatrix<T>();
            var C = BitMatrix.alloc<T>();
            var n = nat32i<N>();

            for(var sample=0; sample<RepCount; sample++)
            {
                SquareBitLogix.eval(op, A, B, C);
                for(var i=0; i<n; i++)
                {
                    var expect = ScalarBits.nor(A[i], B[i]);
                    var actual = C[i];
                    Claim.eq(expect, actual);
                }

                Random.BitMatrix(ref A);
                Random.BitMatrix(ref B);
            }
        }

        void bm_api_bench<T>(BinaryBitLogicKind op, SystemCounter clock = default)
            where T : unmanaged, IEquatable<T>
        {
            var opname = $"bm_{op.Format()}_{TypeIdentity.numeric<T>()}_api";

            var A = Random.BitMatrix<T>();
            var B = Random.BitMatrix<T>();
            var C = Random.BitMatrix<T>();
            var Z = BitMatrix.alloc<T>();
            var opcount = 0;

            clock.Start();

            for(var i=0; i<CycleCount; i++)
            {
                // C = SquareBitLogix.eval(op, A, B, Z);
                // opcount++;
                // for(var sample=0; sample< RepCount; sample++)
                // {
                //     SquareBitLogix.eval(op, Z, A, Z);
                //     SquareBitLogix.eval(op, B, Z, Z);
                //     opcount +=2;
                // }
            }

            clock.Stop();

            ReportBenchmark(opname, opcount, clock);
        }

        void bm_delegate_bench<T>(BinaryBitLogicKind opkind, SystemCounter clock = default)
            where T : unmanaged, IEquatable<T>
        {
            var opname = $"bm_{opkind.Format()}_{TypeIdentity.numeric<T>()}_delegate";
            var A = Random.BitMatrix<T>();
            var B = Random.BitMatrix<T>();
            var C = Random.BitMatrix<T>();
            var Z = BitMatrix.alloc<T>();
            var opcount = 0;
            var Op = SquareBitLogix.lookup<T>(opkind);

            clock.Start();

            for(var i=0; i<CycleCount; i++)
            {
                Op(A, B, Z);
                opcount++;
                for(var sample=0; sample< RepCount; sample++)
                {
                    Op(Z, A, Z);
                    Op(B, Z, Z);
                    opcount +=2;
                }
            }

            clock.Stop();

            ReportBenchmark(opname, opcount, clock);
        }
    }
}