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
        public static Ptr16 p16(ushort* pSrc)
            => new Ptr16(pSrc);

        /// <summary>
        /// Creates a representation over a specified pointer
        /// </summary>
        /// <param name="pSrc">The source pointer</param>
        [MethodImpl(Inline), Op]
        public static Ptr16 p16(void* pSrc)
            => new Ptr16((ushort*)pSrc);
    }
}