//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public class NativeFlows
    {
        const NumericKind Closure = UnsignedInts;

        /// <summary>
        /// Creates a <see cref='NativeFlow{S,T}'/> from a specified source to a specified target;
        /// </summary>
        /// <param name="src">The source</param>
        /// <param name="dst">The target</param>
        /// <typeparam name="S">The source type</typeparam>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline)]
        public static NativeFlow<S,T> flow<S,T>(in S src, in T dst)
            where S : INativeChannel
            where T : INativeChannel
                => new NativeFlow<S,T>(src,dst);

        [MethodImpl(Inline)]
        public static NativeFlow<K,S,T> flow<K,S,T>(K kind, in S src, in T dst)
            where K : unmanaged
            where S : INativeChannel
            where T : INativeChannel
                => new NativeFlow<K,S,T>(kind,src,dst);

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

        [MethodImpl(Inline)]
        public static NativeFiber<T> fiber<T>(T channel, uint cell = 0, ushort offset = 0, byte width = 0)
            where T : unmanaged,INativeChannel
                => new NativeFiber<T>(channel,cell,offset,width);

        [MethodImpl(Inline), Op]
        public static NativeFiber fiber(NativeChannel channel, uint cell = 0, ushort offset = 0, byte width = 0)
            => new NativeFiber(channel,cell,offset,width);

         public static string syntax<S,T>(NativeFlow<S,T> flow)
            where S : INativeChannel
            where T : INativeChannel
        {
            const string Pattern = "{0}:{1} -> {4}:{5}";
            return string.Format(Pattern, flow.Source, typeof(S).Name, flow.Target, typeof(T).Name);
        }

        public static string syntax<K,S,T>(NativeFlow<K,S,T> flow)
            where K : unmanaged
            where S : INativeChannel
            where T : INativeChannel
        {
            const string Pattern = "{0}:{1} |{2}:{3}> {4}:{5}";
            return string.Format(Pattern, flow.Source, typeof(S).Name, flow.Kind, typeof(K).Name, flow.Target, typeof(T).Name);
        }

        internal static string format(ChannelMask src)
        {
            if(src.IsEmpty)
                return EmptyString;
            else
            {
                if(src.Kind == ChannelMaskKind.Zero)
                    return string.Format("z{{0}}", src.Value.FormatBits());
                else
                    return string.Format("k{{0}}", src.Value.FormatBits());
            }
        }

        internal static string format(NativeChannel src)
        {
            if(src.Mask.IsEmpty)
                return string.Format("{0}x{1}", src.CellCount, src.CellWidth);
            else
                return string.Format("{0}x{1} {2}", src.CellCount, src.CellWidth, format(src.Mask));
        }

        internal static string format<K,S,T>(in NativeFlow<K,S,T> flow)
            where K : unmanaged
            where S : INativeChannel
            where T : INativeChannel
                => string.Format("{0} |{1}> {2}", flow.Source, flow.Kind, flow.Target);

        internal static RenderPattern<S,T> RenderFlow<S,T>() => "{0} -> {1}";

        internal static RenderPattern<T,T> RenderFlow<T>() => RenderFlow<T,T>();

        internal static string format<S,T>(in NativeFlow<S,T> flow)
            where S : INativeChannel
            where T : INativeChannel
                => RenderFlow<S,T>().Format(flow.Source, flow.Target);
    }
}