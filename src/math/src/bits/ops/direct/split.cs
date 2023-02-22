//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class bits
    {
        /// <summary>
        /// Splits a 16-bit integer into lo/hi parts
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="n">The target partition count</param>
        [MethodImpl(Inline), Split]
        public static ConstPair<byte> split(ushort src, N2 n)
            => ((byte)src, ((byte)(src >> 8)));

        /// <summary>
        /// Splits a 32-bit integer into lo/hi parts
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="n">The target partition count</param>
        [MethodImpl(Inline), Split]
        public static ConstPair<ushort> split(uint src, N2 n)
            => ((ushort)src, ((ushort)(src >> 16)));

        /// <summary>
        /// Splits a 32-bit integer into four parts of equal width, from lo to hi
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="n">The target partition count</param>
        [MethodImpl(Inline), Split]
        public static Quad<byte> split(uint src, N4 n)
            => ((byte)src,(byte)(src >> 8),(byte)(src >> 16), (byte)(src >> 24));

        /// <summary>
        /// Splits a 64-bit integer into hi/lo parts
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="n">The target partition count</param>
        [MethodImpl(Inline), Split]
        public static ConstPair<uint> split(ulong src, N2 n)
            => ((uint)src, (uint)(src >> 32));

        /// <summary>
        /// Splits a 64-bit integer into four parts of equal width, from lo to hi
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="n">The target partition count</param>
        [MethodImpl(Inline), Split]
        public static Quad<ushort> split(ulong src, N4 n)
            => ((ushort)src,(ushort)(src >> 16),(ushort)(src >> 32), (ushort)(src >> 48));

        /// <summary>
        /// Partitions the source value into two parts predicated on an index
        /// [1010 11111 0011] |> split 4 = [1010 1111] [0011]
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="index">The index that partitions the source</param>
        /// <param name="x0">The lo partition</param>
        /// <param name="x1">The hi partition</param>
        [MethodImpl(Inline), Split]
        public static void split(byte src, int index, out byte x0, out byte x1)
        {
            x1 = (byte)(src >> index);
            x0 = (byte)(src & ((byte)Pow2.pow((byte)index) - 1));
        }

        /// <summary>
        /// Partitions the source value into two parts predicated on an index
        /// [1010 11111 0011] |> split 4 = [1010 1111] [0011]
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="index">The index that partitions the source</param>
        /// <param name="x0">The lo partition</param>
        /// <param name="x1">The hi partition</param>
        [MethodImpl(Inline), Split]
        public static void split(ushort src, int index, out ushort x0, out ushort x1)
        {
            x1 = (ushort)(src >> index);
            x0 = (ushort)(src & ((ushort)Pow2.pow((byte)index) - 1));
        }

        /// <summary>
        /// Partitions the source value into two parts predicated on an index
        /// [1010 11111 0011] |> split 4 = [1010 1111] [0011]
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="index">The index that partitions the source</param>
        /// <param name="x0">The lo partition</param>
        /// <param name="x1">The hi partition</param>
        [MethodImpl(Inline), Split]
        public static void split(uint src, int index, out uint x0, out uint x1)
        {
            x1 = src >> index;
            x0 =  src & ((uint)Pow2.pow((byte)index) - 1);
        }

        /// <summary>
        /// Partitions the source value into two parts predicated on an index
        /// [1010 11111 0011] |> split 4 = [1010 1111] [0011]
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="index">The index that partitions the source</param>
        /// <param name="x0">The lo partition</param>
        /// <param name="x1">The hi partition</param>
        [MethodImpl(Inline), Split]
        public static void split(ulong src, int index, out ulong x0, out ulong x1)
        {
            x1 = src >> index;
            x0 =  src & (Pow2.pow((byte)index) - 1);
        }

        /// <summary>
        /// Partitions an 8-bit source upper and lower parts, each with an effective width of 4 bits
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="x0">Receives sourc bits [0..3]</param>
        /// <param name="x1">Receives sourc bits [4..7]</param>
        [MethodImpl(Inline), Split]
        public static void split(byte src, out byte x0, out byte x1)
        {
            x0 = (byte)(src &0xF);
            x1 = (byte)(src >> 4);
        }

        /// <summary>
        /// Partitions an 8-bit source value into upper and lower parts of effective width 4,
        /// sending the lo part to the output parameter and returning the hi part
        /// <param name="src">The source value</param>
        /// <param name="x0">Receives source bits [0..3]</param>
        [MethodImpl(Inline), Split]
        public static byte split(byte src, out byte x0)
        {
            x0 = (byte)(src & 0xF);
            return (byte)(src >> 4);
        }

        /// <summary>
        /// Partitions a 16-bit source value into upper and lower 8-bit parts
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="x0">Receives source bits [0..7]</param>
        /// <param name="x1">Receives source bits [8..15]</param>
        [MethodImpl(Inline), Split]
        public static void split(ushort src, out byte x0, out byte x1)
        {
            x0 = (byte)src;
            x1 = (byte)(src >>8);
        }

        /// <summary>
        /// Partitions a 16-bit source value into upper and lower 8-bit parts,
        /// sending the lo part to the output parameter and returning the hi part
        /// <param name="src">The source value</param>
        /// <param name="x0">Receives source bits [0..7]</param>
        [MethodImpl(Inline), Split]
        public static byte split(ushort src, out byte x0)
        {
            x0 = (byte)src;
            return (byte)(src >> 8);
        }

        /// <summary>
        /// Partitions a 32-bit source value into upper and lower 16-bit parts
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="x0">Receives source bits [0..15]</param>
        /// <param name="x1">Receives source bits [16..31]</param>
        [MethodImpl(Inline), Split]
        public static void split(uint src, out ushort x0, out ushort x1)
        {
            x0 = (ushort)(src);
            x1 = (ushort)(src >> 16);
        }

        /// <summary>
        /// Partitions a 64-bit source value into upper and lower 32-bit parts,
        /// sending the lo part to the output parameter and returning the hi part
        /// <param name="src">The source value</param>
        /// <param name="x0">Receives source bits [0..31]</param>
        [MethodImpl(Inline), Split]
        public static ushort split(uint src, out ushort x0)
        {
            x0 = (ushort)src;
            return (ushort)(src >> 16);
        }

        /// <summary>
        /// Partitions a 64-bit source value into upper and lower 32-bit parts
        /// <param name="src">The source value</param>
        /// <param name="x0">Receives source bits [0..31]</param>
        /// <param name="x1">Receives source bits [32..63]</param>
        [MethodImpl(Inline), Split]
        public static void split(ulong src, out uint x0, out uint x1)
        {
            x0 = (uint)src;
            x1 = (uint)(src >> 32);
        }

        /// <summary>
        /// Partitions a 64-bit source value into upper and lower 32-bit parts,
        /// sending the lo part to the output parameter and returning the hi part
        /// <param name="src">The source value</param>
        /// <param name="x0">Receives source bits [0..31]</param>
        [MethodImpl(Inline), Split]
        public static uint split(ulong src, out uint x0)
        {
            x0 = (uint)src;
            return (uint)(src >> 32);
        }

        /// <summary>
        /// Partitions a 64-bit source value into 4 16-bit parts
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="x0">Receives source bits [0..15]</param>
        /// <param name="x1">Receives source bits [16..31]</param>
        /// <param name="x2">Receives source bits [32..47]</param>
        /// <param name="x3">Receives source bits [48..63]</param>
        [MethodImpl(Inline), Split]
        public static void split(ulong src, out ushort x0, out ushort x1, out ushort x2, out ushort x3)
        {
            x0 = (ushort)src;
            x1 = (ushort)(src >> 16);
            x2 = (ushort)(src >> 32);
            x3 = (ushort)(src >> 48);
        }

        /// <summary>
        /// Partitions a 32-bit source value into 4 8-bit parts
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="x0">Receives source bits [0..7]</param>
        /// <param name="x1">Receives source bits [8..15]</param>
        /// <param name="x2">Receives source bits [16..23]</param>
        /// <param name="x3">Receives source bits [24..31]</param>
        [MethodImpl(Inline), Split]
        public static void split(uint src, out byte x0, out byte x1, out byte x2, out byte x3)
        {
            x0 = (byte)(src >> 0*8);
            x1 = (byte)(src >> 1*8);
            x2 = (byte)(src >> 2*8);
            x3 = (byte)(src >> 3*8);
        }

        /// <summary>
        /// Partitions a 32-bit source value into 8 8-bit parts
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="x0">Receives source bits [0..7]</param>
        /// <param name="x1">Receives source bits [8..15]</param>
        /// <param name="x2">Receives source bits [16..23]</param>
        /// <param name="x3">Receives source bits [24..31]</param>
        /// <param name="x4">Receives source bits [32..39]</param>
        /// <param name="x5">Receives source bits [40..47]</param>
        /// <param name="x6">Receives source bits [48..55]</param>
        /// <param name="x7">Receives source bits [56..63]</param>
        [MethodImpl(Inline), Split]
        public static void split(ulong src, out byte x0, out byte x1, out byte x2, out byte x3, out byte x4, out byte x5, out byte x6, out byte x7)
        {
            x0 = (byte)(src >> 0*8);
            x1 = (byte)(src >> 1*8);
            x2 = (byte)(src >> 2*8);
            x3 = (byte)(src >> 3*8);
            x4 = (byte)(src >> 4*8);
            x5 = (byte)(src >> 5*8);
            x6 = (byte)(src >> 6*8);
            x7 = (byte)(src >> 7*8);
        }
    }
}