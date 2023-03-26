// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     public class Workspace : Project, IWorkspace
//     {
//         public ReadOnlySeq<ISolution> Solutions {get;}

//         [MethodImpl(Inline)]
//         public Workspace(string name, IDbArchive root, ReadOnlySeq<ISolution> solutions)
//             : base(name,root)
//         {
//             Solutions = solutions;            
//         }

//         public Workspace()
//         {
            
//         }

//         public bool IsEmpty
//         {
//             [MethodImpl(Inline)]
//             get => Root.IsEmpty;
//         }

//         public bool IsNonEmpty
//         {
//             [MethodImpl(Inline)]
//             get => Root.IsNonEmpty;
//         }
//     }
// }