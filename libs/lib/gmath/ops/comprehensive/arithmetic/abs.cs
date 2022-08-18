//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial class gmath
    {
        /// <summary>
        /// Computes the absolute value of a primal operand
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Abs, Closures(SignedInts | Floats)]
        public static T abs<T>(T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(math.abs(int8(src)));
            else if(typeof(T) == typeof(short))
                return generic<T>(math.abs(int16(src)));
            else if(typeof(T) == typeof(int))
                return generic<T>(math.abs(int32(src)));
            else if(typeof(T) == typeof(long))
                return generic<T>(math.abs(int64(src)));
            else if(NumericKinds.unsigned<T>())
                return src;
            else
                return gfp.abs(src);
        }
   }
}