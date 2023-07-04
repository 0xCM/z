// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     public interface IFileParser<T>
//     {
//         Outcome Parse(FileRef src, out T dst);
//     }

//     public interface IFileParser<F,T>
//         where F : IFile
//     {
//         Outcome Parse(F src, out T dst);
//     }

//     public interface IFileParser<P,F,T> : IFileParser<F,T>
//         where F : IFile
//         where P : IFileParser<P,F,T>, new()
//     {

//     }
// }