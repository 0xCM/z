//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Clr
    {
        /// <summary>
        /// Returns a <see cref='SegRef'/> to the cli metadata segment of the source
        /// </summary>
        /// <param name="src">The source assembly</param>
        [MethodImpl(Inline), Op]
        public static unsafe MemorySeg metadata(Assembly src)
        {
            if(src.TryGetRawMetadata(out var ptr, out var len))
                return new MemorySeg(ptr,len);
            else
                return MemorySeg.Empty;
        }
    }
}