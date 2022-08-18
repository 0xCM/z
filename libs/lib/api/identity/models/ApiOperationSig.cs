//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = ApiSigs;

    public class ApiOperationSig : ITextual
    {
        public NameOld Name {get;}

        public ApiOperandSig Return {get;}

        public Index<ApiOperandSig> Operands {get;}

        [MethodImpl(Inline)]
        public ApiOperationSig(NameOld name, ApiOperandSig @return, ApiOperandSig[] operands)
        {
            Name = name;
            Return = @return;
            Operands = operands;
        }

        public uint OperandCount
        {
            [MethodImpl(Inline)]
            get => (uint)Operands.Length;
        }

        public bool HasVoidReturn
        {
            [MethodImpl(Inline)]
            get => Return.IsVoid;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsNonEmpty;
        }
        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        public static ApiOperationSig Empty
        {
            [MethodImpl(Inline)]
            get => new ApiOperationSig(NameOld.Empty, ApiOperandSig.Empty, Index<ApiOperandSig>.Empty);
        }
    }
}