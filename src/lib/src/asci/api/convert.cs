// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     using static sys;

//     using C = AsciCode;

//     partial struct Asci
//     {
//         [MethodImpl(Inline), Op]
//         public static uint convert(ReadOnlySpan<C> src, Span<char> dst)
//         {
//             var count = (uint)min(src.Length, dst.Length);
//             for(var i=0; i<count; i++)
//                 seek(dst,i) = (char)skip(src,i);
//             return count;
//         }

//         [MethodImpl(Inline), Op]
//         public static uint convert(ReadOnlySpan<byte> src, Span<char> dst)
//         {
//             var count = (uint)min(src.Length, dst.Length);
//             for(var i=0; i<count; i++)
//                 seek(dst,i) = (char)skip(src,i);
//             return count;
//         }

//         [MethodImpl(Inline), Op]
//         public static uint convert(ReadOnlySpan<char> src, Span<C> dst)
//         {
//             var count = (uint)min(src.Length, dst.Length);
//             for(var i=0; i<count; i++)
//                 seek(dst,i) = (C)skip(src,i);
//             return count;
//         }

//         [MethodImpl(Inline), Op]
//         public static uint convert(ReadOnlySpan<char> src, Span<byte> dst)
//         {
//             var count = (uint)min(src.Length, dst.Length);
//             for(var i=0; i<count; i++)
//                 seek(dst,i) = (byte)skip(src,i);
//             return count;
//         }
//     }
// }