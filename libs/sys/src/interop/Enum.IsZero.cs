//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class XTend
    {
        [MethodImpl(Inline)]
        public static bool IsZero<T>(this T src)
            where T : unmanaged, Enum
                => bw64(src) == 0;

        [MethodImpl(Inline)]
        public static bool IsNonZero<T>(this T src)
            where T : unmanaged, Enum
                => bw64(src) != 0;
    }
}