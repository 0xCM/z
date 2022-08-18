//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Encoded x86 bytes extracted from a memory source with a known (nonzero) location
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public readonly record struct CodeBlock : ICodeBlock<CodeBlock>
    {
        /// <summary>
        /// The head of the memory location from which the data originated
        /// </summary>
        public readonly MemoryAddress Address;

        /// <summary>
        /// The encoded content
        /// </summary>
        public readonly BinaryCode Code;

        [MethodImpl(Inline)]
        public CodeBlock(MemoryAddress src, byte[] data)
        {
            Address = src;
            Code = new BinaryCode(data ?? sys.empty<byte>());
        }

        [MethodImpl(Inline)]
        public CodeBlock(MemoryAddress src, in BinaryCode code)
        {
            Address = src;
            Code = code;
        }

        [MethodImpl(Inline)]
        CodeBlock(ulong zero)
        {
            Address = zero;
            Code = sys.empty<byte>();
        }

        MemoryAddress IAddressable.Address
            => Address;

        public ByteSize ByteCount
        {
            [MethodImpl(Inline)]
            get => Code.Size;
        }

        public byte[] Storage
        {
            [MethodImpl(Inline)]
            get => Code.Storage;
        }

        public ReadOnlySpan<byte> View
        {
            [MethodImpl(Inline)]
            get => Code.View;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Code.Length;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Code.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Code.IsNonEmpty;
        }

        public ref readonly byte this[long index]
        {
            [MethodImpl(Inline)]
            get => ref Code[index];
        }

        public ref readonly byte this[ulong index]
        {
            [MethodImpl(Inline)]
            get => ref Code[index];
        }

        [MethodImpl(Inline)]
        public bool Equals(CodeBlock src)
            => Code.Equals(src.Code);

        public string Format()
            => Code.Format();


        public override string ToString()
            => Format();

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Code.Hash;
        }

        [MethodImpl(Inline)]
        public int CompareTo(CodeBlock src)
            =>  Address.CompareTo(src.Address);

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public static implicit operator byte[](CodeBlock src)
            => src.Storage;

        [MethodImpl(Inline)]
        public static implicit operator BinaryCode(CodeBlock src)
            => src.Code;

        [MethodImpl(Inline)]
        public static implicit operator ReadOnlySpan<byte>(CodeBlock src)
            => src.View;

        public static CodeBlock Empty
            => new CodeBlock(0);
    }
}