// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     public class ProjectWorkspace : IProjectWorkspace
//     {
//         public ProjectId ProjectId {get;}

//         public IDbArchive Root {get;}

//         public ReadOnlySeq<ISolution> Solutions 
//             => sys.empty<ISolution>();

//         public @string Name 
//             => ProjectId.Format();

//         FolderPath IRootedArchive.Root 
//             => Root.Root;

//         public FileIndex FileIndex {get;}

//         [MethodImpl(Inline)]
//         public ProjectWorkspace(IDbArchive src, ProjectId id)
//         {
//             Root = src;
//             FileIndex = FS.index(src.Files());
//             ProjectId = id;
//         }        
//     }
// }