// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     [StructLayout(LayoutKind.Sequential)]
//     public readonly record struct KindedFile
//     {
//         public readonly FilePath Path;

//         public readonly FileKind Kind;

//         public KindedFile(FilePath path, FileKind kind)
//         {
//             Path = path;
//             Kind = kind;
//         }

//         public bool IsEmpty
//         {
//             get => Kind == 0;            
//         }

//         public bool IsNonEmpty
//         {
//             get => Kind != 0;            
//         }

//         public static KindedFile Empty => new KindedFile(FilePath.Empty, FileKind.None);
//     }        
// }