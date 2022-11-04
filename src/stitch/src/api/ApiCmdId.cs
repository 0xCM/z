//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct ApiCmdId : IDataType<ApiCmdId>
    {
        readonly Hex32 Lo;

        readonly Hash32 Hi;

        [MethodImpl(Inline)]
        public ApiCmdId(uint data)
        {
            Lo = data;
            Hi = 0;
        }

        [MethodImpl(Inline)]
        public ApiCmdId(Hex32 data)
        {
            Lo = data;
            Hi = 0;
        }

        [MethodImpl(Inline)]
        public ApiCmdId(Hash32 data)
        {
            Lo = (Hex32)data;
            Hi = 0;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Lo == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Lo != 0;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => (Hash32)Lo;
        }

        public override int GetHashCode()
            => Hash;

        public string Format()
            => Lo.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public int CompareTo(ApiCmdId src)
            => Lo.CompareTo(src.Lo);

        [MethodImpl(Inline)]
        public bool Equals(ApiCmdId src)
            => Lo == src.Lo;

        [MethodImpl(Inline)]
        public static implicit operator ApiCmdId(Hash32 src)
            => new ApiCmdId(src);

        [MethodImpl(Inline)]
        public static implicit operator ApiCmdId(uint src)
            => new ApiCmdId(src);

        [MethodImpl(Inline)]
        public static implicit operator ApiCmdId(Hex32 src)
            => new ApiCmdId(src);
    }
}