// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     public class Relation
//     {
//         public readonly dynamic Kind;

//         public readonly dynamic Source;

//         public readonly dynamic Target;

//         [MethodImpl(Inline)]
//         public Relation(dynamic kind, dynamic src, dynamic dst)
//         {
//             Kind = kind;
//             Source = src;
//             Target = dst;
//         }

//         public Hash32 Hash
//         {
//             [MethodImpl(Inline)]
//             get => sys.hash((object)Kind) | sys.hash((object)Source) | sys.hash((object)Target);
//         }

//         public string Format()
//             => string.Format("{0}:{1} -> {2}", Source, Target);

//         public override string ToString()
//             => Format();

//         [MethodImpl(Inline)]
//         public bool Equals(Relation src)
//             => Source == src.Source && Target == src.Target;

//         public override int GetHashCode()
//             => (int)Hash;
//     }
// }