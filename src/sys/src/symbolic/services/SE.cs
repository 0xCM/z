//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Symbolic Effects
    /// </summary>
    [ApiHost]
    public class SE
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T copy<T>(ReadOnlySpan<char> src, ref T dst)
            where T : unmanaged
        {
            var count = (uint)min(src.Length, size<T>()/2);
            copy(first(src), ref @as<T,char>(dst), count);
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static uint copy(char src, ref uint i, Span<char> dst)
        {
            seek(dst,i++) = src;
            return 1;
        }

        [MethodImpl(Inline), Op]
        public static uint copy(ReadOnlySpan<char> src, ref uint i, Span<char> dst)
        {
            var count = src.Length;
            var counter = 0u;
            for(var j=0; j<count; j++, counter++)
                seek(dst, i++) = skip(src, j);
            return counter;
        }

        [MethodImpl(Inline), Op]
        public static uint copy(string src, ref uint i, Span<char> dst)
        {
            var input = src.ToSpan();
            var count = input.Length;
            var counter = 0u;
            for(var j=0; j<count; j++, counter++)
                seek(dst, i++) = skip(input,j);
            return counter;
        }

        [MethodImpl(Inline), Op]
        public static uint copy(string src, ref char dst)
        {
            var input = src.ToSpan();
            var count = input.Length;
            for(var i=0; i<count; i++)
                seek(dst, i++) = skip(input,i);
            return (uint)count;
        }

        [MethodImpl(Inline), Op]
        static void copy(in byte src, ref byte dst, uint count)
        {
            for(var i=0; i<count; i++)
                seek(dst,i) = skip(src,i);
        }

        [MethodImpl(Inline)]
        static void copy<S,T>(in S src, ref T dst, uint srcCount, uint dstOffset = 0)
            where S: unmanaged
            where T :unmanaged
                => copy(sys.u8(src), ref sys.uint8(ref seek(dst, dstOffset)), srcCount*size<S>());    }
}