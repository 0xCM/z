//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;

    using static Root;
    using static core;
    using static LinqXPress;
    using static LinqXFunc;

    partial struct ModelsDynamic
    {
        public static class Mul<T>
        {
            static readonly Func<T,T,T> _OP
                = Construct();

            static Func<T,T,T> Construct()
            {
                switch (sys.typecode<T>())
                {
                    case TypeCode.String:
                        return fx(LinqDynamic.method<T,T,T>("Concat").Require().Func<T,T,T>()).Compile();
                    case TypeCode.Byte:
                        return cast<Func<T,T,T>>(Ops8u.Mul.Compile());
                    case TypeCode.SByte:
                        return cast<Func<T,T,T>>(Ops8i.Mul.Compile());
                    case TypeCode.UInt16:
                        return cast<Func<T,T,T>>(ModelsDynamic.mul16u().Compile());
                    default:
                        return lambda<T,T,T>(Expression.Multiply).Compile();
                }
            }

            public static T Apply(T x, T y)
                => _OP(x, y);

            public static MethodInfo Method => _OP.Method;
        }

        public static class MultiplyChecked<T>
        {
            static readonly Func<T,T,T> _OP
                = lambda<T,T,T>(Expression.MultiplyChecked).Compile();

            public static T Apply(T x, T y)
                => _OP(x, y);

            public static MethodInfo Method => _OP.Method;
        }
    }
}