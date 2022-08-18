//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class NumericKinds
    {
        /// <summary>
        /// Determines whether a specifed <see cref='NumericKind'/> is of integral class
        /// </summary>
        /// <param name="kind">The source kind</param>
        [MethodImpl(Inline), Op]
        public static bool integer(NumericKind kind)
            => unsigned(kind) || signed(kind);
    }
}