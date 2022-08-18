//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct NaturalNumericClosure<T>
        where T : unmanaged
    {
        public ulong? M {get;}

        public ulong N {get;}

        public MethodInfo Definition {get;}

        [MethodImpl(Inline)]
        public NaturalNumericClosure(MethodInfo def, ulong? m, ulong n)
        {
            Definition = def;
            M = m;
            N = n;
        }

        public NaturalNumericClosure Untyped
            => new NaturalNumericClosure(Definition, M, N, typeof(T).NumericKind());
    }
}