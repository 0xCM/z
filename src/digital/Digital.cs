//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using C = AsciCode;

    /// <summary>
    /// Defines operations over character digits
    /// </summary>
    [ApiHost("api")]
    public readonly partial struct Digital
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op]
        public static int IndexOfFirstDigit(Base10 @base, ReadOnlySpan<char> src)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                if(Digital.test(@base, skip(src, i)))
                    return i;
            return NotFound;
        }

        [MethodImpl(Inline), Op]
        public static int IndexOfFirstDigit(Base10 @base, ReadOnlySpan<C> src)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                if(Digital.test(@base, skip(src, i)))
                    return i;
            return NotFound;
        }

        [MethodImpl(Inline), Op]
        public static int IndexOfFirstDigit(Base16 @base, ReadOnlySpan<char> src)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                if(Digital.test(@base, skip(src, i)))
                    return i;
            return NotFound;
        }

        [MethodImpl(Inline), Op]
        public static int IndexOfFirstDigit(Base16 @base, ReadOnlySpan<C> src)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                if(Digital.test(@base, skip(src, i)))
                    return i;
            return NotFound;
        }
    }
}