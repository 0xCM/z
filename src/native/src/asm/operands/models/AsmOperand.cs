//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using Operands;

    using static sys;

    using B = ByteBlock16;

    [StructLayout(LayoutKind.Sequential,Pack=1), ApiComplete]
    public struct AsmOperand : IAsmOp
    {
        public readonly AsmOpClass OpClass;

        public readonly AsmOpKind OpKind;

        public readonly NativeSize Size;

        B _Data;

        [MethodImpl(Inline)]
        public AsmOperand(RegOp src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,RegOp>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(Imm8 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,Imm>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(Imm16 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,Imm>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(Imm16i src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,Imm>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(Imm32 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,Imm>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(Imm64 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,Imm>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(MemOp src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,MemOp>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(m8 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,MemOp>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(m16 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,MemOp>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(m32 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,MemOp>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(m64 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,MemOp>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(m128 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,MemOp>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(m256 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,MemOp>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(m512 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,MemOp>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(Disp8 src)
        {
            OpClass = AsmOpClass.Disp;
            OpKind = AsmOpKind.Disp8;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,Disp>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(Disp16 src)
        {
            OpClass = AsmOpClass.Disp;
            OpKind = AsmOpKind.Disp16;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,Disp>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(Disp32 src)
        {
            OpClass = AsmOpClass.Disp;
            OpKind = AsmOpKind.Disp32;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,Disp>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(Disp64 src)
        {
            OpClass = AsmOpClass.Disp;
            OpKind = AsmOpKind.Disp64;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,Disp>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(Rel8 src)
        {
            OpClass = AsmOpClass.Rel;
            OpKind = AsmOpKind.Rel8;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,Rel>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(Rel16 src)
        {
            OpClass = AsmOpClass.Rel;
            OpKind = AsmOpKind.Rel16;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,Rel>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(Rel32 src)
        {
            OpClass = AsmOpClass.Rel;
            OpKind = AsmOpKind.Rel32;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,Rel>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(RegMask src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,RegMask>(_Data) = src;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => OpClass == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => OpClass == 0;
        }

        public ReadOnlySpan<byte> Data
        {
            [MethodImpl(Inline), UnscopedRef]
            get => _Data.Bytes;
        }

        public ref readonly RegOp Reg
        {
            [MethodImpl(Inline), UnscopedRef]
            get => ref @as<RegOp>(Data);
        }

        public ref readonly MemOp Mem
        {
            [MethodImpl(Inline), UnscopedRef]
            get => ref @as<MemOp>(Data);
        }

        public ref readonly Imm Imm
        {
            [MethodImpl(Inline), UnscopedRef]
            get  => ref @as<Imm>(Data);
        }

        public ref readonly RegMask RegMask
        {
            [MethodImpl(Inline), UnscopedRef]
            get => ref @as<RegMask>(Data);
        }

        public ref readonly Rel Rel
        {
            [MethodImpl(Inline), UnscopedRef]
            get => ref @as<Rel>(Data);
        }

        public ref readonly Disp Disp
        {
            [MethodImpl(Inline), UnscopedRef]
            get => ref @as<Disp>(Data);
        }

       public string Format()
            => AsmRender.format(this);

        public override string ToString()
            => Format();

        AsmOpClass IAsmOp.OpClass
            => OpClass;

        NativeSize IAsmOp.Size
            => Size;

        AsmOpKind IAsmOp.OpKind
            => OpKind;

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(Imm8 src)
            => new AsmOperand(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(Imm16 src)
            => new AsmOperand(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(Imm32 src)
            => new AsmOperand(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(Imm64 src)
            => new AsmOperand(src);

        public static AsmOperand Empty => default;
    }
}