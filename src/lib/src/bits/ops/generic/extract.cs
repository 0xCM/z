//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class gbits
    {
        /// <summary>
        /// Extracts a contiguous range of bits from a primal source inclusively between two index positions
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="rhs">The left bit position</param>
        /// <param name="dst">The right bit position</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), BitSeg, Closures(AllNumeric)]
        public static T extract<T>(T src, byte i0, byte i1)
            where T : unmanaged
                => extract_u(src, i0, i1);

        /// <summary>
        /// Extracts a contiguous sequence of bits from a source and deposits the result to a caller-supplied target
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="i0">The position of the first bit</param>
        /// <param name="i1">The position of the last bit</param>
        /// <param name="dst">The target that receives the sequence</param>
        /// <param name="offset">The target offset</param>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline), BitSeg, Closures(Closure)]
        public static ref T extract<T>(in T src, byte i0, byte i1, ref T dst)
            where T : unmanaged
        {
            dst = extract(src, i0, i1);
            return ref dst;
        }

        /// <summary>
        /// Extracts a T-valued segment, cross-cell or same-cell, from the source as determined by an inclusive linear index range
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="i0">The sequence-relative index of the first bit</param>
        /// <param name="i1">The sequence-relative index of the last bit</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), BitSeg, Closures(Closure)]
        public static T extract<T>(Span<T> src, uint i0, uint i1)
            where T : unmanaged
                => extract(src, BitPos.bitpos<T>(i0), BitPos.bitpos<T>(i1));

        /// <summary>
        /// Extracts a T-valued segment, cross-cell or same-cell, from the source as determined by an inclusive position range
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="i0">The sequence-relative position of the first bit</param>
        /// <param name="i1">The sequence-relative position of the last bit</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), BitSeg, Closures(Closure)]
        public static T extract<T>(Span<T> src, BitPos<T> i0, BitPos<T> i1)
            where T : unmanaged
        {
            var width = (uint)(i1 - i0);
            if(width > core.width<T>())
                return Limits.maxval<T>();

            var same = i0.CellIndex == i1.CellIndex;
            var length = ScalarCast.uint8(same ? width : (uint)core.width<T>() - i0.BitOffset);
            var part1 = slice(bitcell(src, i0), (byte)i0.BitOffset, length);

            if(same)
                return part1;
            else
            {
                return gmath.or(part1, gmath.sal(slice(bitcell(src,i1), 0, ScalarCast.uint8(width - length)), length));
            }
        }

        [MethodImpl(Inline)]
        static T extract_u<T>(T src, byte i0, byte i1)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                 return generic<T>(bits.extract(uint8(src), i0, i1));
            else if(typeof(T) == typeof(ushort))
                 return generic<T>(bits.extract(uint16(src), i0, i1));
            else if(typeof(T) == typeof(uint))
                 return generic<T>(bits.extract(uint32(src), i0, i1));
            else if(typeof(T) == typeof(ulong))
                 return generic<T>(bits.extract(uint64(src), i0, i1));
            else
                return extract_i(src,i0,i1);
        }

        [MethodImpl(Inline)]
        static T extract_i<T>(T src, byte i0, byte i1)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                 return generic<T>(bits.extract(int8(src), i0, i1));
            else if(typeof(T) == typeof(short))
                 return generic<T>(bits.extract(int16(src), i0, i1));
            else if(typeof(T) == typeof(int))
                 return generic<T>(bits.extract(int32(src), i0, i1));
            else if(typeof(T) == typeof(long))
                 return generic<T>(bits.extract(int64(src), i0, i1));
            else
                return extract_f(src,i0,i1);
        }

        [MethodImpl(Inline)]
        static T extract_f<T>(T src, byte i0, byte i1)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                 return generic<T>(bits.extract(float32(src), i0, i1));
            else if(typeof(T) == typeof(double))
                 return generic<T>(bits.extract(float64(src),  i0, i1));
            else
                throw no<T>();
        }
    }
}