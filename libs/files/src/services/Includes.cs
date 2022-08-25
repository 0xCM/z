//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public readonly struct Includes
    {
        public static IncludePath concat(IncludePath a, IncludePath b)
        {
            var dst = alloc<FolderPath>(a.EntryCount + b.EntryCount);
            concat(a,b,dst);
            return dst;
        }

        public static IncludePath concat(IncludePath a, FolderPath b)
        {
            var dst = alloc<FolderPath>(a.EntryCount + 1);
            concat(a, include(b), dst);
            return dst;
        }

        public static IncludePath concat(FolderPath a, IncludePath b)
        {
            var dst = alloc<FolderPath>(b.EntryCount + 1);
            concat(include(a), b, dst);
            return dst;
        }

        [Op]
        public static void concat(IncludePath a, IncludePath b, IncludePath dst)
        {
            var ka = a.EntryCount;
            var va = a.Entries;
            var kb = b.EntryCount;
            var vb = b.Entries;
            var count = ka + kb;
            ref var target = ref dst.Data.First;
            var j=0;
            for(var i=0; i<ka; i++,j++)
                seek(target,j) = skip(va,i);
            for(var i=0; i<kb; i++,j++)
                seek(target,j) = skip(vb,i);
        }

        [Op]
        public static string format(IncludePath src, PathSeparator sep, bool quote)
        {
            var dst = text.buffer();
            iter(src.Entries, include => dst.AppendFormat("{0};", include.Format(sep, quote)));
            return dst.Emit();
        }

        [MethodImpl(Inline), Op]
        public static IncludePath include(params FolderPath[] src)
            => src;
    }
}