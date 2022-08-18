//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static CodeExecCases;

    partial class AsmCheckCmd
    {
        [CmdOp("asm/check/exec")]
        void CheckCodeExec()
        {
            var result = Outcome.Success;
            using var buffer = CodeBuffer.allocate();
            CheckBinaryOpExec(buffer);
            CheckUnaryOpExec(buffer);
            CheckUnaryFuncExec(buffer);
            CheckFxPointers();
        }

        static unsafe string fx1()
        {
            var f = MemFx.binop<uint>(mul_32u_32u_32u);
            var a = 5u;
            var b = 10u;
            var expect = a*b;
            var c = f(a,b);
            return string.Format("{0}*{1}={2}", a, b, c);
        }

        static unsafe string fx2()
        {
            var f = MemFx.unaryop<byte>(inc_8u_8u);
            var expect = (byte)6;
            var a = (byte)5;
            var b = Require.equal(f(a), expect);
            return string.Format("++{0}={1}", a, b);
        }

        public unsafe string fx3()
        {
            var f = MemFx.binop_ptr<byte>(vadd_128x8u);
            var a = vmask.veven<byte>(w128, n2, n1);
            var b = vmask.veven<byte>(w128, n2, n2);
            var c = MemFx.invoke(f, a, b);
            return string.Format("<{0}> + <{1}> = <{2}>", a.FormatHex(), b.FormatHex(), c.FormatHex());
        }

        unsafe void CheckFxPointers()
        {
            Write(fx1());
            Write(fx2());
            Write(fx3());
        }

        void CheckBinaryOpExec(CodeBuffer buffer)
        {
            var name = nameof(min64u_64u_64u);
            var code = min64u_64u_64u;
            var a = 3ul;
            var b = 4ul;
            var f = buffer.LoadBinOp<ulong>(name,code);
            var c = f.Invoke(a,b);
            Write(f.Format(a,b,c));
        }

        void CheckUnaryOpExec(CodeBuffer buffer)
        {
            var name = nameof(dec_64u);
            var code = dec_64u;
            var a = 52ul;
            var f = buffer.LoadUnaryOp<ulong>(name, code);
            var b = f.Invoke(a);
            Write(f.Format(a,b));
        }

        void CheckUnaryFuncExec(CodeBuffer buffer)
        {
            var name = nameof(nonz_64u);
            var code = nonz_64u;
            var a = 52ul;
            var f = buffer.LoadUnaryFunc<ulong,bit>(name,code);
            var b = f.Invoke(a);
            Write(f.Format(a,b));
        }
    }

    readonly struct CodeExecCases
    {
        public static ReadOnlySpan<byte> min64u_64u_64u
            => new byte[18]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x3b,0xca,0x72,0x04,0x48,0x8b,0xc2,0xc3,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> nonz_64u
            => new byte[18]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x85,0xc9,0x0f,0x95,0xc0,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> dec_64u
             => new byte[10]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8d,0x41,0xff,0xc3};

        public static ReadOnlySpan<byte> mul_32u_32u_32u
            => new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0xc1,0x0f,0xaf,0xc2,0xc3};

        public static ReadOnlySpan<byte> inc_8u_8u
            => new byte[14]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc1,0xff,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> vadd_128x8u
            => new byte[22]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x79,0xfc,0x00,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};
    }
}