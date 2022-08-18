//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Reflection;

    public readonly struct CaseMethods
    {
        public static uint Emitter()
            => 17;

        public static uint Square(uint x)
            => x*x;

        public static uint BinaryAdd(uint x, uint y)
            => x + y;

        public static uint TernaryAdd(uint x, uint y, uint z)
            => x + y + z;

        public static MethodInfo Emitter_Method
            => typeof(CaseMethods).Method(nameof(Emitter));

        public static MethodInfo Square_Method
            => typeof(CaseMethods).Method(nameof(Square));

        public static MethodInfo BinaryAdd_Method
            => typeof(CaseMethods).Method(nameof(BinaryAdd));

        public static MethodInfo TernaryAdd_Method
            => typeof(CaseMethods).Method(nameof(TernaryAdd));
    }
}