//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;
    using static ScalarCast;
    using static sys;

    partial class Sized
    {
        [MethodImpl(Inline), Op]
        public static ByteSize size(Mb mb)
            => mb.Count * BytesPerMb;

        [MethodImpl(Inline), Op]
        public static ByteSize size(Gb gb)
            => gb.Count * BytesPerGb;

        [MethodImpl(Inline), Op]
        public static ByteSize size(Kb src)
            => new ByteSize((uint64(src.Count) * BytesPerKb) + uint64(src.Rem)/BitsPerByte);       

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint size<T>()
            => (uint)SizeOf<T>();

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint size<T>(uint count)
            => (uint)SizeOf<T>() * count;
    }
}