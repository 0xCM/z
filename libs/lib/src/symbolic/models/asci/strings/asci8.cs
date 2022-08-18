//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 4040
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using N = N8;
    using A = asci8;
    using W = W64;
    using S = System.UInt64;
    using C = AsciCode;

    using api = Asci;

    /// <summary>
    /// Defines a 64-bit asci code sequence of length 8
    /// </summary>
    public readonly struct asci8 : IAsciSeq<A,N>
    {
        internal readonly S Storage;

        [MethodImpl(Inline)]
        public asci8(S src)
            => Storage = src;

        [MethodImpl(Inline)]
        public asci8(char c0)
            => Storage = (ulong)c0;

        [MethodImpl(Inline)]
        public asci8(char c0, char c1)
            => Storage = api.pack(c0, c1);

        [MethodImpl(Inline)]
        public asci8(char c0, char c1, char c2)
            => Storage = api.pack(c0,c1,c2);

        [MethodImpl(Inline)]
        public asci8(char c0, char c1, char c2, char c3)
            => Storage = api.pack(c0,c1,c2,c3);

        [MethodImpl(Inline)]
        public asci8(char c0, char c1, char c2, char c3, char c4)
            => Storage = api.pack(c0,c1,c2,c3,c4);

        [MethodImpl(Inline)]
        public asci8(char c0, char c1, char c2, char c3, char c4, char c5)
            => Storage = api.pack(c0,c1,c2,c3,c4,c5);

        [MethodImpl(Inline)]
        public asci8(char c0, char c1, char c2, char c3, char c4, char c5, char c6)
            => Storage = api.pack(c0,c1,c2,c3,c4,c5,c6);

        [MethodImpl(Inline)]
        public asci8(char c0, char c1, char c2, char c3, char c4, char c5, char c6, char c7)
            => Storage = api.pack(c0,c1,c2,c3,c4,c5,c6,c7);

        [MethodImpl(Inline)]
        public asci8(C c0)
            => Storage = (ulong)c0;

        [MethodImpl(Inline)]
        public asci8(C c0, C c1)
            => Storage = api.pack(c0, c1);

        [MethodImpl(Inline)]
        public asci8(C c0, C c1, C c2)
            => Storage = api.pack(c0,c1,c2);

        [MethodImpl(Inline)]
        public asci8(C c0, C c1, C c2, C c3)
            => Storage = api.pack(c0,c1,c2,c3);

        [MethodImpl(Inline)]
        public asci8(C c0, C c1, C c2, C c3, C c4)
            => Storage = api.pack(c0,c1,c2,c3,c4);

        [MethodImpl(Inline)]
        public asci8(C c0, C c1, C c2, C c3, C c4, C c5)
            => Storage = api.pack(c0,c1,c2,c3,c4,c5);

        [MethodImpl(Inline)]
        public asci8(C c0, C c1, C c2, C c3, C c4, C c5, C c6)
            => Storage = api.pack(c0,c1,c2,c3,c4,c5,c6);

        [MethodImpl(Inline)]
        public asci8(C c0, C c1, C c2, C c3, C c4, C c5, C c6, C c7)
            => Storage = api.pack(c0,c1,c2,c3,c4,c5,c6,c7);

        [MethodImpl(Inline)]
        public asci8(string src)
            => Storage = Asci.encode(n,src).Storage;

        [MethodImpl(Inline)]
        public asci8(ReadOnlySpan<char> src)
            => Storage = Asci.encode(n,src).Storage;

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
            get => Equals(Null);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !Equals(Null);
        }

        public A Zero
        {
            [MethodImpl(Inline)]
            get => Null;
        }

        public C this[int index]
        {
            [MethodImpl(Inline)]
            get => (C)(Storage >> index*8);
        }

        /// <summary>
        /// Specifies the number of characters that precede a null terminator, if any; otherwise, returns the maximum content length
        /// </summary>
        public int Length
        {
            [MethodImpl(Inline)]
            get => Asci.length(this);
        }

        public int Capacity
        {
            [MethodImpl(Inline)]
            get => Size;
        }

        public Span<byte> Edit
        {
            [MethodImpl(Inline)]
            get => core.bytes(Storage);
        }

        public ReadOnlySpan<byte> View
        {
            [MethodImpl(Inline)]
            get => api.bytes(this);
        }

        public ReadOnlySpan<char> Decoded
        {
            [MethodImpl(Inline)]
            get => api.decode(this);
        }

        public TextBlock Text
        {
            [MethodImpl(Inline)]
            get => text.format(Decoded);
        }

        [MethodImpl(Inline)]
        public Vector128<byte> EncodedVector()
            => cpu.v8u(cpu.vscalar(w128,Storage));

        [MethodImpl(Inline)]
        public Vector128<ushort> DecodedVector()
            => api.decode(Storage);

        [MethodImpl(Inline)]
        public void Store(Span<char> dst)
            => api.store(this,dst);

        [MethodImpl(Inline)]
        public int CompareTo(A src)
            => Text.CompareTo(src.Text);

        [MethodImpl(Inline)]
        public bool Equals(A src)
            => Storage.Equals(src.Storage);

        public override bool Equals(object src)
            => src is A x && Equals(x);

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => core.hash(Storage);
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public string Format()
            => Text;

        public override string ToString()
            => Text;

        public const int Size = 8;

        static N n => default;

        static W w => default;
        public static A Null
        {
            [MethodImpl(Inline)]
            get => new A(default(S));
        }

        public static A Spaced
        {
            [MethodImpl(Inline)]
            get => Asci.init(n);
        }

        [MethodImpl(Inline)]
        public static implicit operator A(string src)
            => new A(src);

        [MethodImpl(Inline)]
        public static implicit operator A(ReadOnlySpan<char> src)
            => new A(src);

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

        [MethodImpl(Inline)]
        public static implicit operator A(uint src)
            => new A(src);

        [MethodImpl(Inline)]
        public static implicit operator A(S src)
            => new A(src);

        [MethodImpl(Inline)]
        public static explicit operator S(A src)
            => src.Storage;

        [MethodImpl(Inline)]
        public static bool operator ==(A a, A b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(A a, A b)
            => !a.Equals(b);

         [MethodImpl(Inline)]
        public static implicit operator AsciSeq<N,A>(A src)
            => new AsciSeq<N,A>(src);

        [MethodImpl(Inline)]
        public static implicit operator AsciSeq<A>(A src)
            => new AsciSeq<A>(src);
    }
}