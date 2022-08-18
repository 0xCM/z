//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Collections.Concurrent;

    using static Root;
    using static ReflectionFlags;

    partial class LinqXPress
    {
        /// <summary>
        /// Searches a type for an instance constructor that matches a specified signature
        /// </summary>
        /// <param name="declaringType">The type to search</param>
        /// <param name="argTypes">The method parameter types in ordinal position</param>
        [MethodImpl(Inline), Op]
        static Option<ConstructorInfo> ctor(Type declaringType, params Type[] argTypes)
            => declaringType.GetConstructor(BF_Instance, null, argTypes, new ParameterModifier[]{});

        /// <summary>
        /// Searches a type for an instance constructor that matches a specified signature
        /// </summary>
        /// <param name="args">The method parameter types in ordinal position</param>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        static Option<ConstructorInfo> ctor<T>(params Type[] args)
            => ctor(typeof(T), args);

        /// <summary>
        /// Searches a type for an instance constructor that matches a parametrically-specified signature
        /// </summary>
        /// <param name="args">The method parameter types in ordinal position</param>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline)]
        static Option<ConstructorInfo> ctor<X1,T>()
            => ctor(typeof(T), typeof(X1));

        /// <summary>
        /// Searches a type for an instance constructor that matches a parametrically-specified signature
        /// </summary>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline)]
        static Option<ConstructorInfo> ctor<X1,X2,T>()
            => ctor(typeof(T), typeof(X1), typeof(X2));

        /// <summary>
        /// Defines a function expression for an emitter
        /// </summary>
        /// <typeparam name="X">The emission type</typeparam>
        /// <param name="f">The emitter</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        static XFunc<X> fmake<X>(Func<X> f)
            => f;

        /// <summary>
        /// Defines a function expression for a heterogenous function of arity 1
        /// </summary>
        /// <typeparam name="X">The function argument type</typeparam>
        /// <typeparam name="Y">The return type</typeparam>
        /// <param name="f">The source function</param>
        [MethodImpl(Inline)]
        static XFunc<X,Y> fmake<X,Y>(Func<X,Y> f)
            => f;

        /// <summary>
        /// Defines a function expression for a heterogenous function of arity 2
        /// </summary>
        /// <typeparam name="X1">The type of the first argument</typeparam>
        /// <typeparam name="X2">The type of the second argument</typeparam>
        /// <typeparam name="Y">The return type</typeparam>
        /// <param name="f">The source function</param>
        [MethodImpl(Inline)]
        static XFunc<X1,X2,Y> fmake<X1,X2,Y>(Func<X1,X2,Y> f)
            => f;

        /// <summary>
        /// Produces a 3-argument func expression
        /// </summary>
        /// <typeparam name="X1">The type of the first argument</typeparam>
        /// <typeparam name="X2">The type of the second argument</typeparam>
        /// <typeparam name="X3">The type of the third argument</typeparam>
        /// <typeparam name="Y">The return type</typeparam>
        /// <param name="f">The source function</param>
        [MethodImpl(Inline)]
        static XFunc<X1,X2,X3,Y> fmake<X1,X2,X3,Y>(Func<X1,X2,X3,Y> f)
            => f;

        static ConcurrentDictionary<MethodInfo, Delegate> _cache { get; }
            = new ConcurrentDictionary<MethodInfo, Delegate>();
    }
}