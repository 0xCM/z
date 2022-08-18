//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using Asm.Operands;

    using static core;

    public struct RegStore32x512
    {
        readonly Index<ByteBlock64> Storage;

        public RegStore32x512()
        {
            Storage = alloc<ByteBlock64>(32);
        }

        [MethodImpl(Inline)]
        public ref xmm Xmm(byte n)
            => ref Storage[n].Cell<xmm>(0);

        [MethodImpl(Inline)]
        public ref ymm Ymm(byte n)
            => ref Storage[n].Cell<ymm>(0);

        [MethodImpl(Inline)]
        public ref zmm Zmm(byte n)
            => ref Storage[n].Cell<zmm>(0);
    }
}