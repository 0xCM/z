//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public ref struct SpanReader
    {
        ReadOnlySpan<byte> Source;

        public static SpanReader create(ReadOnlySpan<byte> src)
            => new SpanReader(src);

        [MethodImpl(Inline)]
        SpanReader(ReadOnlySpan<byte> src)
        {
            Source = src;
            Pos = 0;
            Max = (uint)src.Length - 1;
        }

        uint Pos;

        uint Max;

        uint Remaining
        {
            [MethodImpl(Inline)]
            get => Max - Pos;
        }

        ref readonly byte Current
        {
            [MethodImpl(Inline)]
            get => ref skip(Source,Pos);
        }

        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public bool Next<T>(out T dst)
            where T : unmanaged
        {
            var wanted = size<T>();
            var result = false;
            if(wanted <= Remaining)
            {
                dst = @as<T>(Current);
                Pos += wanted;
                result = true;
            }
            else
            {
                dst = default;
            }
            return result;
        }
   }
}