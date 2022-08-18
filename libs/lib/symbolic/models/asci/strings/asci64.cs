//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 4040
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;

    using N = N64;
    using W = W512;
    using A = asci64;
    using S = Vector512<byte>;
    using api = Asci;

    [DataWidth(512)]
    public readonly struct asci64 : IAsciSeq<A,N>
    {
        public const int Size = 64;

        internal readonly S Storage;

        [MethodImpl(Inline)]
        public asci64(S src)
            => Storage = src;

        [MethodImpl(Inline)]
        public asci64(Vector256<byte> a)
            => Storage = Vector512<byte>.from(a);

        [MethodImpl(Inline)]
        public asci64(Vector256<byte> a, Vector256<byte> b)
            => Storage = Vector512<byte>.from(a,b);

        [MethodImpl(Inline)]
        public asci64(Vector128<byte> a)
            => Storage = Vector512<byte>.from(a);

        [MethodImpl(Inline)]
        public asci64(Vector128<byte> a, Vector128<byte> b)
            => Storage = Vector512<byte>.from(a, b);

        [MethodImpl(Inline)]
        public asci64(Vector128<byte> a, Vector128<byte> b, Vector128<byte> c)
            => Storage = Vector512<byte>.from(a, b, c);

        [MethodImpl(Inline)]
        public asci64(Vector128<byte> a, Vector128<byte> b, Vector128<byte> c, Vector128<byte> d)
            => Storage = Vector512<byte>.from(a, b, c, d);

        [MethodImpl(Inline)]
        public asci64(string src)
            => Storage = api.encode(n,src).Storage;

        [MethodImpl(Inline)]
        public asci64(ReadOnlySpan<byte> src)
            => Storage = cpu.vload(w, first(src));

        public bool IsBlank
        {
            [MethodImpl(Inline)]
            get => IsNull || Equals(Spaced);
        }

        public bool IsNull
        {
            [MethodImpl(Inline)]
            get => Equals(Null);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Storage.Equals(default);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !Storage.Equals(default);
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => api.length(this);
        }

        public int Capacity
        {
            [MethodImpl(Inline)]
            get => Size;
        }

        public ReadOnlySpan<byte> View
        {
            [MethodImpl(Inline)]
            get => api.bytes(this);
        }

        public A Zero
        {
            [MethodImpl(Inline)]
            get => default;
        }

        public asci32 Lo
        {
            [MethodImpl(Inline)]
            get => new asci32(Storage.Lo);
        }

        public asci32 Hi
        {
            [MethodImpl(Inline)]
            get => new asci32(Storage.Hi);
        }

        public ReadOnlySpan<char> Decoded
        {
            [MethodImpl(Inline)]
            get => api.decode(this);
        }

        public TextBlock Text
        {
            [MethodImpl(Inline)]
            get => text.format(Decoded,true);
        }

        [MethodImpl(Inline)]
        public Vector512<byte> EncodedVector()
            => Storage;

        [MethodImpl(Inline)]
        public Vector256<byte> EncodedVector(N0 n)
            => Storage.Lo;

        [MethodImpl(Inline)]
        public Vector256<byte> EncodedVector(N1 n)
            => Storage.Hi;

        [MethodImpl(Inline)]
        public Vector128<byte> EncodedVector(N0 n, W128 w)
            => Storage[n];

        [MethodImpl(Inline)]
        public Vector128<byte> EncodedVector(N1 n, W128 w)
            => Storage[n];

        [MethodImpl(Inline)]
        public Vector128<byte> EncodedVector(N2 n, W128 w)
            => Storage[n];

        [MethodImpl(Inline)]
        public Vector128<byte> EncodedVector(N3 n, W128 w)
            => Storage[n];

        [MethodImpl(Inline)]
        public void CopyTo(Span<byte> dst)
            => api.copy(this,dst);

        [MethodImpl(Inline)]
        public int CompareTo(A src)
            => Text.CompareTo(src.Text);

        [MethodImpl(Inline)]
        public string Format()
            => Text;

        public override string ToString()
            => Format();

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => core.hash(Storage);
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(A src)
            => Storage.Equals(src.Storage);


        public override bool Equals(object src)
            => src is A j && Equals(j);

        public static A Spaced
        {
            [MethodImpl(Inline)]
            get => api.init(n);
        }

        public static A Null => default;

        [MethodImpl(Inline)]
        public static implicit operator A(string src)
            => new A(src);

        [MethodImpl(Inline)]
        public static implicit operator A(asci32 src)
            => new A(src.EncodedVector());

        [MethodImpl(Inline)]
        public static implicit operator A(asci16 src)
            => new A(src.EncodedVector());

        [MethodImpl(Inline)]
        public static implicit operator A(asci8 src)
            => new A(src.EncodedVector());

        [MethodImpl(Inline)]
        public static implicit operator A(TextBlock src)
            => new A(src.Format());

        [MethodImpl(Inline)]
        public static implicit operator string(A src)
            => src.Text;

        [MethodImpl(Inline)]
        public static implicit operator ReadOnlySpan<byte>(A src)
            => src.View;

        [MethodImpl(Inline)]
        public static implicit operator ReadOnlySpan<char>(A src)
            => src.Decoded;

        static N n => default;

        static W w => default;

        [MethodImpl(Inline)]
        public static implicit operator AsciSeq<N,A>(A src)
            => new AsciSeq<N,A>(src);

        [MethodImpl(Inline)]
        public static implicit operator AsciSeq<A>(A src)
            => new AsciSeq<A>(src);
    }
}