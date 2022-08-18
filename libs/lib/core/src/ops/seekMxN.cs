//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
        [MethodImpl(Inline)]
        public static ref byte seek8x8k<T,K>(in T src, K count)
            where K : unmanaged
                => ref add(@as<T,byte>(edit(src)), u8(count));

        [MethodImpl(Inline)]
        public static ref byte seek8x16k<T,K>(in T src, K count)
            where K : unmanaged
                => ref add(@as<T,byte>(edit(src)), u16(count));

        [MethodImpl(Inline)]
        public static ref byte seek8x32k<T,K>(in T src, K count)
            where K : unmanaged
                => ref add(@as<T,byte>(edit(src)), u32(count));

        [MethodImpl(Inline)]
        public static ref byte seek8x64k<T,K>(in T src, K count)
            where K : unmanaged
                => ref add(@as<T,byte>(edit(src)), u64(count));

        [MethodImpl(Inline)]
        public static ref ushort seek16x8k<T,K>(in T src, K count)
            where K : unmanaged
                => ref add(@as<T,ushort>(edit(src)), u8(count));

        [MethodImpl(Inline)]
        public static ref ushort seek16x16k<T,K>(in T src, K count)
            where K : unmanaged
                => ref add(@as<T,ushort>(edit(src)), u16(count));

        [MethodImpl(Inline)]
        public static ref ushort seek16x32k<T,K>(in T src, K count)
            where K : unmanaged
                => ref add(@as<T,ushort>(edit(src)), u32(count));

        [MethodImpl(Inline)]
        public static ref ushort seek16x64k<T,K>(in T src, K count)
            where K : unmanaged
                => ref add(@as<T,ushort>(edit(src)), u64(count));

        [MethodImpl(Inline)]
        public static ref uint seek32x8k<T,K>(in T src, K count)
            where K : unmanaged
                => ref add(@as<T,uint>(edit(src)), u8(count));

        [MethodImpl(Inline)]
        public static ref uint seek32x16k<T,K>(in T src, K count)
            where K : unmanaged
                => ref add(@as<T,uint>(edit(src)), u16(count));

        [MethodImpl(Inline)]
        public static ref uint seek32x32k<T,K>(in T src, K count)
            where K : unmanaged
                => ref add(@as<T,uint>(edit(src)), u32(count));

        [MethodImpl(Inline)]
        public static ref uint seek32x64k<T,K>(in T src, K count)
            where K : unmanaged
                => ref add(@as<T,uint>(edit(src)), u64(count));

        [MethodImpl(Inline)]
        public static ref ulong seek64x8k<T,K>(in T src, K count)
            where K : unmanaged
                => ref add(@as<T,ulong>(edit(src)), u8(count));

        [MethodImpl(Inline)]
        public static ref ulong seek64x16k<T,K>(in T src, K count)
            where K : unmanaged
                => ref add(@as<T,ulong>(edit(src)), u16(count));

        [MethodImpl(Inline)]
        public static ref ulong seek64x32k<T,K>(in T src, K count)
            where K : unmanaged
                => ref add(@as<T,ulong>(edit(src)), u32(count));

        [MethodImpl(Inline)]
        public static ref ulong seek64x64k<T,K>(in T src, K count)
            where K : unmanaged
                => ref add(@as<T,ulong>(edit(src)), u64(count));
    }
}