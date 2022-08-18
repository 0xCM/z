//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;

    partial class StringTables
    {
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> entry(StringTable src, int i)
        {
            var i0 = src.Offsets[i];
            var count = src.EntryCount;
            if(i < count-1)
            {
                var i1 = src.Offsets[i+1];
                var length = i1 - i0;
                return slice(src.Content.View, i0, length);
            }
            else
                return slice(src.Content.View, i0);
        }
    }
}