//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct FS
    {
        /// <summary>
        /// Determines whether a module is native (vs. managed)
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        [MethodImpl(Inline), Op]
        public static bool native(FilePath src)
            => !managed(src);
    }
}