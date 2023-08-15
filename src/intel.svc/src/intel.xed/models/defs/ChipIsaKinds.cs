//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedModels
    {
        public readonly struct ChipIsaKinds
        {
            public readonly ChipCode Chip;

            public readonly InstIsaKinds Kinds;

            [MethodImpl(Inline)]
            public ChipIsaKinds(ChipCode chip, InstIsaKinds kinds)
            {
                Chip = chip;
                Kinds = kinds;
            }

            public ChipIsaKinds(ChipCode chip)
            {
                Chip = chip;
                Kinds = new();
            }

            public void Add(InstIsaKind kind)
            {
                Kinds.Add(kind);
            }

            public void Add(InstIsaKind[] kinds)
            {
                foreach(var k in kinds)
                    Kinds.Add(k);
            }

            public uint Count
            {
                [MethodImpl(Inline)]
                get => (uint)Kinds.Count;
            }
        }
    }
}