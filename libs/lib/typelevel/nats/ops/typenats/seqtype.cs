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
        /// Computes the generic type definition for a natural sequence
        /// </summary>
        /// <param name="length">The sequence length</param>
        [MethodImpl(Inline)]
        public static Type seqtype(uint length)
        {
            if(length == 2)
                return typedef(typeof(NatSeq<,>));
            else if(length == 3)
                return typedef(typedef(typeof(NatSeq<,,>)));
            else if(length == 4)
                return typedef(typeof(NatSeq<,,,>));
            else if(length == 5)
                return typedef(typeof(NatSeq<,,,,>));
            else if(length == 6)
                return typedef(typeof(NatSeq<,,,,,>));
            else if(length == 7)
                return typedef(typeof(NatSeq<,,,,,,>));
            else if(length == 8)
                return typedef(typeof(NatSeq<,,,,,,,>));
            else if(length == 9)
                return typedef(typeof(NatSeq<,,,,,,,,>));
            else
                return typeof(NatSeq0<>);
        }

        [MethodImpl(Inline)]
        static Type typedef(Type t)
            => t.GetGenericTypeDefinition();
    }
}