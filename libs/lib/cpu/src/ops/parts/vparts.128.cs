//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.Vector128;
    using static System.Runtime.Intrinsics.Vector256;

    partial struct cpu
    {
        /// <summary>
        /// Defines a 128-bit vector by explicit component specification, from least -> most significant
        /// </summary>
        /// <param name="w">The vector width selector</param>
        [MethodImpl(Inline),Op]
        public static Vector128<byte> vparts(W128 w,
            byte x0, byte x1, byte x2, byte x3, byte x4, byte x5, byte x6, byte x7,
            byte x8, byte x9, byte xa, byte xb, byte xc, byte xd, byte xe, byte xf)
                => Create(x0,x1, x2, x3, x4, x5, x6, x7, x8, x9, xa, xb, xc, xd, xe, xf);

        /// <summary>
        /// Defines a 128-bit vector by explicit component specification, from least -> most significant
        /// </summary>
        /// <param name="w">The vector width selector</param>
        [MethodImpl(Inline),Op]
        public static Vector128<sbyte> vparts(W128i w,
            sbyte x0, sbyte x1, sbyte x2, sbyte x3, sbyte x4, sbyte x5, sbyte x6, sbyte x7,
            sbyte x8, sbyte x9, sbyte xa, sbyte xb, sbyte xc, sbyte xd, sbyte xe, sbyte xf)
                => Create(x0,x1, x2, x3, x4, x5, x6, x7, x8, x9, xa, xb, xc, xd, xe, xf);

        /// <summary>
        /// Defines a 128-bit vector by explicit component specification, from least -> most significant
        /// </summary>
        /// <param name="w">The vector width selector</param>
        [MethodImpl(Inline),Op]
        public static Vector128<short> vparts(W128i w, short x0, short x1, short x2, short x3, short x4, short x5, short x6, short x7)
            => Create(x0,x1, x2, x3, x4, x5, x6, x7);

        /// <summary>
        /// Defines a 128-bit vector by explicit component specification, from least -> most significant
        /// </summary>
        /// <param name="w">The vector width selector</param>
        [MethodImpl(Inline),Op]
        public static Vector128<ushort> vparts(W128 w, ushort x0, ushort x1, ushort x2, ushort x3, ushort x4, ushort x5, ushort x6, ushort x7)
            => Create(x0,x1, x2, x3, x4, x5, x6, x7);

        /// <summary>
        /// Defines a 128-bit vector by explicit component specification, from least -> most significant
        /// </summary>
        /// <param name="w">The vector width selector</param>
        [MethodImpl(Inline),Op]
        public static Vector128<uint> vparts(W128 w, uint x0, uint x1, uint x2, uint x3)
            => Create(x0, x1, x2, x3);

        /// <summary>
        /// Defines a 128-bit vector by explicit component specification, from least -> most significant
        /// </summary>
        /// <param name="w">The vector width selector</param>
        [MethodImpl(Inline),Op]
        public static Vector128<int> vparts(W128i w, int x0, int x1, int x2, int x3)
            => Create(x0,x1, x2, x3);

        /// <summary>
        /// Defines a 128-bit vector by explicit component specification, from least -> most significant
        /// </summary>
        /// <param name="w">The vector width selector</param>
        [MethodImpl(Inline),Op]
        public static Vector128<long> vparts(W256i w, long x0, long x1)
            => Create(x0,x1);

        /// <summary>
        /// Defines a 128-bit vector by explicit component specification, from least -> most significant
        /// </summary>
        /// <param name="w">The vector width selector</param>
        [MethodImpl(Inline),Op]
        public static Vector128<ulong> vparts(ulong x0, ulong x1)
            => Create(x0,x1);

        /// <summary>
        /// Defines a 128-bit vector by explicit component specification, from least -> most significant
        /// </summary>
        /// <param name="w">The vector width selector</param>
        [MethodImpl(Inline),Op]
        public static Vector128<ulong> vparts(W128 w, ulong x0, ulong x1)
            => Create(x0, x1);

        /// <summary>
        /// Defines a 128-bit vector by explicit component specification, from least -> most significant
        /// </summary>
        /// <param name="w">The vector width selector</param>
        [MethodImpl(Inline),Op]
        public static Vector128<float> vparts(W128 w, float x0, float x1, float x2, float x3)
            => Create(x0, x1, x2, x3);

        /// <summary>
        /// Defines a 128-bit vector by explicit component specification, from least -> most significant
        /// </summary>
        /// <param name="w">The vector width selector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<double> vparts(W128 w, double x0, double x1)
            => Create(x0, x1);
    }
}