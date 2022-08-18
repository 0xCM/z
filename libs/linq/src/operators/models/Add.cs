//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    using static core;
    using static Z0.LinqXPress;
    using static Z0.LinqXFunc;

    partial struct ModelsDynamic
    {
        public static class Add<T>
        {
            static readonly Option<Func<T,T,T>> _OPSafe
                = TryConstruct();

            static Func<T,T,T> _OP
                => _OPSafe.Require();

            static Option<Func<T,T,T>> TryConstruct()
                => core.@try(() =>
                {
                    switch (sys.typecode<T>())
                    {

                        case TypeCode.String:
                            return fx(LinqDynamic.method<T,T,T>("Concat").Require().Func<T,T,T>()).Compile();
                        case TypeCode.Byte:
                            return cast<Func<T,T,T>>(Ops8u.Add.Compile());
                        case TypeCode.SByte:
                            return cast<Func<T,T,T>>(Ops8i.Add.Compile());
                        case TypeCode.Int16:
                            return cast<Func<T,T,T>>(Ops16i.Add.Compile());
                        case TypeCode.UInt16:
                            return cast<Func<T,T,T>>(Ops16u.Add.Compile());
                        default:
                            return lambda<T,T,T>(Expression.Add).Compile();
                    }
                });

            /// <summary>
            /// Specifies whether the operator exists for <typeparamref name="T"/>
            /// </summary>
            public static bool Exists
                => _OPSafe.IsSome();

            public static T Apply(T x, T y)
                => _OP(x, y);

            public static MethodInfo Method => _OP.Method;
        }

        public static class AddChecked<T>
        {
            static readonly Func<T,T,T> _OP
                = lambda<T,T,T>(Expression.AddChecked).Compile();

            public static T Apply(T x, T y)
                => _OP(x, y);
        }
    }
}