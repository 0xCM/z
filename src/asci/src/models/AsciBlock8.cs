// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     using static sys;

//     using A = AsciBlock8;
//     using B = ByteBlock8;
//     using N = N8;
//     using C = AsciCode;
//     using S = AsciSymbol;
//     using api = AsciBlocks;

//     /// <summary>
//     /// Defines 16 bytes of storage
//     /// </summary>
//     [StructLayout(LayoutKind.Sequential, Size = Size, Pack=1), ApiComplete]
//     public record struct AsciBlock8
//     {
//         public static A Empty => default;

//         public const ushort Size = 8;

//         public static N N => default;

//         public static A zero() => Empty;

//         public A Zero => zero();

//         [MethodImpl(Inline)]
//         public static A load(ReadOnlySpan<C> src)
//             => api.load(src, out A _);

//         [MethodImpl(Inline)]
//         public static A load(ReadOnlySpan<S> src)
//             => api.load(src, out A _);

//         [MethodImpl(Inline)]
//         public static A encode(string src)
//             => api.encode(src, out A _);

//         [MethodImpl(Inline)]
//         public static A encode(ReadOnlySpan<char> src)
//             => api.encode(src, out A _);

//         public Span<byte> Bytes
//         {
//             [MethodImpl(Inline), UnscopedRef]
//             get => bytes(this);
//         }

//         public Span<C> Codes
//         {
//             [MethodImpl(Inline), UnscopedRef]
//             get => recover<C>(Bytes);
//         }

//         public Span<S> Symbols
//         {
//             [MethodImpl(Inline), UnscopedRef]
//             get => recover<S>(Bytes);
//         }

//         public ref S this[int index]
//         {
//             [MethodImpl(Inline), UnscopedRef]
//             get => ref sys.seek(Symbols,index);
//         }

//         public ref S this[uint index]
//         {
//             [MethodImpl(Inline), UnscopedRef]
//             get => ref sys.seek(Symbols,index);
//         }

//         public ref byte First
//         {
//             [MethodImpl(Inline), UnscopedRef]
//             get => ref first(Bytes);
//         }

//         [MethodImpl(Inline), UnscopedRef]
//         public Span<T> Storage<T>()
//             where T : unmanaged
//                 => recover<T>(Bytes);

//         [MethodImpl(Inline)]
//         public static implicit operator B(A src)
//             => @as<A,B>(src);

//         [MethodImpl(Inline)]
//         public static implicit operator ulong(A src)
//             => sys.u64(src);

//         [MethodImpl(Inline)]
//         public static implicit operator A(string src)
//             => api.encode(src, out A _);

//         [MethodImpl(Inline)]
//         public static implicit operator A(ReadOnlySpan<char> src)
//             => api.encode(src, out A _);

//         [MethodImpl(Inline)]
//         public static implicit operator A(ReadOnlySpan<C> src)
//             => load(src);

//         [MethodImpl(Inline)]
//         public static implicit operator A(ReadOnlySpan<S> src)
//             => load(src);
//     }
// }