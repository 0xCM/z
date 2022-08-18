//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Sized
    {
        [MethodImpl(Inline), Op]
        public static NativeSize native(BitWidth src)
        {
            if(src == 8)
                return NativeSizeCode.W8;
            else if(src == 80)
                return NativeSizeCode.W80;
            else
                return (NativeSizeCode)Pow2.log(src >> 3);
        }

        /// <summary>
        /// Computes the bit-width of the represented primitive
        /// </summary>
        /// <param name="src">The literal's bitfield</param>
        [MethodImpl(Inline), Op]
        public static NativeSize native(PrimalKind src)
            => native((uint)PrimalBits.width(src));

        [MethodImpl(Inline)]
        public static NativeSize native<W>(W w)
            where W : unmanaged, IDataWidth
                => native((BitWidth)w.BitWidth);

        [MethodImpl(Inline)]
        public static NativeSize native<T>()
            where T : unmanaged
                => native(width<T>());
    }
}