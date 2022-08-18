//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = NumericWidth;

    partial class Widths
    {
        public static K numeric(Type t)
        {
            var k = NumericKinds.kind(t);
            if(k != 0)
                return (K)(uint)k;
            else
                return K.None;
        }

        /// <summary>
        /// Computes the literal numeric width from a parametric width
        /// </summary>
        /// <typeparam name="W">The parametric width</typeparam>
        [MethodImpl(Inline)]
        public static K numeric<W>(W w = default)
            where W : struct, INumericWidth
        {
            if(typeof(W) == typeof(W1))
                return K.W1;
            else if(typeof(W) == typeof(W8))
                return K.W8;
            else if(typeof(W) == typeof(W16))
                return K.W16;
            else if(typeof(W) == typeof(W32))
                return K.W32;
            else if(typeof(W) == typeof(W64))
                return K.W64;
            else
                return 0;
        }

        [MethodImpl(Inline)]
        public static sbyte int8<W>(W w = default)
            where W : struct, INumericWidth
                => (sbyte)numeric(w);

        [MethodImpl(Inline)]
        public static byte uint8<W>(W w = default)
            where W : struct, INumericWidth
                => (byte)numeric(w);

        [MethodImpl(Inline)]
        public static short int16<W>(W w = default)
            where W : struct, INumericWidth
                => (short)default(W).TypeWidth;

        [MethodImpl(Inline)]
        public static ushort uint16<W>(W w = default)
            where W : struct, INumericWidth
                => (ushort)numeric(w);

        [MethodImpl(Inline)]
        public static int int32<W>(W w = default)
            where W : struct, INumericWidth
                => (int)numeric(w);

        [MethodImpl(Inline)]
        public static uint uint32<W>(W w = default)
            where W : struct, INumericWidth
                => (uint)default(W).TypeWidth;

        [MethodImpl(Inline)]
        public static long int64<W>(W w = default)
            where W : struct, INumericWidth
                => (long)numeric(w);

        [MethodImpl(Inline)]
        public static ulong uint64<W>(W w = default)
            where W : struct, INumericWidth
                => (ulong)numeric(w);

        /// <summary>
        /// Computes k := width[W] / bitsize[T]
        /// </summary>
        /// <param name="n">The natural representative</param>
        /// <param name="t">A type representative</param>
        /// <typeparam name="N">The natural type</typeparam>
        /// <typeparam name="T">The bit width type</typeparam>
        [MethodImpl(Inline)]
        public static int div<W,T>(W w = default, T t = default)
            where W : struct, ITypeWidth
            where T : unmanaged
                => (int)type<W>() / (int)bits<T>();
    }
}