//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    unsafe partial struct memory
    {
        /// <summary>
        /// Creates a <see cref='Ptr8'/> representation over a specified source
        /// </summary>
        /// <param name="pSrc">The source pointer</param>
        [MethodImpl(Inline), Op]
        public static Ptr8 p8(byte* pSrc)
            => new Ptr8(pSrc);

        /// <summary>
        /// Creates a <see cref='Ptr8'/> representation over a specified source
        /// </summary>
        /// <param name="pSrc">The source pointer</param>
        [MethodImpl(Inline), Op]
        public static Ptr8 p8(void* pSrc)
            => new Ptr8((byte*)pSrc);

        /// <summary>
        /// Creates a <see cref='Ptr8'/> representation over a specified source
        /// </summary>
        /// <param name="pSrc">The source pointer</param>
        [MethodImpl(Inline), Op]
        public static Ptr8 p8(ushort* pSrc)
            => new Ptr8((byte*)pSrc);

        /// <summary>
        /// Creates a <see cref='Ptr8'/> representation over a specified source
        /// </summary>
        /// <param name="pSrc">The source pointer</param>
        [MethodImpl(Inline), Op]
        public static Ptr8 p8(uint* pSrc)
            => new Ptr8((byte*)pSrc);

        /// <summary>
        /// Creates a <see cref='Ptr8'/> representation over a specified source
        /// </summary>
        /// <param name="pSrc">The source pointer</param>
        [MethodImpl(Inline), Op]
        public static Ptr8 p8(ulong* pSrc)
            => new Ptr8((byte*)pSrc);

        /// <summary>
        /// Presents a <see cref='Ptr16'/> representation as a <see cref='Ptr8'/> representation
        /// </summary>
        /// <param name="source">The source representation</param>
        [MethodImpl(Inline), Op]
        public static ref Ptr8 p8(in Ptr16 src)
            => ref @as<Ptr16,Ptr8>(src);

        /// <summary>
        /// Presents a <see cref='Ptr32'/> representation as a <see cref='Ptr8'/> representation
        /// </summary>
        /// <param name="source">The source representation</param>
        [MethodImpl(Inline), Op]
        public static ref Ptr8 p8(in Ptr32 src)
            => ref @as<Ptr32,Ptr8>(src);

        /// <summary>
        /// Presents a <see cref='Ptr64'/> representation as a <see cref='Ptr8'/> representation
        /// </summary>
        /// <param name="source">The source representation</param>
        [MethodImpl(Inline), Op]
        public static ref Ptr8 p8(in Ptr64 src)
            => ref @as<Ptr64,Ptr8>(src);
    }
}