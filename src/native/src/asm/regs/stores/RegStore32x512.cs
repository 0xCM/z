//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm.Operands;

    using static sys;

    public struct RegStore32x512
    {
        readonly Seq<byte> Storage;

        public RegStore32x512()
        {
            Storage = alloc<byte>(64*32);
        }

        [MethodImpl(Inline)]
        public ref xmm Xmm(byte n)
            => ref @as<xmm>(Storage[n]);

        [MethodImpl(Inline)]
        public ref ymm Ymm(byte n)
            => ref @as<ymm>(Storage[n]);

        [MethodImpl(Inline)]
        public ref zmm Zmm(byte n)
            => ref @as<zmm>(Storage[n]);
    }
}