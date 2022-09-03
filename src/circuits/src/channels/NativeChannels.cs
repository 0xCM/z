//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]

    public class NativeChannels
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op]
        public static NativeChannel channel(uint cells, uint width, ChannelMask mask = default)
            => new NativeChannel(cells, width, mask);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static NativeChannel<T> channel<T>(uint cells, ChannelMask mask = default)
            where T : unmanaged, ITypeWidth
                => new NativeChannel<T>(cells,mask);

        [MethodImpl(Inline)]
        public static NativeChannel<N,W> channel<N,W>(N n = default, W w = default)
            where W : unmanaged, ITypeWidth
            where N : unmanaged, ITypeNat
                => new NativeChannel<N,W>();

        [MethodImpl(Inline)]
        public static NativeChannel<N,W> channel<N,W>(ChannelMask mask, N n = default, W w = default)
            where W : unmanaged, ITypeWidth
            where N : unmanaged, ITypeNat
                => new NativeChannel<N,W>(mask);
    }
}