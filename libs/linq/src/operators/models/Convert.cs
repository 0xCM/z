//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    using System;

    using static Z0.LinqXFunc;

    partial struct ModelsDynamic
    {
        public static class Convert<X,Y>
        {
            static Y Cast(X value)
                => (Y)(object)value;

            static XFunc<X,Y> Converter()
                => f((X x) => (Y)Convert.ChangeType(x,typeof(Y)));

            static readonly Func<X,Y> _OP
                = Converter().Fx.Compile();

            public static Y Apply(X x)
                => _OP(x);
        }
    }
}