//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class gbits
    {
        // /// <summary>
        // /// Creates a mask that covers an inclusive range of bits
        // /// </summary>
        // /// <param name="i0">The position of the first bit</param>
        // /// <param name="i1">The position of the last bit</param>
        // /// <typeparam name="T">The target data type</typeparam>
        // [MethodImpl(Inline), Op, Closures(AllNumeric)]
        // public static T ones<T>(byte i0, byte i1)
        // {
        //     if(size<T>() == 1)
        //         return generic<T>(bits.ones(w8, i0, i1));
        //     else if(size<T>() == 2)
        //         return generic<T>(bits.ones(w16, i0, i1));
        //     else if(size<T>() == 4)
        //         return generic<T>(bits.ones(w32, i0, i1));
        //     else if(size<T>() == 8)
        //         return generic<T>(bits.ones(w64, i0, i1));
        //     else
        //         throw no<T>();
        // }
    }
}