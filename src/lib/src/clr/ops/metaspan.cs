//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Clr
    {
        /// <summary>
        /// Returns a reference to the cli metadata for an assembly
        /// </summary>
        /// <param name="src">The source assembly</param>
        [Op]
        public static unsafe ref ReadOnlySpan<byte> metaspan(Assembly src, out ReadOnlySpan<byte> dst)
            => ref ClrAssembly.metaspan(src, out dst);

        /// <summary>
        /// Returns a reference to the cli metadata for an assembly
        /// </summary>
        /// <param name="src">The source assembly</param>
        [Op]
        public static unsafe ReadOnlySpan<byte> metaspan(Assembly src)
            => ClrAssembly.metaspan(src);
    }
}