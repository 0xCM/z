// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     partial class math
//     {
//         [Op]
//         public static unsafe int intersect(ushort* rcx, int rdx,  ushort* r8, int r9, ushort* dst)
//         {
//             var found = 0;
//             int i_a = 0, i_b = 0;

//             while(i_a < rdx && i_b < rdx)
//             {
//                 if(rcx[i_a] == r8[i_b])
//                 {
//                     dst[found++] = rcx[i_a];
//                     i_a++;
//                     i_b++;
//                 }
//                 else if (rcx[i_a] > r8[i_b])
//                     i_b++;
//                 else
//                     i_a++;
//             }

//             return found;
//         }

//         [Op]
//         public static int intersect(ReadOnlySpan<ushort> left, ReadOnlySpan<ushort> right, Span<ushort> dst)
//         {
//             var found = 0;
//             var l_a = left.Length;
//             var l_b = right.Length;
//             var limit = dst.Length;
//             int i_a = 0, i_b = 0;
//             while(i_a < l_a && i_b < l_a && found < limit)
//             {
//                 ref readonly var a = ref sys.skip(left,i_a);
//                 ref readonly var b = ref sys.skip(right,i_b);

//                 if(a == b)
//                 {
//                     sys.seek(dst, found++) = a;
//                     i_a++;
//                     i_b++;
//                 }
//                 else if (a > b)
//                     i_b++;
//                 else
//                     i_a++;
//             }
            
//             return found;
//         }

//     }
// }