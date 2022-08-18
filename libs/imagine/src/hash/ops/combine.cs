//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class HashCodes
    {
        /// <summary>
        /// Calculates a combined calc for 2 unsigned 32-bit integers
        /// </summary>
        /// <param name="x">The left source</param>
        /// <param name="y">The right source</param>
        /// <remarks>Adapted from the .Net core type System.Reflection.Internal.Hash</remarks>
        [MethodImpl(Inline), Op]
        public static uint combine(uint x, uint y)
            => (y * K) + x;

        /// <summary>
        /// Creates a combined/unsigned calc code
        /// </summary>
        /// <param name="x">The left source</param>
        /// <param name="y">The right source</param>
        /// <remarks>Adapted from the .Net core type System.Reflection.Internal.Hash</remarks>
        [MethodImpl(Inline), Op]
        public static uint combine(sbyte x, sbyte y)
            => combine((uint)x,(uint)y);

        /// <summary>
        /// Creates a combined/unsigned calc code
        /// </summary>
        /// <param name="x">The left source</param>
        /// <param name="y">The right source</param>
        /// <remarks>Adapted from the .Net core type System.Reflection.Internal.Hash</remarks>
        [MethodImpl(Inline), Op]
        public static uint combine(byte x, byte y)
            => combine((uint)x,(uint)y);

        /// <summary>
        /// Creates a combined/unsigned calc code
        /// </summary>
        /// <param name="x">The left source</param>
        /// <param name="y">The right source</param>
        /// <remarks>Adapted from the .Net core type System.Reflection.Internal.Hash</remarks>
        [MethodImpl(Inline), Op]
        public static uint combine(short x, short y)
            => combine((uint)x,(uint)y);

        /// <summary>
        /// Creates a combined/unsigned calc code
        /// </summary>
        /// <param name="x">The left source</param>
        /// <param name="y">The right source</param>
        /// <remarks>Adapted from the .Net core type System.Reflection.Internal.Hash</remarks>
        [MethodImpl(Inline), Op]
        public static uint combine(ushort x, ushort y)
            => combine((uint)x,(uint)y);

        /// <summary>
        /// Creates a combined/unsigned calc code
        /// </summary>
        /// <param name="x">The left source</param>
        /// <param name="y">The right source</param>
        /// <remarks>Adapted from the .Net core type System.Reflection.Internal.Hash</remarks>
        [MethodImpl(Inline), Op]
        public static uint combine(int x, int y)
            => combine((uint)x, (uint)y);

        /// <summary>
        /// Creates a combined/unsigned calc code
        /// </summary>
        /// <param name="x">The left source</param>
        /// <param name="y">The right source</param>
        /// <remarks>Adapted from the .Net core type System.Reflection.Internal.Hash</remarks>
        [MethodImpl(Inline), Op]
        public static uint combine(ulong x, ulong y)
            => combine(combine((uint)x,(uint)(x >> 32)), combine((uint)y,(uint)(y >> 32)));

        /// <summary>
        /// Creates a combined/unsigned calc code
        /// </summary>
        /// <param name="x">The left source</param>
        /// <param name="y">The right source</param>
        /// <remarks>Adapted from the .Net core type System.Reflection.Internal.Hash</remarks>
        [MethodImpl(Inline), Op]
        public static uint combine(long x, long y)
            => combine((ulong)x,(ulong)y);

        /// <summary>
        /// Creates a combined/unsigned calc code
        /// </summary>
        /// <param name="x">The left source</param>
        /// <param name="y">The right source</param>
        /// <remarks>Adapted from the .Net core type System.Reflection.Internal.Hash</remarks>
        [MethodImpl(Inline), Op]
        public static uint combine(float x, float y)
            => combine(i32(x), i32(y));

        /// <summary>
        /// Creates a combined/unsigned calc code
        /// </summary>
        /// <param name="x">The left source</param>
        /// <param name="y">The right source</param>
        /// <remarks>Adapted from the .Net core type System.Reflection.Internal.Hash</remarks>
        [MethodImpl(Inline), Op]
        public static uint combine(double x, double y)
            => combine(u64(x), u64(y));

        /// <summary>
        /// Creates a combined/unsigned calc code
        /// </summary>
        /// <param name="x">The left source</param>
        /// <param name="y">The right source</param>
        /// <remarks>Adapted from the .Net core type System.Reflection.Internal.Hash</remarks>
        [MethodImpl(Inline), Op]
        public static uint combine(decimal x, decimal y)
            => combine(u64(x), u64(y));

        /// <summary>
        /// Creates a 64-bit calc code predicated on two types
        /// </summary>
        /// <typeparam name="S">The first type</typeparam>
        /// <typeparam name="T">The second type</typeparam>
        [MethodImpl(Inline)]
        public static ulong combine(Type t1, Type t2)
            => (ulong)hash(t1) | (ulong)hash(t2) << 32;

        /// <summary>
        /// Creates a 64-bit calc code predicated on three types
        /// </summary>
        /// <typeparam name="S">The first type</typeparam>
        /// <typeparam name="T">The second type</typeparam>
        [MethodImpl(Inline)]
        public static ulong combine(Type t1, Type t2, Type t3)
            => combine(t1,t2) ^ combine(t1, t3);

        /// <summary>
        /// Combines 3 32-bit hash codes into 1 32-hash code
        /// </summary>
        /// <param name="x">The first hash</param>
        /// <param name="y">The second hash</param>
        /// <param name="z">The third hash</param>
        [MethodImpl(Inline), Op]
        public static uint combine(sbyte x, sbyte y, sbyte z)
            => combine(combine(x,y), z);

        /// <summary>
        /// Combines 3 32-bit hash codes into 1 32-hash code
        /// </summary>
        /// <param name="x">The first hash</param>
        /// <param name="y">The second hash</param>
        /// <param name="z">The third hash</param>
        [MethodImpl(Inline), Op]
        public static uint combine(byte x, byte y, byte z)
            => combine(combine(x,y), z);

        /// <summary>
        /// Combines 3 32-bit hash codes into 1 32-hash code
        /// </summary>
        /// <param name="x">The first hash</param>
        /// <param name="y">The second hash</param>
        /// <param name="z">The third hash</param>
        [MethodImpl(Inline), Op]
        public static uint combine(ushort x, ushort y, ushort z)
            => combine(combine(x,y), z);

        /// <summary>
        /// Combines 3 32-bit hash codes into 1 32-hash code
        /// </summary>
        /// <param name="x">The first hash</param>
        /// <param name="y">The second hash</param>
        /// <param name="z">The third hash</param>
        [MethodImpl(Inline), Op]
        public static uint combine(short x, short y, short z)
            => combine(combine(x,y), z);

        /// <summary>
        /// Combines 3 32-bit hash codes into 1 32-hash code
        /// </summary>
        /// <param name="x">The first hash</param>
        /// <param name="y">The second hash</param>
        /// <param name="z">The third hash</param>
        [MethodImpl(Inline), Op]
        public static uint combine(uint x, uint y, uint z)
            => combine(combine(x,y), z);

        /// <summary>
        /// Combines 3 32-bit hash codes into 1 32-hash code
        /// </summary>
        /// <param name="x">The first hash</param>
        /// <param name="y">The second hash</param>
        /// <param name="z">The third hash</param>
        [MethodImpl(Inline), Op]
        public static uint combine(int x, int y, int z)
            => combine(combine(x,y), z);

        /// <summary>
        /// Combines 3 64-bit hash codes into 1 64-hash code
        /// </summary>
        /// <param name="x">The first hash</param>
        /// <param name="y">The second hash</param>
        /// <param name="z">The third hash</param>
        [MethodImpl(Inline), Op]
        public static uint combine(ulong x, ulong y, ulong z)
            => combine(combine(x,y),z);

        /// <summary>
        /// Combines 3 64-bit hash codes into 1 64-hash code
        /// </summary>
        /// <param name="x">The first hash</param>
        /// <param name="y">The second hash</param>
        /// <param name="z">The third hash</param>
        [MethodImpl(Inline), Op]
        public static uint combine(long x, long y, long z)
            => combine(combine(x,y),z);

        /// <summary>
        /// Combines 3 64-bit hash codes into 1 64-hash code
        /// </summary>
        /// <param name="x">The first hash</param>
        /// <param name="y">The second hash</param>
        /// <param name="z">The third hash</param>
        [MethodImpl(Inline), Op]
        public static uint combine(char x, char y, char z)
            => combine(combine(x,y),z);
    }
}