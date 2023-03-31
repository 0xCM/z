//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [StructLayout(LayoutKind.Sequential,Pack = 16)]
    public struct XMM_REGISTERS
    {
        public Vector128<byte> Xmm0;

        public Vector128<byte> Xmm1;

        public Vector128<byte> Xmm2;

        public Vector128<byte> Xmm3;

        public Vector128<byte> Xmm4;

        public Vector128<byte> Xmm5;

        public Vector128<byte> Xmm6;

        public Vector128<byte> Xmm7;

        public Vector128<byte> Xmm8;

        public Vector128<byte> Xmm9;

        public Vector128<byte> Xmm10;

        public Vector128<byte> Xmm11;

        public Vector128<byte> Xmm12;

        public Vector128<byte> Xmm13;

        public Vector128<byte> Xmm14;

        public Vector128<byte> Xmm15;

        public override string ToString()
        {
            var dst = text.emitter();
            var fields = GetType().Fields();
            var @this = this;
            iter(fields, f => {
                dst.AppendLineFormat("{0,-16} ", ((Vector128<byte>)f.GetValue(@this)).FormatHex());
            });
            return dst.Emit();
        }
    }
}