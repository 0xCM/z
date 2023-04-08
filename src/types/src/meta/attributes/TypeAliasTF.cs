// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     public abstract class TypeAlias<F,T> : ITypeAlias<T>
//         where F : TypeAlias<F,T>, new()
//         where T : IType
//     {
//         public T Type {get;}

//         public Identifier Alias {get;}

//         protected TypeAlias(T type, Identifier alias)
//         {
//             Type = type;
//             Alias = alias;
//         }
//     }
// }