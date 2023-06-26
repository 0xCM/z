//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedRules
{
    public partial class OperandStates : IIndex<OperandStates.StateRecord>
    {
        readonly Index<StateRecord> Data;

        [MethodImpl(Inline)]
        public ref readonly Index<StateRecord> Entries()
            => ref Data;

        [MethodImpl(Inline)]
        public bool Field(uint i, FieldKind kind, out FieldValue dst)
            => Data[i].Field(kind, out dst);

        public OperandStates(StateRecord[] src)
        {
            Data = src;
        }

        public ref StateRecord this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref StateRecord this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        StateRecord[] IIndex<StateRecord>.Storage
            => Data;
    }
}
