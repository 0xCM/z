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
        /// For a natural number n <= 9, returns the type of the corresponding natural primitive. If n > 9, returns the zero type
        /// </summary>
        /// <param name="n">The number to evaluate</param>
        [MethodImpl(Inline), Op]
        public static Type primtype(byte n)
        {
            if(n == 1)
                return typeof(N1);
            else if(n == 2)
                return typeof(N2);
            else if(n == 3)
                return typeof(N3);
            else if(n == 4)
                return typeof(N4);
            else if(n == 5)
                return typeof(N5);
            else if(n == 6)
                return typeof(N6);
            else if(n == 7)
                return typeof(N7);
            else if(n == 8)
                return typeof(N8);
            else if(n == 9)
                return typeof(N9);
            else
                return typeof(N0);
        }

        /// <summary>
        /// Constructs an array of types that defines a sequence of natural primitives
        /// </summary>
        /// <param name="digits">The digit values where each value is in the range 0..9</param>
        public static Type[] primtypes(byte[] digits)
        {
            var types = new Type[digits.Length];
            ref var tHead = ref types[0];
            ref var dHead = ref digits[0];
            for(var i=0; i< digits.Length; i++)
                Unsafe.Add(ref tHead, i) = primtype(Unsafe.Add(ref dHead, i));
            return types;
        }
    }
}