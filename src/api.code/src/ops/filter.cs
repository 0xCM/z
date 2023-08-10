// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     using static sys;

//     partial class ApiCode
//     {
//         [Op]
//         public static ReadOnlySpan<MemberCodeBlock> filter(ReadOnlySpan<MemberCodeBlock> src, ApiClassKind kind)
//         {
//             var count = src.Length;
//             var dst = list<MemberCodeBlock>();
//             for(var i=0; i<count; i++)
//             {
//                 ref readonly var code = ref skip(src,i);
//                 if(code.KindId == kind)
//                     dst.Add(code);
//             }
//             return dst.ViewDeposited();
//         }
//     }
// }