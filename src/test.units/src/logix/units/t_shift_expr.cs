//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Logix
{
    using System.Runtime.Intrinsics;

    using static TypedLogicSpec;

    using AK = BitShiftClass;

    public class t_shift_expr : t_typed_logix<t_shift_expr>
    {
        public void sll_8u()
            => check_op<byte>(AK.Sll);

        public void sll_128x8u()
            => check_op_128<byte>(AK.Sll);

        public void sll_256x8u()
            => check_op_256<byte>(AK.Sll);

        public void sll_32u()
            => check_op<uint>(AK.Sll);

        public void sll_128x32u()
            => check_op_128<uint>(AK.Sll);

        public void sll_256x32u()
            => check_op_256<uint>(AK.Sll);

        public void sll_64u()
            => check_op<ulong>(AK.Sll);

        public void sll_128x64u()
            => check_op_128<ulong>(AK.Sll);

        public void sll_256x64u()
            => check_op_256<ulong>(AK.Sll);

        public void srl_8u()
            => check_op<byte>(AK.Srl);

        public void srl_128x8u()
            => check_op_128<byte>(AK.Srl);

        public void srl_256x8u()
            => check_op_256<byte>(AK.Srl);

        public void check_srl_32u()
            => check_op<uint>(AK.Srl);

        public void srl_128x32u()
            => check_op_128<uint>(AK.Srl);

        public void srl_256x32u()
            => check_op_256<uint>(AK.Srl);

        public void check_srl_64u()
            => check_op<ulong>(AK.Srl);

        public void srl_128x64u()
            => check_op_128<ulong>(AK.Srl);

        public void srl_256x64u()
            => check_op_256<ulong>(AK.Srl);

        public void rotl_8u()
            => check_op<byte>(AK.Rotl);

        public void rotl_128x8u()
            => check_op_128<byte>(AK.Rotl);

        public void rotl_256x8u()
            => check_op_256<byte>(AK.Rotl);

        public void rotl_32u()
            => check_op<uint>(AK.Rotl);

        public void rotl_128x32u()
            => check_op_128<uint>(AK.Rotl);

        public void rotl_256x32u()
            => check_op_256<uint>(AK.Rotl);

        public void rotl_64u()
            => check_op<ulong>(AK.Rotl);

        public void check_rotl_128x64u()
            => check_op_128<ulong>(AK.Rotl);

        public void rotl_256x64u()
            => check_op_256<ulong>(AK.Rotl);

        public void rotr_8u()
            => check_op<byte>(AK.Rotr);

        public void rotr_128x8u()
            => check_op_128<byte>(AK.Rotr);

        public void rotr_256x8u()
            => check_op_256<byte>(AK.Rotr);

        public void rotr_16u()
            => check_op<ushort>(AK.Rotr);

        public void rotr_128x16u()
            => check_op_128<ushort>(AK.Rotr);

        public void rotr_256x16u()
            => check_op_256<ushort>(AK.Rotr);

        public void rotr_32u()
            => check_op<uint>(AK.Rotr);

        public void rotr_128x32u()
            => check_op_128<uint>(AK.Rotr);

        public void rotr_256x32u()
            => check_op_256<uint>(AK.Rotr);

        public void rotr_64u()
            => check_op<ulong>(AK.Rotr);

        public void rotr_128x64u()
            => check_op_128<ulong>(AK.Rotr);

        public void check_rotr_256x64u()
            => check_op_256<ulong>(AK.Rotr);

        void check_op<T>(AK op)
            where T : unmanaged
        {
            var v1 = variable<T>(1);
            byte offset = 6;
            var expr = shift(op,v1,offset);

            for(var i=0; i< RepCount; i++)
            {
                var a = Random.Next<T>();
                v1.Set(a);
                T actual = LogixEngine.eval(expr);
                T expect = NumericLogixHost.eval(op,a,offset);
                Claim.eq(actual,expect);
            }
        }

        void check_op_256<T>(AK op)
            where T : unmanaged
        {
            var v1 = variable(1, default(Vector256<T>));
            byte offset = 6;
            var expr = shift(op,v1,offset);

            for(var i=0; i< RepCount; i++)
            {
                var a = Random.CpuVector<T>(n256);
                v1.Set(a);
                Vector256<T> actual = LogixEngine.eval(expr);
                Vector256<T> expect = VLogixOps.eval(op,a,offset);
                Claim.veq(actual,expect);
            }
        }

        protected void check_op_128<T>(AK op)
            where T : unmanaged
        {
            var v1 = variable(1, default(Vector128<T>));
            byte offset = 6;
            var expr = shift(op,v1,offset);

            for(var i=0; i< RepCount; i++)
            {
                var a = Random.CpuVector<T>(n128);
                v1.Set(a);
                Vector128<T> actual = LogixEngine.eval(expr);
                Vector128<T> expect = VLogixOps.eval(op,a,offset);
                Claim.veq(actual,expect);
            }
        }
    }
}