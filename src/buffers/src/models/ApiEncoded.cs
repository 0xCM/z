//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly record struct ApiEncoded : IDataType<ApiEncoded>
    {
        public readonly ApiToken Token;

        public readonly BinaryCode Code;

        [MethodImpl(Inline)]
        public ApiEncoded(ApiToken token, BinaryCode code)
        {
            Token = token;
            Code = code;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Token.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Token.IsNonEmpty;
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

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => (Hash32)(uint)Token.EntryId;
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(ApiEncoded src)
            => Token.Equals(src.Token);

        [MethodImpl(Inline)]
        public int CompareTo(ApiEncoded src)
            => Token.EntryAddress.CompareTo(src.Token.EntryAddress);

        public static ApiEncoded Empty => new (ApiToken.Empty, sys.empty<byte>());
    }
}