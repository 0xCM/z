//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedRules;

partial class XedFields
{
    public partial class StateIndex : IIndex<States>
    {
        readonly Index<States> Data;

        [MethodImpl(Inline)]
        public ref readonly Index<States> Entries()
            => ref Data;

        [MethodImpl(Inline)]
        public bool Field(uint i, FieldKind kind, out FieldValue dst)
            => Data[i].Field(kind, out dst);

        public StateIndex(States[] src)
        {
            Data = src;
        }

        public ref States this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref States this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        States[] IIndex<States>.Storage
            => Data;
    }
}