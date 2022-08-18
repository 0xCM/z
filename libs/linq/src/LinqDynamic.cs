//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Linq.Expressions;
    using System.Reflection;

    using static Root;
    using static LinqXPress;
    using static ModelsDynamic;

    [ApiHost]
    public readonly struct LinqDynamic
    {
        /// <summary>
        /// Searches a type for any method that matches the supplied signature
        /// </summary>
        /// <param name="name">The name of the method</param>
        /// <typeparam name="T">The type to search</typeparam>
        /// <typeparam name="A1">The first argument type</typeparam>
        /// <typeparam name="A2">The second argument type</typeparam>
        internal static Option<MethodInfo> method<T,X,R>(string name)
            => typeof(T).MatchMethod(name, typeof(X), typeof(R));

        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Negate<T> negate<T>()
            where T : unmanaged
                => new Negate<T>(lambda<T,T>(Expression.Negate).Compile());

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static And<T> and<T>()
            where T : unmanaged
                => new And<T>(lambda<T,T,T>(Expression.And).Compile());

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Xor<T> xor<T>()
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return new Xor<T>(Delegates.generic<T>(Ops8u.Xor));
            else if(typeof(T) == typeof(ushort))
                return new Xor<T>(Delegates.generic<T>(Ops16u.Xor.Compile()));
            else if(typeof(T) == typeof(uint))
                return new Xor<T>(Delegates.generic<T>(Ops32u.Xor));
            else if(typeof(T) == typeof(ulong))
                return new Xor<T>(Delegates.generic<T>(Ops64u.Xor));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static GtEq<T> gteq<T>()
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return new GtEq<T>(Delegates.generic<T>(Ops8u.GtEq.Compile()));
            else if(typeof(T) == typeof(ushort))
                return new GtEq<T>(Delegates.generic<T>(Ops16u.GtEq.Compile()));
            else if(typeof(T) == typeof(uint))
                return new GtEq<T>(Delegates.generic<T>(Ops32u.GtEq.Compile()));
            else if(typeof(T) == typeof(ulong))
                return new GtEq<T>(Delegates.generic<T>(Ops64u.GtEq.Compile()));
            else
                return new GtEq<T>(lambda<T,T,bool>(Expression.GreaterThanOrEqual).Compile());
        }
    }
}