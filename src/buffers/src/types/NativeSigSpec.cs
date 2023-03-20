//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct NativeSigSpec
    {
        public readonly string Scope;

        public readonly string Name;

        public readonly NativeType ReturnType;

        public readonly Seq<NativeOpDef> Operands;

        [MethodImpl(Inline)]
        public NativeSigSpec(string scope, string name, NativeType ret, params NativeOpDef[] ops)
        {
            Scope = scope;
            Name = name;
            ReturnType = ret;
            Operands = ops;
        }

        public ref NativeOpDef this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Operands[i];
        }

        public ref NativeOpDef this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Operands[i];
        }

        public string Format()
            => NativeRender.format(this);

        public string Format(SigFormatStyle style)
            => NativeRender.format(this, style);

        public override string ToString()
            => Format();

    }
}