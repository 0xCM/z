//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Asci
    {
        [MethodImpl(Inline)]
        public static ref readonly asci2 cast<A>(N2 n, in A src)
            where A : unmanaged, IByteSeq
                => ref @as<A,asci2>(src);

        [MethodImpl(Inline)]
        public static ref readonly asci4 cast<A>(N4 n, in A src)
            where A : unmanaged, IByteSeq
                => ref @as<A,asci4>(src);

        [MethodImpl(Inline)]
        public static ref readonly asci8 cast<A>(N8 n, in A src)
            where A : unmanaged, IByteSeq
                => ref @as<A,asci8>(src);

        [MethodImpl(Inline)]
        public static ref readonly asci16 cast<A>(N16 n, in A src)
            where A : unmanaged, IByteSeq
                => ref @as<A,asci16>(src);

        [MethodImpl(Inline)]
        public static ref readonly asci32 cast<A>(N32 n, in A src)
            where A : unmanaged, IByteSeq
                => ref @as<A,asci32>(src);

        [MethodImpl(Inline)]
        public static ref readonly asci64 cast<A>(N64 n, in A src)
            where A : unmanaged, IByteSeq
                => ref @as<A,asci64>(src);
    }
}