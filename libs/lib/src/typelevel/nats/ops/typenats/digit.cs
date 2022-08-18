//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class TypeNats
    {
        /// <summary>
        /// Defines a digit relative to a natural base
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The digit's enumeration type</typeparam>
        /// <typeparam name="N">The natural base type</typeparam>
        [MethodImpl(Inline)]
        public static Digit<N,T> digit<N,T>(T src, N @base = default)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new Digit<N,T>(src);
    }
}