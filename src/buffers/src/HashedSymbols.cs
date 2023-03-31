// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     using static sys;

//     public class HashedSymbols
//     {
//         StringBuffer Buffer;

//         Index<HashedSymbol> Hashed;

//         uint Allocated;

//         uint SymIndex;

//         uint Capacity
//         {
//             [MethodImpl(Inline)]
//             get => Buffer.Length;
//         }

//         public static bool contains(StringBuffer buffer, string src)
//         {
//             var location = address(src);
//             return location >= buffer.BaseAddress && location <= buffer.BaseAddress + buffer.Size;
//         }

//         bool HashSymbol(string src)
//         {
//             if(!contains(Buffer,src) && SymIndex < Hashed.Length - 1)
//             {
//                 var offset = Allocated;
//                 var len = (uint)src.Length;
//                 var total = offset + len;
//                 if(total > Capacity)
//                     return false;

//                 if(Buffer.Store(src, Allocated))
//                 {
//                     Allocated += len;
//                     Hashed[SymIndex++] = new HashedSymbol(new StringRef(Buffer.Address(offset), len), hash(src));
//                     return true;
//                 }
//             }
//             return false;
//         }
//     }
// }