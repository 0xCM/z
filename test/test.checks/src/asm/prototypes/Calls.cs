//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost("asm.protos.calls"), Free]
    public class AsmCalls
    {
        public delegate byte Mul(byte x, byte y);

        public static byte mul(byte x, byte y)
            => (byte)(x*y);

        [Op, Size(18)]
        public static MemoryAddress call(N0 n)
            => target(n);

        [Op, Size(18)]
        public static MemoryAddress call(N1 n)
            => target(n);

        [Op, Size(18)]
        public static MemoryAddress call(N2 n)
            => target(n);

        [Op, Size(18)]
        public static MemoryAddress call(N3 n)
            => target(n);

        [Op, MethodImpl(NotInline)]
        static MemoryAddress target(N0 n)
            => (MemoryAddress)MethodInfo.GetCurrentMethod().MethodHandle.GetFunctionPointer();

        [Op, MethodImpl(NotInline)]
        static MemoryAddress target(N1 n)
            => (MemoryAddress)MethodInfo.GetCurrentMethod().MethodHandle.GetFunctionPointer();

        [Op, MethodImpl(NotInline)]
        static MemoryAddress target(N2 n)
            => (MemoryAddress)MethodInfo.GetCurrentMethod().MethodHandle.GetFunctionPointer();

        [Op, MethodImpl(NotInline)]
        static MemoryAddress target(N3 n)
            => (MemoryAddress)MethodInfo.GetCurrentMethod().MethodHandle.GetFunctionPointer();        

        [Op]
        public static FPtr<Mul> testFptr()
        {
            Mul f = mul;
            return memory.fptr(f);
        }

        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static void binop<T>(ReadOnlySpan<T> left, ReadOnlySpan<T> right, Func<T,T,T> f, Span<T> results)
        {
            var count = left.Length;
            ref readonly var a = ref first(left);
            ref readonly var b = ref first(right);
            ref var c = ref first(results);
            for(var i=0u; i<count; i++)
                seek(c,i) = f(skip(a,i), skip(b,i));
        }

        public static void binop<T>(uint count, in T left, in T right, Func<T,T,T> f, ref T dst)
        {
            for(var i=0u; i<count; i++)
                seek(dst,i) = f(skip(left,i), skip(right,i));
        }

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static void binop<T>(uint count, in Pair<T> src, Func<T,T,T> f, ref T dst)
        {
            for(var i=0u; i<count; i++)
                seek(dst,i) = f(skip(src,i).Left, skip(src,i).Right);
        }

        [Op]
        public static void binop(uint count, in Pair<uint> src, Func<uint,uint,uint> f, ref uint dst)
            => binop<uint>(count, src, f, ref dst);

        [Op]
        public static void binfunc(uint count, in Paired<uint,byte> src, Func<uint,byte,ulong> f, ref ulong dst)
        {
            for(var i=0u; i<count; i++)
                seek(dst,i) = f(skip(src,i).Left, skip(src,i).Right);
        }

        [MethodImpl(Inline)]
        public static void binfunc<A,B,C>(uint count, in Paired<A,B> src, Func<A,B,C> f, ref C dst)
        {
            for(var i=0u; i<count; i++)
                seek(dst,i) = f(skip(src,i).Left, skip(src,i).Right);
        }

        [Op]
        public static unsafe void f_u32_u32_p32u(uint ecx, uint edx, uint* r8d)
        {
            r8d[0] = ecx*0x7;
            r8d[1] = ecx*0xd;
            r8d[2] = edx*0x11;
            r8d[3] = edx*0x17;
        }


        [Op]
        public static Vector128<uint> f_u32_u32_u32_u32_v128x32u(uint a0, uint a1, uint a2, uint a3)
            => cpu.vparts(w128, a0,  a1, a2, a3);

        [Op]
        public static void f1x1(uint a0, out uint b0)
        {
            b0 = a0*0x77;
        }

        [Op]
        public static void f1x2(uint a0, out uint b0, out uint b1)
        {
            b0 = a0*0x11CC;
            b1 = a0*0xFFCC;
        }

        [Op]
        public static void f1x3(uint a0, out uint b0, out uint b1, out uint b2)
        {
            b0 = a0*0x1111;
            b1 = a0*0xFFCC;
            b2 = a0*0xCCFF;
        }

        [Op]
        public static void f2x1(uint a0, uint a1, out uint b0)
        {
            b0 = a0*a1;
        }

        [Op]
        public static void f3x0(uint a0, uint a1, Span<uint> dst)
        {
            seek(dst,0) = a0*0x1111;
            seek(dst,1) = a1*0xFFCC;
            seek(dst,2) = a0*0x3333;
            seek(dst,3) = skip(dst,2)*4;
        }

        [Op]
        public static void f2x3(uint a0, uint a1, out uint b0, out uint b1, out uint b2)
        {
            b0 = a0*0x1111;
            b1 = a1*0xFFCC;
            b2 = a0*a1;
        }

        [Op]
        public static void f2x4(uint a0, uint a1, out uint b0, out uint b1, out uint b2, out uint b3)
        {
            b0 = a0*0x1111;
            b1 = a1*0xFFCC;
            b2 = a0*a1;
            b3 = a1*0x8999;
        }

        [Op]
        public static void f3x1(uint a0, uint a1, uint a2, out uint b0)
        {
            b0 = a0*a1*a2;
        }


        [Op]
        public static void f3x2(uint a0, uint a1, uint a2, out uint b0, out uint b1)
        {
            b0 = a0*a1;
            b1 = a1*0x16;
        }

        [Op]
        public static void f_8i_8i_8i_out8i_out8i_out8i(sbyte a0, sbyte a1, sbyte a2, out sbyte b0, out sbyte b1, out sbyte b2)
        {
            b0 = a0;
            b1 = a1;
            b2 = a2;
        }

        [Op]
        public static void f_8u_8u_8u_out8u_out8u_out8u(byte a0, byte a1, byte a2, out byte b0, out byte b1, out byte b2)
        {
            b0 = a0;
            b1 = a1;
            b2 = a2;
        }

        [Op]
        public static void f_16u_16u_16u_out16u_out16u_out16u(ushort a0, ushort a1, ushort a2, out ushort b0, out ushort b1, out ushort b2)
        {
            b0 = a0;
            b1 = a1;
            b2 = a2;
        }

        [Op]
        public static void f_32u_32u_32u_out32u_out32u_out32u(uint a0, uint a1, uint a2, out uint b0, out uint b1, out uint b2)
        {
            b0 = a0;
            b1 = a1;
            b2 = a2;
        }

        [Op]
        public static void f_64u_64u_64u_out64u_out64u_out64u(ulong a0, ulong a1, ulong a2, out ulong b0, out ulong b1, out ulong b2)
        {
            b0 = a0;
            b1 = a1;
            b2 = a2;
        }

        [Op]
        public static void f_in8i_in8i_in8i_out8i_out8i_out8i(in sbyte a0, in sbyte a1, in sbyte a2, out sbyte b0, out sbyte b1, out sbyte b2)
        {
            b0 = a0;
            b1 = a1;
            b2 = a2;
        }

        [Op]
        public static void f_in8u_in8u_in8u_out8u_out8u_out8u(in byte a0, in byte a1, in byte a2, out byte b0, out byte b1, out byte b2)
        {
            b0 = a0;
            b1 = a1;
            b2 = a2;
        }

        [Op]
        public static unsafe void f_p8u_out8u_out8u_out8u(byte* a0, out byte b0, out byte b1, out byte b2)
        {
            b0 = a0[0];
            b1 = a0[1];
            b2 = a0[2];
        }

        [Op]
        public static unsafe void f_p8u_out8u_out8u_out8u_out8u(byte* a0, out byte b0, out byte b1, out byte b2, out byte b3)
        {
            b0 = a0[0];
            b1 = a0[1];
            b2 = a0[2];
            b3 = a0[3];
        }
    }
}