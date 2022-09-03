//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;
    using static LinqXPress;

    partial struct ModelsDynamic
    {
        public static class LtEq<T>
        {
            static readonly Option<Func<T,T,bool>> _OPSafe
                = TryConstruct();

            static Func<T,T,bool> _OP
                => _OPSafe.Require();

            static Option<Func<T,T,bool>> TryConstruct()
                => core.@try(() =>
                    {
                        switch (sys.typecode<T>())
                        {
                            case TypeCode.Byte:
                                return cast<Func<T,T,bool>>(Ops8u.LtEq.Compile());
                            case TypeCode.SByte:
                                return cast<Func<T,T,bool>>(Ops8i.LtEq.Compile());
                            case TypeCode.UInt16:
                                return cast<Func<T,T,bool>>(Ops16u.LtEq.Compile());
                            default:
                                return lambda<T,T,bool>(Expression.LessThanOrEqual).Compile();
                        }
                    });

            /// <summary>
            /// Specifies whether the operator exists for <typeparamref name="T"/>
            /// </summary>
            public static bool Exists
                => _OPSafe.IsSome();

            public static bool Apply(T x, T y)
                => _OP(x, y);

            public static MethodInfo Method
            {
                [MethodImpl(Inline)]
                get => _OP.Method;
            }
        }
    }
}