//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct CellTypes : IIndex<CellTypeInfo>
        {
            readonly Index<CellTypeInfo> Data;

            [MethodImpl(Inline)]
            public CellTypes(CellTypeInfo[] src)
            {
                Data = src;
            }

            public uint Count
            {
                [MethodImpl(Inline)]
                get => Data.Count;
            }

            public ref CellTypeInfo this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Data[i];
            }

            public ref CellTypeInfo this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Data[i];
            }

            public CellTypeInfo[] Storage
            {
                [MethodImpl(Inline)]
                get => Data.Storage;
            }

            [MethodImpl(Inline)]
            public static implicit operator CellTypes(CellTypeInfo[] src)
                => new CellTypes(src);

            [MethodImpl(Inline)]
            public static implicit operator CellTypeInfo[](CellTypes src)
                => src.Data;
        }
    }
}