//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public unsafe readonly struct CorSig
    {
        readonly byte* Data;

        readonly ushort Size;

        [MethodImpl(Inline)]
        public CorSig(byte* pSrc, ushort size)
        {
            Data = pSrc;
            Size = size;
        }
    }
}