//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines a 128-bit bitfield that identifies an api operation along with its operands
    /// </summary>
    /// <remarks>
    /// [ Operands              | ApiClass  | Host | Component ]
    /// [ 7 | 6 | 5 | 4 | 3     | 2         | 1    | 0         ]
    /// </remarks>
    [ApiComplete]
    public readonly record struct ApiKey
    {
        public static W128 W => default;

        [MethodImpl(Inline)]
        public static K kind<K>(ApiKey src)
            => @as<ApiKeySeg,K>(src.Seg(n2));

        readonly Cell128 Storage;

        [MethodImpl(Inline)]
        public ApiKey(ReadOnlySpan<byte> src)
            => Storage = Cells.load(W,src);

        [MethodImpl(Inline)]
        public ApiKey(ReadOnlySpan<ushort> src)
            => Storage = Cells.load(W,src);

        [MethodImpl(Inline)]
        public ApiKey(ReadOnlySpan<ApiKeySeg> src)
            => Storage = Cells.load(W,bytes(src));

        [MethodImpl(Inline)]
        public ApiKey(Cell128 src)
            => Storage = src;

        public DataWidth Width
            => DataWidth.W128;

        public ReadOnlySpan<byte> Data
        {
            [MethodImpl(Inline)]
            get => Storage.Bytes;
        }

        [MethodImpl(Inline)]
        public ApiKeySeg Seg(byte index)
            => Storage.Cell(w16, index);

        [MethodImpl(Inline)]
        public ApiKey WithSeg(byte index, ApiKeySeg src)
        {
            var dst = recover<ushort>(Storage.Bytes);
            seek(dst, index) = src;
            return new ApiKey(Cells.load(w128, Storage.Bytes));
        }

        [MethodImpl(Inline)]
        public ApiKeySeg Seg(N0 n)
            => Seg(0);

        [MethodImpl(Inline)]
        public ApiKeySeg Seg(N1 n)
            => Seg(1);

        [MethodImpl(Inline)]
        public ApiKeySeg Seg(N2 n)
            => Seg(2);

        [MethodImpl(Inline)]
        public ApiKeySeg Seg(N3 n)
            => Seg(3);

        [MethodImpl(Inline)]
        public ApiKeySeg Seg(N4 n)
            => Seg(4);

        [MethodImpl(Inline)]
        public ApiKeySeg Seg(N5 n)
            => Seg(5);

        [MethodImpl(Inline)]
        public ApiKeySeg Seg(N6 n)
            => Seg(6);

        [MethodImpl(Inline)]
        public ApiKeySeg Seg(N7 n)
            => Seg(7);

        public Vector128<byte> V8u
        {
            [MethodImpl(Inline)]
            get => Storage;
        }

        public Vector128<ushort> V16u
        {
            [MethodImpl(Inline)]
            get => Storage.V16u;
        }

        public string Format()
            => ApiKeys.format(this);

        public override string ToString()
            => Format();
        [MethodImpl(Inline)]
        public static implicit operator ApiKey(ReadOnlySpan<byte> src)
            => new ApiKey(src);

        [MethodImpl(Inline)]
        public static implicit operator ReadOnlySpan<byte>(ApiKey src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator ApiKey(ReadOnlySpan<ApiKeySeg> src)
            => new ApiKey(src);

        [MethodImpl(Inline)]
        public static implicit operator ApiKey(Span<byte> src)
            => new ApiKey(src);

        [MethodImpl(Inline)]
        public static implicit operator ApiKey(Span<ApiKeySeg> src)
            => new ApiKey(src);

        public static ApiKey Empty => default;
    }
}