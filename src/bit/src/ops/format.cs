//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct bit
    {
        [Op]
        public static string format(ReadOnlySpan<bit> src)
        {
            var count = (int)src.Length;
            Span<char> buffer = stackalloc char[count];
            for(var i=0; i<count; i++)
                seek(buffer,i) = skip(src,i).ToChar();
            buffer.Reverse();
            return sys.@string(buffer);
        }
    }
}