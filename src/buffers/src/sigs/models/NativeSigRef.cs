//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial class NativeSigs
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly record struct NativeSigRef
    {
        const uint StringSize = 16;

        const uint OpCountSize = 1;

        const uint OpCountOffset = 0;

        const uint ScopeSize = StringSize;

        const uint NameSize = StringSize;

        const uint OperandSize = Operand.StorageSize;

        const uint ReturnSize = OperandSize;

        const uint ScopeOffset = OpCountOffset + OpCountSize;

        const uint NameOffset = ScopeOffset + ScopeSize;

        const uint ReturnOffset = NameOffset + NameSize;

        const uint OperandsOffset = ReturnOffset + ReturnSize;

        public readonly Hex64 Id;

        readonly MemorySegment DataRef;

        [MethodImpl(Inline)]
        public NativeSigRef(Hex64 id, MemorySegment data)
        {
            Id = id;
            DataRef = data;
        }

        readonly Span<byte> Data
        {
            [MethodImpl(Inline)]
            get => DataRef.Edit;
        }

        public ref byte OperandCount
        {
            [MethodImpl(Inline)]
            get =>  ref first(Data);
        }

        public ref StringRef Scope
        {
            [MethodImpl(Inline)]
            get => ref @as<StringRef>(seek(Data,ScopeOffset));
        }

        public ref StringRef Name
        {
            [MethodImpl(Inline)]
            get => ref @as<StringRef>(seek(Data,NameOffset));
        }

        public ref Operand Return
        {
            [MethodImpl(Inline)]
            get => ref @as<Operand>(seek(Data,ReturnOffset));
        }

        public Span<Operand> Operands
        {
            [MethodImpl(Inline)]
            get => recover<Operand>(slice(Data,OperandsOffset, OperandCount*OperandSize));
        }

        public ref Operand this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref seek(Operands,i);
        }

        public ref Operand this[int i]
        {
            [MethodImpl(Inline)]
            get => ref seek(Operands,i);
        }

        public string Format()
            => format(this);

        public string Format(SigFormatStyle style)
            => format(this, style);

        public override string ToString()
            => Format();
    }    
}
