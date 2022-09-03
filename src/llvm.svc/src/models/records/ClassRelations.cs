// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0.llvm
// {
//     [Record(TableId), StructLayout(LayoutKind.Sequential)]
//     public struct LineRelations : ILineRelations<LineRelations>
//     {
//         const string TableId = "llvm.classes.relations";

//         public const byte FieldCount = 4;

//         [Render(14)]
//         public LineNumber SourceLine;

//         [Render(60)]
//         public string Name;

//         [Render(110)]
//         public Lineage Ancestors;

//         [Render(1)]
//         public string Parameters;

//         LineNumber ILineRelations.SourceLine
//             => SourceLine;

//         string ILineRelations.Name
//             => Name;

//         public static LineRelations Empty => default;
//     }
// }