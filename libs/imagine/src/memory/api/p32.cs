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
        public static Ptr32 p32(uint* pSrc)
            => new Ptr32(pSrc);

        /// <summary>
        /// Creates a representation over a specified pointer
        /// </summary>
        /// <param name="pSrc">The source pointer</param>
        [MethodImpl(Inline), Op]
        public static Ptr32 p32(void* pSrc)
            => new Ptr32((uint*)pSrc);
    }
}