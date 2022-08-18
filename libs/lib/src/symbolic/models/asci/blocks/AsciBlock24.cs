//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using A = AsciBlock24;
    using B = ByteBlock24;
    using H = AsciBlock24;
    using C = AsciCode;
    using S = AsciSymbol;
    using N = N24;
    using api = AsciBlocks;

    /// <summary>
    /// Defines 24 bytes of storage
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size = Size, Pack=1), ApiComplete]
    public struct AsciBlock24 : IAsciBlock<A>
    {
        public const ushort Size = 24;

        public static N N => default;

        public static A zero() => Empty;

        public A Zero => zero();

        [MethodImpl(Inline)]
        public static A load(ReadOnlySpan<C> src)
            => api.load(src, out A _);

        [MethodImpl(Inline)]
        public static A load(ReadOnlySpan<S> src)
            => api.load(src, out A _);

        [MethodImpl(Inline)]
        public static A encode(string src)
            => api.encode(src, out A _);

        [MethodImpl(Inline)]
        public static A encode(ReadOnlySpan<char> src)
            => api.encode(src, out A _);
        public Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => bytes(this);
        }

        public Span<C> Codes
        {
            [MethodImpl(Inline)]
            get => recover<C>(Bytes);
        }

        public Span<S> Symbols
        {
            [MethodImpl(Inline)]
            get => recover<S>(Bytes);
        }

        public ref S this[int index]
        {
            [MethodImpl(Inline)]
            get => ref sys.seek(Symbols,index);
        }

        public ref S this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref sys.seek(Symbols,index);
        }

        public ref byte First
        {
            [MethodImpl(Inline)]
            get => ref first(Bytes);
        }


        [MethodImpl(Inline)]
        public Span<T> Storage<T>()
            where T : unmanaged
                => recover<T>(Bytes);

        [MethodImpl(Inline)]
        public static implicit operator B(A src)
            => @as<A,B>(src);

        [MethodImpl(Inline)]
        public static implicit operator A(string src)
            => encode(src);

        [MethodImpl(Inline)]
        public static implicit operator A(ReadOnlySpan<char> src)
            => encode(src);

        [MethodImpl(Inline)]
        public static implicit operator A(ReadOnlySpan<C> src)
            => load(src);

        [MethodImpl(Inline)]
        public static implicit operator A(ReadOnlySpan<S> src)
            => load(src);

        public static A Empty => default;
    }
}