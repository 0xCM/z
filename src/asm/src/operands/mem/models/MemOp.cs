//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct MemOp : IMemOp
    {
        public static AsmPointerKind ptr(NativeSizeCode src)
            => src switch {
            NativeSizeCode.W8 => AsmPointerKind.@byte,
            NativeSizeCode.W16 => AsmPointerKind.word,
            NativeSizeCode.W32 => AsmPointerKind.dword,
            NativeSizeCode.W64 => AsmPointerKind.qword,
            NativeSizeCode.W128 => AsmPointerKind.xmmword,
            NativeSizeCode.W256 => AsmPointerKind.ymmword,
            NativeSizeCode.W512 => AsmPointerKind.zmmword,
                _ => AsmPointerKind.@byte
            };
        public static string format<T>(T src)
            where T : unmanaged, IMemOp
        {
            var dst = text.buffer();
            dst.Append(string.Format("{0} ptr [", expr(ptr(src.TargetSize))));
            dst.Append(src.Address.Format());
            dst.Append(Chars.RBracket);
            return dst.Emit();
        }

        static string expr<T>(T src)
            where T : unmanaged, Enum
                => Symbols.index<T>()[src].Expr.Format();

        public readonly NativeSize TargetSize;

        public readonly AsmAddress Address;

        [MethodImpl(Inline)]
        public MemOp(NativeSize target, AsmAddress address)
        {
            TargetSize = target;
            Address = address;
        }

        public AsmOpClass OpClass
        {
            [MethodImpl(Inline)]
            get => AsmOpClass.Mem;
        }

        public NativeSize Size
        {
            [MethodImpl(Inline)]
            get => TargetSize;
        }

        public AsmOpKind OpKind
        {
            [MethodImpl(Inline)]
            get => AsmOps.kind(OpClass, Size);
        }

        public string Format()
            => format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(MemOp src)
            => new AsmOperand(src);

        public static MemOp Empty => default;

        AsmAddress IMemOp.Address
            => Address;

        NativeSize IMemOp.TargetSize
            => Size;
    }
}