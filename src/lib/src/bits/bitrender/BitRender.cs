//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using C = AsciCode;

    [ApiHost]
    public readonly partial struct BitRender
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op]
        static uint separate(uint offset, Span<char> dst)
        {
            seek(dst,offset) = Chars.Space;
            return 1;
        }

        [MethodImpl(Inline), Op]
        static uint separate(uint offset, Span<C> dst)
        {
            seek(dst,offset) = AsciCode.Space;
            return 1;
        }

        [MethodImpl(Inline), Op]
        static uint separate(uint offset, char sep, Span<char> dst)
        {
            seek(dst, offset) = sep;
            return 1;
        }

        [MethodImpl(Inline), Op]
        static uint separate(uint offset, C sep, Span<C> dst)
        {
            seek(dst,offset) = sep;
            return 1;
        }
    }
}