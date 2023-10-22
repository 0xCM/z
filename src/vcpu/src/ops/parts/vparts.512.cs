//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class vcpu
    {
        /// <summary>
        /// Defines a 512-bit vector by explicit component specification, from least -> most significant
        /// </summary>
        /// <param name="w">The vector width selector</param>
        [MethodImpl(Inline),Op]
        public static Vector512<short> vparts(W512i w,
            short x0, short x1, short x2, short x3, short x4, short x5, short x6, short x7,
            short x8, short x9, short x10, short x11, short x12, short x13, short x14, short x15,
            short x16, short x17, short x18, short x19, short x20, short x21, short x22, short x23,
            short x24, short x25, short x26, short x27, short x28, short x29, short x30, short x31)
                => Vector512.Create(
                    x0,x1, x2, x3,x4,x5,x6,x7,x8,x9,x10,x11,x12,x13,x14,x15,
                    x16,x17,x18,x19,x20,x21,x22,x23,x24,x25,x26,x27,x28,x29,x30,x31);

        [MethodImpl(Inline),Op]
        public static Vector512<byte> vparts(byte e0, byte e1, byte e2, byte e3, byte e4, byte e5, byte e6, byte e7, byte e8, byte e9, byte e10, byte e11, byte e12, byte e13, byte e14, byte e15, byte e16, byte e17, byte e18, byte e19, byte e20, byte e21, byte e22, byte e23, byte e24, byte e25, byte e26, byte e27, byte e28, byte e29, byte e30, byte e31, byte e32, byte e33, byte e34, byte e35, byte e36, byte e37, byte e38, byte e39, byte e40, byte e41, byte e42, byte e43, byte e44, byte e45, byte e46, byte e47, byte e48, byte e49, byte e50, byte e51, byte e52, byte e53, byte e54, byte e55, byte e56, byte e57, byte e58, byte e59, byte e60, byte e61, byte e62, byte e63)
            => Vector512.Create(e0, e1, e2, e3, e4, e5, e6, e7, e8, e9, e10, e11, e12, e13, e14, e15, e16, e17, e18, e19, e20, e21, e22, e23, e24, e25, e26, e27, e28, e29, e30, e31, e32, e33, e34, e35, e36, e37, e38, e39, e40, e41, e42, e43, e44, e45, e46, e47, e48, e49, e50, e51, e52, e53, e54, e55, e56, e57, e58, e59, e60, e61, e62, e63);

        /// <summary>
        /// Defines a 512-bit vector by explicit component specification, from least -> most significant
        /// </summary>
        /// <param name="w">The vector width selector</param>
        [MethodImpl(Inline),Op]
        public static Vector512<ushort> vparts(W512 w,
            ushort x0, ushort x1, ushort x2, ushort x3, ushort x4, ushort x5, ushort x6, ushort x7,
            ushort x8, ushort x9, ushort x10, ushort x11, ushort x12, ushort x13, ushort x14, ushort x15,
            ushort x16, ushort x17, ushort x18, ushort x19, ushort x20, ushort x21, ushort x22, ushort x23,
            ushort x24, ushort x25, ushort x26, ushort x27, ushort x28, ushort x29, ushort x30, ushort x31)
                => Vector512.Create(
                    x0,x1, x2, x3,x4,x5,x6,x7,x8,x9,x10,x11,x12,x13,x14,x15,
                    x16,x17,x18,x19,x20,x21,x22,x23,x24,x25,x26,x27,x28,x29,x30,x31);

        /// <summary>
        /// Defines a 512-bit vector by explicit component specification, from least -> most significant
        /// </summary>
        /// <param name="w">The vector width selector</param>
        [MethodImpl(Inline),Op]
        public static Vector512<int> vparts(W512i w, int x0, int x1, int x2, int x3, int x4, int x5, int x6, int x7,
            int x8, int x9, int x10, int x11, int x12, int x13, int x14, int x15)
                => Vector512.Create(x0,x1, x2, x3,x4,x5,x6,x7,x8,x9,x10,x11,x12,x13,x14,x15);

        /// <summary>
        /// Defines a 512-bit vector by explicit component specification, from least -> most significant
        /// </summary>
        /// <param name="w">The vector width selector</param>
        [MethodImpl(Inline),Op]
        public static Vector512<uint> vparts(W512 w,uint x0, uint x1, uint x2, uint x3, uint x4, uint x5, uint x6, uint x7,
            uint x8, uint x9, uint x10, uint x11, uint x12, uint x13, uint x14, uint x15)
                => Vector512.Create(x0,x1, x2, x3,x4,x5,x6,x7,x8,x9,x10,x11,x12,x13,x14,x15);

        /// <summary>
        /// Defines a 512-bit vector by explicit component specification, from least -> most significant
        /// </summary>
        /// <param name="w">The vector width selector</param>
        [MethodImpl(Inline),Op]
        public static Vector512<long> vparts(W512i w, long x0, long  x1, long  x2, long  x3, long x4, long  x5, long  x6, long  x7)
            => Vector512.Create(x0,x1,x2,x3,x4,x5,x6,x7);

        /// <summary>
        /// Defines a 512-bit vector by explicit component specification, from least -> most significant
        /// </summary>
        /// <param name="w">The vector width selector</param>
        [MethodImpl(Inline), Op]
        public static Vector512<ulong> vparts(W512 w, ulong x0, ulong  x1, ulong  x2, ulong  x3, ulong x4, ulong  x5, ulong  x6, ulong  x7)
            => Vector512.Create(x0,x1,x2,x3,x4,x5,x6,x7);

        /// <summary>
        /// Defines a 512-bit vector by lane specifiecation
        /// </summary>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector512<T> vparts<T>(W512 w, Vector256<T> a, Vector256<T> b)
            where T : unmanaged
                => Vector512.Create(a, b);

        /// <summary>
        /// Defines a 512-bit vector by explicit component specification, from least -> most significant
        /// </summary>
        /// <param name="w">The vector width selector</param>
        [MethodImpl(Inline), Op]
        public static Vector512<float> vparts(W512 w, float x0, float x1, float x2, float x3, float x4, float x5, float x6, float x7,
            float x8, float x9, float x10, float x11, float x12, float x13, float x14, float x15)
                => Vector512.Create(x0,x1, x2, x3,x4,x5,x6,x7,x8,x9,x10,x11,x12,x13,x14,x15);

        /// <summary>
        /// Defines a 512-bit vector by explicit component specification, from least -> most significant
        /// </summary>
        /// <param name="w">The vector width selector</param>
        [MethodImpl(Inline), Op]
        public static Vector512<double> vparts(W512 w,double x0, double  x1, double  x2, double  x3, double x4, double  x5, double  x6, double  x7)
            => Vector512.Create(x0,x1,x2,x3,x4,x5,x6,x7);
    }
}