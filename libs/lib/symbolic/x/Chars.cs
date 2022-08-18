//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class XText
    {
        [MethodImpl(Inline), TextUtility]
        public static bool IsDigit(this char src)
            => Char.IsDigit(src);

        [MethodImpl(Inline), TextUtility]
        public static bool IsLower(this char src)
            => Char.IsLower(src);

        [MethodImpl(Inline), TextUtility]
        public static bool IsUpper(this char src)
            => Char.IsUpper(src);

        [MethodImpl(Inline), TextUtility]
        public static char ToUpper(this char src)
            => Char.ToUpperInvariant(src);

        [MethodImpl(Inline), TextUtility]
        public static char ToLower(this char src)
            => Char.ToLowerInvariant(src);
    }
}