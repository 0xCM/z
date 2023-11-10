//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedFields;

partial class XedRules
{
    public class FieldStateIndex
    {
        readonly Seq<FieldStates> Data;

        public FieldStateIndex(FieldStates[] src)
        {
            Data = src;
        }

        public ref FieldStates this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref FieldStates this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }
    }
}