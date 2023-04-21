// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     public sealed class EnvVars<T> : ReadOnlySeq<EnvVars<T>,EnvVar<T>>
//         where T : IEquatable<T>, new()
//     {
//         readonly ConstLookup<@string,T> Lookup;

//         public EnvVars()
//         {

//         }

//         public EnvVars(EnvVar<T>[] src)
//             : base(src)
//         {
//             Lookup = src.Map(x => (x.Name, x.Value)).ToDictionary();
//         }

//         public T this[string name]
//         {            
//             get
//             {
//                 var value = new T();
//                 Find(name, out value);
//                 return value;
//             }
//         }

//         public bool Find(string name, out T value)
//             => Lookup.Find(name, out value);

//         public ReadOnlySpan<@string> Names
//         {
//             [MethodImpl(Inline)]
//             get => Lookup.Keys;
//         }

//         public static implicit operator EnvVars<T>(EnvVar<T>[] src)
//             => new EnvVars<T>(src);
//     }
// }