// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     using static sys;

//     using C = AsciCode;

//     partial struct Hex
//     {
//         public static string clear(string src)
//             => src.Remove("0x").RemoveAny('h');

//         [MethodImpl(Inline), Op]
//         public static ReadOnlySpan<char> clear(ReadOnlySpan<char> src)
//         {
//             var output = src;
//             if(src.Length >= 2)
//             {
//                 ref readonly var c0 = ref skip(src,0);
//                 ref readonly var c1 = ref skip(src,1);
//                 if(c0 == '0' & c1 == 'x')
//                     output = slice(src,2);
//                 else
//                 {
//                     ref readonly var c = ref skip(src,src.Length-1);
//                     if(c == 'h')
//                         output = slice(src,0, src.Length - 1);
//                 }
//             }
//             return output;
//         }

//         [MethodImpl(Inline), Op]
//         public static ReadOnlySpan<C> clear(ReadOnlySpan<C> src)
//         {
//             var output = src;
//             if(src.Length >= 2)
//             {
//                 ref readonly var c0 = ref skip(src,0);
//                 ref readonly var c1 = ref skip(src,1);
//                 if(c0 == C.d0 & c1 == C.x)
//                     output = slice(src,2);
//                 else
//                 {
//                     ref readonly var c = ref skip(src,src.Length-1);
//                     if(c == C.h)
//                         output = slice(src,0, src.Length - 1);
//                 }
//             }
//             return output;
//         }
//     }
// }