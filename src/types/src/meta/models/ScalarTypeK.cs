// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     public class ScalarTypeInfo<K> : IEquatable<ScalarTypeInfo<K>>
//         where K : unmanaged, ISizedType, IEquatable<K>
//     {
//         public Identifier Name {get;}

//         public K Kind {get;}

//         public NativeClass NativeClass {get;}

//         public BitWidth ContentWidth {get;}

//         public BitWidth StorageWidth {get;}

//         [MethodImpl(Inline)]
//         public ScalarTypeInfo(Identifier name, NativeClass @class, K kind)
//         {
//             Name = name;
//             Kind = kind;
//             ContentWidth = kind.ContentWidth;
//             StorageWidth = kind.StorageWidth;
//         }

//         public bool IsEmpty
//         {
//             [MethodImpl(Inline)]
//             get => Name.IsEmpty;
//         }

//         public virtual string Format()
//             => IsEmpty ? EmptyString : Name;

//         public override string ToString()
//             => Format();

//         public bool Equals(ScalarTypeInfo<K> src)
//             => Name.Equals(src.Name) && ContentWidth == src.ContentWidth && Kind.Equals(src.Kind);

//         [MethodImpl(Inline)]
//         public static implicit operator ScalarType(ScalarTypeInfo<K> src)
//             => new ScalarType(src.Name, src.NativeClass, src.ContentWidth, src.StorageWidth);

//         public static ScalarType Empty
//         {
//             [MethodImpl(Inline)]
//             get => new ScalarType(EmptyString, NativeClass.None, 0, 0);
//         }
//     }
// }