//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedModels
{
    public readonly record struct PatternKey
    {
        readonly XedInstForm Form;

        readonly MachineMode Mode;

        readonly ushort Index;

        readonly bit Lock;

        public PatternKey(XedInstForm form, MachineMode mode, bool @lock, byte index)
        {
            Form = form;
            Mode = mode;
            Lock = @lock;
            Index = index;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => (uint)Form | ((uint)Index << 16) | ((uint)Mode.Class << 24) | ((uint)Lock << 28);
        }

        public override int GetHashCode()
            => Hash;

        public bool Equals(PatternKey src)
            => Form == src.Form && Index == src.Index && Mode == src.Mode && Lock == src.Lock;
    }   

}
