//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct NaturalNumericClosure
    {
        public ulong? M {get;}

        public ulong N {get;}

        public NumericKind T {get;}

        public MethodInfo Definition {get;}

        [MethodImpl(Inline)]
        public NaturalNumericClosure(MethodInfo def, ulong? m, ulong n, NumericKind t)
        {
            Definition = def;
            M = m;
            N = n;
            T = t;
        }
    }
}