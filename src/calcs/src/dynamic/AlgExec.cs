//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using C = AlgDynamic.CalcBytes;
    using I = AlgDynamic.OpIndex;

    partial class AlgDynamic
    {
        public static void runA(Action<string> emitter)
        {
            var src = dynops();
            var count = src.Count;
            var buffer = alloc<MsilCompilation>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                ref readonly var op = ref src[i];
                ref var result = ref seek(dst,i);
                result = ClrDynamic.compilation(op.Definition);
                emitter(string.Format("{0}: {1}", result.EntryPoint, result.Msil.Encoded.Format()));
            }
        }

        public static void runB(Action<string> emitter)
        {
            var name = nameof(mul_8u_8u_8u);
            var code = mul_8u_8u_8u;
            var dynop = BinaryOpDynamics.dynop<byte>(name, code);
            var fx = dynop.Delegate;
            var il = ClrDynamic.compilation(dynop.Definition);
            emitter(string.Format("{0}: {1}", il.EntryPoint, il.Msil.Encoded.Format()));
            for(byte i=0; i<20; i++)
            {
                var a = i;
                var b = (byte)(a*2);
                var c = fx(a,b);
                emitter(string.Format("{0}({1},{2})={3}", name, a, b, c));
            }
        }

        public static void runC(Action<string> emitter)
        {
            compute();
            var dst = text.buffer();
            run(dst);
            emitter(dst.Emit());
        }

        static ReadOnlySpan<byte> mul_8u_8u_8u
            => new byte[18]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc1,0x0f,0xb6,0xd2,0x0f,0xaf,0xc2,0x0f,0xb6,0xc0,0xc3};

        public static BinaryOperators<T> index<T>()
            => new BinaryOperators<T>(new BinaryOp<T>[256]);

        public static BinaryOperators<byte> arithmetic()
        {
            var dst = index<byte>();
            dst[I.Add] = BinaryOpDynamics.create<byte>(OpIdentity.define(nameof(C.add_???8i???8i???)), C.add_???8i???8i???);
            dst[I.Sub] = BinaryOpDynamics.create<byte>(OpIdentity.define(nameof(C.sub_???8u???8u???)), C.sub_???8u???8u???);
            dst[I.Mul] = BinaryOpDynamics.create<byte>(OpIdentity.define(nameof(C.mul_???8u???8u???)), C.mul_???8u???8u???);
            dst[I.Div] = BinaryOpDynamics.create<byte>(OpIdentity.define(nameof(C.div_???8u???8u???)), C.div_???8u???8u???);
            return dst;
        }

        public static Index<DynamicOp<BinaryOp<byte>>> dynops()
        {
            var dst = alloc<DynamicOp<BinaryOp<byte>>>(4);
            dst[0] = BinaryOpDynamics.dynop<byte>(nameof(C.add_???8i???8i???), C.add_???8i???8i???);
            dst[1] = BinaryOpDynamics.dynop<byte>(nameof(C.sub_???8u???8u???), C.sub_???8u???8u???);
            dst[2] = BinaryOpDynamics.dynop<byte>(nameof(C.mul_???8u???8u???), C.mul_???8u???8u???);
            dst[3] = BinaryOpDynamics.dynop<byte>(nameof(C.div_???8u???8u???), C.div_???8u???8u???);
            return dst;
        }
    }
}