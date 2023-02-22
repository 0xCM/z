//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.Intrinsics;
    using static BinaryBitLogicKind;

    /// <summary>
    /// Verifies the bit-level equivalence of the binary bitwise operators and the binary logical operators
    /// </summary>
    public class t_bitwise_logic : t_logix<t_bitwise_logic>
    {
        public void bwl_and_check()
        {
            var op = And;
            bitwise_logic_check<byte>(op);
            bitwise_logic_check<ushort>(op);
            bitwise_logic_check<uint>(op);
            bitwise_logic_check<ulong>(op);
        }

        public void bwl_nand_check()
        {
            var op = Nand;
            bitwise_logic_check<byte>(op);
            bitwise_logic_check<ushort>(op);
            bitwise_logic_check<uint>(op);
            bitwise_logic_check<ulong>(op);
        }

        public void bwl_or_check()
        {
            var op = Or;
            bitwise_logic_check<byte>(op);
            bitwise_logic_check<ushort>(op);
            bitwise_logic_check<uint>(op);
            bitwise_logic_check<ulong>(op);
        }

        public void bwl_nor_check()
        {
            var op = Nor;
            bitwise_logic_check<byte>(op);
            bitwise_logic_check<ushort>(op);
            bitwise_logic_check<uint>(op);
            bitwise_logic_check<ulong>(op);
        }

        public void bwl_xor_check()
        {
            var op = Xor;
            bitwise_logic_check<byte>(op);
            bitwise_logic_check<ushort>(op);
            bitwise_logic_check<uint>(op);
            bitwise_logic_check<ulong>(op);
        }

        public void bwl_xnor_check()
        {
            var op = Xnor;
            bitwise_logic_check<byte>(op);
            bitwise_logic_check<ushort>(op);
            bitwise_logic_check<uint>(op);
            bitwise_logic_check<ulong>(op);
        }

        public void bwl_lnot_check()
        {
            var op = LNot;
            bitwise_logic_check<byte>(op);
            bitwise_logic_check<ushort>(op);
            bitwise_logic_check<uint>(op);
            bitwise_logic_check<ulong>(op);
        }

        public void bwl_rnot_check()
        {
            var op = RNot;
            bitwise_logic_check<byte>(op);
            bitwise_logic_check<ushort>(op);
            bitwise_logic_check<uint>(op);
            bitwise_logic_check<ulong>(op);
        }

        public void bwl_imply_check()
        {
            var op = Impl;
            bitwise_logic_check<byte>(op);
            bitwise_logic_check<ushort>(op);
            bitwise_logic_check<uint>(op);
            bitwise_logic_check<ulong>(op);
        }

        public void bwl_notimply_check()
        {
            var op = NonImpl;
            bitwise_logic_check<byte>(op);
            bitwise_logic_check<ushort>(op);
            bitwise_logic_check<uint>(op);
            bitwise_logic_check<ulong>(op);
        }

        public void bwl_cimply_check()
        {
            var op = CImpl;
            bitwise_logic_check<byte>(op);
            bitwise_logic_check<ushort>(op);
            bitwise_logic_check<uint>(op);
            bitwise_logic_check<ulong>(op);
        }

        public void bwl_cnotimply_check()
        {
            var op = CNonImpl;
            bitwise_logic_check<byte>(op);
            bitwise_logic_check<ushort>(op);
            bitwise_logic_check<uint>(op);
            bitwise_logic_check<ulong>(op);
        }

       protected void bitwise_logic_check<T>(BinaryBitLogicKind kind)
            where T : unmanaged
        {
            for(var i=0; i< RepCount; i++)
            {
                var a = Random.Next<T>();
                var b = Random.Next<T>();
                var result1 = NumericLogixHost.eval(kind,a,b);
                var result2 = BitVectorLogix.Service.EvalDirect(kind, ScalarBits.alloc(a), ScalarBits.alloc(b)).State;
                var result3 = BitVectorLogix.Service.EvalRef(kind, ScalarBits.alloc(a), ScalarBits.alloc(b)).State;
                var result4 = VLogixOps.eval(kind, gcpu.vbroadcast(n128,a), gcpu.vbroadcast(n128,b)).ToScalar();
                var result5 = VLogixOps.eval(kind, gcpu.vbroadcast(n256,a), gcpu.vbroadcast(n256,b)).ToScalar();
                Claim.eq(result1, result2);
                Claim.eq(result2, result3);
                Claim.eq(result3, result4);
                Claim.eq(result4, result5);
            }
        }
    }
}