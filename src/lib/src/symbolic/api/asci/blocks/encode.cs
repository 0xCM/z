//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;
    using static Refs;
    using static Scalars;

    partial struct AsciBlocks
    {
        [MethodImpl(Inline), Op]
        public static ref AsciBlock4 encode(string src, out AsciBlock4 dst)
            => ref encode(span(src), out dst);

        [MethodImpl(Inline), Op]
        public static ref AsciBlock8 encode(string src, out AsciBlock8 dst)
            => ref encode(span(src), out dst);

        [MethodImpl(Inline), Op]
        public static ref AsciBlock16 encode(string src, out AsciBlock16 dst)
            => ref encode(span(src), out dst);

        [MethodImpl(Inline), Op]
        public static ref AsciBlock32 encode(string src, out AsciBlock32 dst)
            => ref encode(span(src), out dst);

        [MethodImpl(Inline), Op]
        public static ref AsciBlock64 encode(string src, out AsciBlock64 dst)
            => ref encode(span(src), out dst);

        [MethodImpl(Inline), Op]
        public static ref AsciBlock128 encode(string src, out AsciBlock128 dst)
            => ref encode(span(src), out dst);

        [MethodImpl(Inline), Op]
        public static ref AsciBlock4 encode(ReadOnlySpan<char> src, out AsciBlock4 dst)
        {
            dst = default;
            var count = min(ByteBlock4.N, src.Length);
            encode(src, slice(dst.Bytes,0,count));
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref AsciBlock8 encode(ReadOnlySpan<char> src, out AsciBlock8 dst)
        {
            dst = default;
            var count = min(ByteBlock8.N, src.Length);
            encode(src, slice(dst.Bytes,0,count));
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref AsciBlock16 encode(ReadOnlySpan<char> src, out AsciBlock16 dst)
        {
            dst = default;
            var count = min(ByteBlock16.N, src.Length);
            encode(src, slice(dst.Bytes,0,count));
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref AsciBlock24 encode(ReadOnlySpan<char> src, out AsciBlock24 dst)
        {
            dst = default;
            var count = min(ByteBlock24.N, src.Length);
            encode(src, slice(dst.Bytes,0,count));
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref AsciBlock32 encode(ReadOnlySpan<char> src, out AsciBlock32 dst)
        {
            dst = AsciBlock32.Empty;
            var count = min(ByteBlock32.N, src.Length);
            encode(src, slice(dst.Bytes,0,count));
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref AsciBlock64 encode(ReadOnlySpan<char> src, out AsciBlock64 dst)
        {
            dst = AsciBlock64.Empty;
            var count = min(ByteBlock64.N, src.Length);
            encode(src, slice(dst.Bytes,0,count));
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref AsciBlock128 encode(ReadOnlySpan<char> src, out AsciBlock128 dst)
        {
            dst = AsciBlock128.Empty;
            var count = min(ByteBlock128.N, src.Length);
            encode(src, slice(dst.Bytes,0,count));
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        static int encode(ReadOnlySpan<char> src, Span<byte> dst)
        {
            var count = min(src.Length, dst.Length);
            for(var i=0u; i<count; i++)
                seek(dst,i) = (byte)skip(src,i);
            return count;
        }
    }
}