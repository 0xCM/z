//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct PairedTypes
    {
        [MethodImpl(Inline)]
        public static PairedTypes define(Type a, Type b)
            => new PairedTypes(a,b);

        [MethodImpl(Inline)]
        public static PairedTypes define<A,B>()
            => new PairedTypes(typeof(A), typeof(B));

        public Type TypeA {get;}

        public Type TypeB {get;}

        [MethodImpl(Inline)]
        public PairedTypes(Type a, Type b)
        {
            TypeA = a;
            TypeB = b;
        }

        public string Format()
            => string.Format("{0}, {1}", TypeA.Name, TypeB.Name);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator PairedTypes((Type a, Type b) src)
            => new PairedTypes(src.a, src.b);
    }
}