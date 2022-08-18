//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct Dim2<T> : IDim2<T>
        where T : unmanaged
    {
        public T I {get;}

        public T J {get;}

        [MethodImpl(Inline)]
        public Dim2(T m, T n)
        {
            I = m;
            J = n;
        }

        public string Format()
            => $"{I}×{J}";

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Dim2<T>((T m, T n) src)
            => new Dim2<T>(src.m, src.n);
    }
}