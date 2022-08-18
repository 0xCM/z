//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    unsafe partial struct memory
    {
        /// <summary>
        /// Creates a representation over a specified pointer
        /// </summary>
        /// <param name="pSrc">The source pointer</param>
        [MethodImpl(Inline), Op]
        public static PChar pchar(ushort* pSrc)
            => new PChar((char*)pSrc);

        /// <summary>
        /// Creates a representation over a specified pointer
        /// </summary>
        /// <param name="pSrc">The source pointer</param>
        [MethodImpl(Inline), Op]
        public static PChar pchar(void* pSrc)
            => new PChar((char*)pSrc);
    }
}