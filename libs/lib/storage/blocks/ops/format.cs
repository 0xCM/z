//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Storage
    {
        public static string format<T>(in T src)
            where T : unmanaged, IStorageBlock<T>
                => src.Bytes.FormatHex();

        public static string format<T>(in T src, char sep, bool prespec=false, bool uppercase = false)
            where T : unmanaged, IStorageBlock<T>
                => src.Bytes.FormatHex(sep, prespec:prespec, uppercase:uppercase);

        public static string format<T>(in TrimmedBlock<T> src)
            where T : unmanaged, IStorageBlock<T>
        {
            var sz = size(src);
            if(sz == 0)
                sz = 1;
            return Spans.slice(src.BlockData, 0, sz).FormatHex();
        }
    }
}