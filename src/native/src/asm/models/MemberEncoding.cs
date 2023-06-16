//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly record struct MemberEncoding
    {
        public readonly ApiToken Token;

        readonly uint _Size;

        [MethodImpl(Inline)]
        public MemberEncoding(ApiToken token, uint size)
        {
            Token = token;
            _Size = size;
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => _Size;
        }

        public ulong Id
        {
            [MethodImpl(Inline)]
            get => Token.Id;
        }

        public MemoryAddress EntryAddress
        {
            [MethodImpl(Inline)]
            get => Token.EntryAddress;
        }

        public MemoryAddress TargetAddress
        {
            [MethodImpl(Inline)]
            get => Token.TargetAddress;
        }

        public Label Uri
        {
            [MethodImpl(Inline)]
            get => Token.Uri;
        }

        public Label Sig
        {
            [MethodImpl(Inline)]
            get => Token.Sig;
        }

        public override int GetHashCode()
            => (int)Token.EntryId;

        public ReadOnlySpan<byte> Data
        {
            [MethodImpl(Inline)]
            get => sys.cover(TargetAddress.Ref<byte>(), _Size);
        }

        public AsmHexCode AsmHex
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public string Format()
            => AsmHex.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(MemberEncoding src)
            => Token.Equals(src.Token);

        [MethodImpl(Inline)]
        public int CompareTo(MemberEncoding src)
            => Token.EntryAddress.CompareTo(src.Token.EntryAddress);
    }
}