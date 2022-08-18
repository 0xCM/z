//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct SpanBlocks
    {
        [MethodImpl(Inline)]
        public static SpanBlock8<T> literals<T>(W8 w, params T[] src)
            where T : unmanaged
                => safeload(w, src);

        [MethodImpl(Inline)]
        public static SpanBlock16<T> literals<T>(W16 w, params T[] src)
            where T : unmanaged
                => safeload(w, src);

        [MethodImpl(Inline)]
        public static SpanBlock32<T> literals<T>(W32 w, params T[] src)
            where T : unmanaged
                => safeload(w, src);

        [MethodImpl(Inline)]
        public static SpanBlock64<T> literals<T>(W64 w, params T[] src)
            where T : unmanaged
                => safeload(w, src);

        [MethodImpl(Inline)]
        public static SpanBlock256<T> literals<T>(W256 w, params T[] src)
            where T : unmanaged
                => safeload(w, src);
    }
}