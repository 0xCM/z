// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     using static sys;

//     /// <summary>
//     /// Specifies a signed-extended immediate
//     /// </summary>
//     [StructLayout(StructLayout,Pack=1)]
//     public readonly record struct ImmSx<S,X> : ISignExtension<S,X>, IDataType<ImmSx<S,X>>
//         where S : unmanaged, IImmOp<S>
//         where X : unmanaged, IImmOp<X>
//     {
//         /// <summary>
//         /// The source value
//         /// </summary>
//         public readonly S Source;

//         /// <summary>
//         /// The sign-extended value
//         /// </summary>
//         public readonly X Target;

//         [MethodImpl(Inline)]
//         public ImmSx(S src, X dst)
//         {
//             Source = src;
//             Target = dst;
//         }

//         public Hash32 Hash
//         {
//             [MethodImpl(Inline)]
//             get => u32(Source);
//         }

//         public override int GetHashCode()
//             => Hash;

//         public bool IsZero
//         {
//             [MethodImpl(Inline)]
//             get => i64(Target) == 0;
//         }

//         bool INullity.IsEmpty
//             => IsZero;

//         [MethodImpl(Inline)]
//         public bool Equals(ImmSx<S,X> src)
//             => i64(Source) == i64(src.Source) && i64(Target) == i64(src.Target);

//         [MethodImpl(Inline)]
//         public int CompareTo(ImmSx<S,X> src)
//             => i64(Target).CompareTo(i64(src.Target));

//         public string Format()
//             => i64(Target).FormatHex();

//         public override string ToString()
//             => Format();

//         S ISignExtension<S,X>.Source
//             => Source;

//         X ISignExtension<S,X>.Target
//             => Target;

//         public static ImmSx<S,X> Zero => default;

//         [MethodImpl(Inline)]
//         public static implicit operator ImmSx<S,X>((S src, X dst) x)
//             => new ImmSx<S,X>(x.src,x.dst);

//     }
// }