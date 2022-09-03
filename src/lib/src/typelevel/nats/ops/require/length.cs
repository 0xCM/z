//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    using static Root;
    using static TypeNats;

    partial class NatRequire
    {
        /// <summary>
        /// Attempts to prove that the k:K => src.length = k
        /// Registers success by returning src
        /// Registers failure by raising an error
        /// </summary>
        /// <param name="src">The source array</param>
        /// <typeparam name="K">The natural type</typeparam>
        /// <typeparam name="T">The list element type</typeparam>
        [MethodImpl(Inline)]
        public static IReadOnlyList<T> length<K,T>(IReadOnlyList<T> src)
            where K : unmanaged, ITypeNat
                => value<K>() == (ulong)src.Count ? src : failure<K,IReadOnlyList<T>>(LengthName, src);

        /// <summary>
        /// Attempts to prove that the k:K => src.length = k
        /// Registers success by returning src
        /// Registers failure by raising an error
        /// </summary>
        /// <param name="src">The source array</param>
        /// <typeparam name="K">The natural type</typeparam>
        /// <typeparam name="T">The list element type</typeparam>
        [MethodImpl(Inline)]
        public static IReadOnlyList<T> length<K,T>(K k, IReadOnlyList<T> src)
            where K : unmanaged, ITypeNat
                => k.NatValue == (ulong)src.Count ? src : failure<K,IReadOnlyList<T>>(LengthName, src);

        /// <summary>
        /// Attempts to prove that the k:K => src.length = k
        /// Registers success by returning src
        /// Registers failure by raising an error
        /// </summary>
        /// <param name="src">The source array</param>
        /// <typeparam name="K">The natural type</typeparam>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline)]
        public static T[] length<K,T>(K k, params T[] src)
            where K : unmanaged, ITypeNat
                => k.NatValue == (ulong)src.Length ? src : failure<K,T[]>(LengthName, src);

        /// <summary>
        /// Attempts to prove that the k:K => src.length = k
        /// Registers success by returning src
        /// Registers failure by raising an error
        /// </summary>
        /// <param name="src">The source array</param>
        /// <typeparam name="K">The natural type</typeparam>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline)]
        public static T[] length<K,T>(params T[] src)
            where K : unmanaged, ITypeNat
                => value<K>() == (ulong)src.Length ? src : failure<K,T[]>(LengthName, src);


        const string LengthName = "length";
    }

}