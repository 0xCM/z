//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Asci
    {
        [MethodImpl(Inline), Op]
        public static unsafe void copy(in asci8 src, ref byte dst)
            => @as<byte,ulong>(dst) = src.Storage;

        [MethodImpl(Inline), Op]
        public static unsafe void copy(in asci32 src, ref byte dst)
            => cpu.vstore(src.Storage, ref dst);

        [MethodImpl(Inline), Op]
        public static unsafe void copy(in asci32 src, Span<byte> dst)
            => cpu.vstore(src.Storage, dst);
    }
}