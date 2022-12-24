//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Symbols
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint names<E>(Symbols<E> src, Span<Label> dst)
            where E : unmanaged
        {
            var view = src.View;
            var count = (uint)min(view.Length, dst.Length);
            for(var i=0; i<count; i++)
                seek(dst,i) = skip(view,i).Name;
            return count;
        }

        public static Index<Label> names<E>()
            where E : unmanaged, Enum
        {
            var src = index<E>().View;
            var count = src.Length;
            var dst = alloc<Label>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = skip(src,i).Name;
            return dst;
        }
    }
}