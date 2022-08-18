//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct BitFormatCheck<W,T> : IRecord<BitFormatCheck<W,T>>
        where W : unmanaged, IDataWidth
        where T : unmanaged, IBitNumber
    {
        public uint Seq;

        public T Value;

        public string Formatted;

        public uint LengthExpect;

        public uint LengthActual;

        public bool LenthMatch;
    }
}