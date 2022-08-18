//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Captures a <see cref='IIsomorhphic'/> relationship between two types
    /// </summary>
    public readonly struct Isomorphic : IIsomorhphic
    {
        public PairedTypes Pair {get;}

        [MethodImpl(Inline)]
        public Isomorphic(Type a, Type b)
        {
            Pair = (a,b);
        }

        [MethodImpl(Inline)]
        public string Format()
            => string.Format("{0} <-> {1}", Pair.TypeA.Name, Pair.TypeB.Name);


        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Isomorphic((Type src, Type dst) x)
            => new Isomorphic(x.src, x.dst);
    }
}