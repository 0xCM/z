//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    partial class Dynop
    {
        /// <summary>
        /// Loads executable source into an identified buffer and creates a fixed unary function over the buffer
        /// </summary>
        /// <param name="dst">The target buffer</param>
        /// <param name="src">The executable source</param>
        public static Func<X0,R> EmitCellFunc<X0,R>(this BufferToken dst, ApiCodeBlock src)
            => (Func<X0,R>)dst.Handle.EmitCellular(src.Id, typeof(Func<X0,R>), typeof(R), typeof(X0));

        /// <summary>
        /// Loads executable source into an identified buffer and creates a fixed binary function over the buffer
        /// </summary>
        /// <param name="dst">The target buffer</param>
        /// <param name="src">The executable source</param>
        public static Func<X0,X1,R> EmitCellFunc<X0,X1,R>(this BufferToken dst, ApiCodeBlock src)
            => (Func<X0,X1,R>)dst.Handle.EmitCellular(src.Id, typeof(Func<X0,X1,R>), typeof(R), typeof(X0), typeof(X1));

        /// <summary>
        /// Loads executable source into an identified buffer and creates a fixed binary function over the buffer
        /// </summary>
        /// <param name="dst">The target buffer</param>
        /// <param name="src">The executable source</param>
        public static Func<X0,X1,X2,R> EmitCellFunc<X0,X1,X2,R>(this BufferToken dst, ApiCodeBlock src)
            => (Func<X0,X1,X2,R>)dst.Handle.EmitCellular(src.Id, typeof(Func<X0,X1,X2,R>), typeof(R), typeof(X0), typeof(X1), typeof(X2));
    }
}