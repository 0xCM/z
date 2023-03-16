// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     using static sys;

//     [ApiHost]
//     public partial class Symbolic
//     {

//         [Parser]
//         public static Outcome parse(string src, out SymInfo dst)
//         {
//             const byte FieldCount = 9;
//             var outcome = Outcome.Success;
//             var j=0;
//             var cells = text.split(src,Chars.Pipe);
//             if(cells.Length != FieldCount)
//             {
//                 dst = default;
//                 return (false, AppMsg.FieldCountMismatch.Format(FieldCount, cells.Length));
//             }

//             dst.Group = skip(cells,j++);
//             dst.Type = skip(cells,j++);
//             Sizes.parse(skip(cells,j++), out dst.Size);
//             uint.TryParse(skip(cells,j++), out dst.Index);
//             dst.Name = skip(cells,j++);
//             SymVal.parse(skip(cells,j++), out dst.Value);
//             SymExpr.parse(skip(cells,j++), out dst.Expr);
//             dst.Description = skip(cells,j++);

//             return outcome;
//         }

//         [Parser]
//         public static Outcome parse(string src, out SymLiteralRow dst)
//         {
//             var outcome = Outcome.Success;
//             var j=0;
//             var cells = text.split(src,Chars.Pipe);
//             if(cells.Length != SymLiteralRow.FieldCount)
//             {
//                 dst = default;
//                 return (false, AppMsg.FieldCountMismatch.Format(SymLiteralRow.FieldCount, cells.Length));
//             }

//             DataParser.parse(skip(cells,j++), out dst.Component);
//             DataParser.parse(skip(cells,j++), out dst.Type);
//             DataParser.parse(skip(cells,j++), out dst.Group);
//             DataParser.parse(skip(cells,j++), out dst.Size);
//             DataParser.parse(skip(cells,j++), out dst.Index);
//             DataParser.parse(skip(cells,j++), out dst.Name);
//             DataParser.parse(skip(cells,j++), out dst.Symbol);
//             Enums.parse(skip(cells,j++), out dst.DataType);
//             DataParser.parse(skip(cells,j++), out dst.Value);
//             Enums.parse(skip(cells,j++), out dst.Base);
//             DataParser.parse(skip(cells,j++), out dst.Hidden);
//             DataParser.parse(skip(cells,j++), out dst.Description);
//             DataParser.parse(skip(cells,j++), out dst.Identity);
//             return outcome;
//         }
//     }
// }