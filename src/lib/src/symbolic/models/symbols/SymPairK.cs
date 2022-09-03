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

    public readonly struct SymPair<K>
        where K : unmanaged
    {
        public Sym<K> Left {get;}

        public Sym<K> Right {get;}

        [MethodImpl(Inline)]
        public SymPair(Sym<K> left, Sym<K> right)
        {
            Left = left;
            Right = right;
        }

        [MethodImpl(Inline)]
        public static implicit operator SymPair<K>((Sym<K> left, Sym<K> right) src)
            => new SymPair<K>(src.left, src.right);

        [MethodImpl(Inline)]
        public static implicit operator SymPair<K>(Pair<Sym<K>> src)
            => new SymPair<K>(src.Left, src.Right);

        [MethodImpl(Inline)]
        public static implicit operator Pair<Sym<K>>(SymPair<K> src)
            => pair(src.Left, src.Right);
    }
}