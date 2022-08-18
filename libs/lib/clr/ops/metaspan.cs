//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;
    using System.Reflection.Metadata;

    using static Root;
    using static core;

    partial struct Clr
    {
        /// <summary>
        /// Returns a reference to the cli metadata for an assembly
        /// </summary>
        /// <param name="src">The source assembly</param>
        [Op]
        public static unsafe ref ReadOnlySpan<byte> metaspan(Assembly src, out ReadOnlySpan<byte> dst)
        {
            src.TryGetRawMetadata(out var ptr, out var size);
            dst = cover(ptr, size);
            return ref dst;
        }

        /// <summary>
        /// Returns a reference to the cli metadata for an assembly
        /// </summary>
        /// <param name="src">The source assembly</param>
        [Op]
        public static unsafe ReadOnlySpan<byte> metaspan(Assembly src)
        {
            src.TryGetRawMetadata(out var ptr, out var size);
            return cover(ptr, size);
        }
    }
}