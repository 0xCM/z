//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;

    using static LinqXPress;

    public readonly struct TernaryOpFactory<T> : ITernaryOpFactory<T>
    {
        public static ITernaryOpFactory<T> Service => default(TernaryOpFactory<T>);

        public Func<T,T,T,T> Create(MethodInfo method, object instance = null)
        {
            var args = core.array(paramX<T,T,T>());
            var callExpr = call(instance, method, args);
            var f = lambda<T,T,T,T>(args, callExpr).Compile();
            return f;
        }
    }
}