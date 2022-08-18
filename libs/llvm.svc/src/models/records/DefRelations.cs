// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0.llvm
// {
//     [Record(TableId)]
//     public struct LineRelations : ILineRelations<LineRelations>, IComparable<LineRelations>
//     {
//         const string TableId = "llvm.defs.relations";

//         public const byte FieldCount = 3;

//         [Render(14)]
//         public LineNumber SourceLine;

//         [Render(64)]
//         public string Name;

//         [Render(1)]
//         public Lineage Ancestors;

//         LineNumber ILineRelations.SourceLine
//             => SourceLine;

//         string ILineRelations.Name
//             => Name;

//         [MethodImpl(Inline)]
//         public LineRelations(LineNumber line, string name, Lineage ancestors)
//         {
//             SourceLine = line;
//             Name = name;
//             Ancestors = ancestors ?? Lineage.Empty;
//         }

//         public string ParentName
//             => Lineage.parent(Ancestors);

//         public Index<string> AncestorNames
//             => Lineage.ancestors(Ancestors);

//         public int CompareTo(LineRelations src)
//         {
//             var i = Name.CompareTo(src.Name);
//             if(i == 0)
//                 return ParentName.CompareTo(src.ParentName);
//             else
//                 return i;
//         }

//         public static LineRelations Empty
//             => new LineRelations(LineNumber.Empty, EmptyString, Lineage.Empty);
//     }
// }