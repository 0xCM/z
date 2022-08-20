//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        /// <summary>
        /// Compute a Marvin hash and collapse it into a 32-bit hash.
        /// </summary>
        [MethodImpl(Inline), Op]
        public static uint hash(ReadOnlySpan<char> src)
            => MarvinHash.marvin(src);

        /// <summary>
        /// Compute a Marvin hash and collapse it into a 32-bit hash.
        /// </summary>
        [MethodImpl(Inline), Op]
        public static uint hash(ReadOnlySpan<byte> src)
            => MarvinHash.marvin(src);
    }
}