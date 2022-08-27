//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        public static PinnedIndex<T> Pin<T>(this Index<T> src)
            where T : unmanaged
                => new PinnedIndex<T>(src.Storage);

        public static PinnedArray<T> Pin<T>(this T[] src)
            where T : unmanaged
                => new PinnedArray<T>(src);
    }
}