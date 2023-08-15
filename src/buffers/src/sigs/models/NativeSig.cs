//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class NativeSigs
{
    public readonly record struct NativeSig
    {
        public readonly string Scope;

        public readonly string Name;

        public readonly NativeType ReturnType;

        public readonly Seq<Operand> Operands;

        [MethodImpl(Inline)]
        public NativeSig(string scope, string name, NativeType ret, params Operand[] ops)
        {
            Scope = scope;
            Name = name;
            ReturnType = ret;
            Operands = ops;
        }

        public ref Operand this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Operands[i];
        }

        public ref Operand this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Operands[i];
        }

        public string Format()
            => format(this);

        public string Format(SigFormatStyle style)
            => format(this, style);

        public override string ToString()
            => Format();
    }    
}
