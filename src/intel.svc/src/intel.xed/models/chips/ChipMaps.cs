//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public readonly struct ChipMap
        {
            readonly ConstLookup<ChipCode,InstIsaKinds> Data;

            [MethodImpl(Inline)]
            public ChipMap(ConstLookup<ChipCode,InstIsaKinds> src)
            {
                Data = src;
            }

            public InstIsaKinds this[ChipCode code]
            {
                [MethodImpl(Inline)]
                get => Data[code];
            }

            public ReadOnlySpan<ChipCode> Codes
            {
                [MethodImpl(Inline)]
                get => Data.Keys;
            }
            
            public ReadOnlySpan<InstIsaKinds> Kinds
            {
                [MethodImpl(Inline)]
                get => Data.Values;
            }

            public static ChipMap Empty => new ChipMap(core.dict<ChipCode,InstIsaKinds>());
        }
    }
}