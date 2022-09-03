//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;

    using static Root;

    using LX = System.Linq.Expressions.Expression;
    using PX = System.Linq.Expressions.ParameterExpression;

    partial class LinqXPress
    {
        /// <summary>
        /// Creates a parameter expression
        /// </summary>
        /// <typeparam name="X">The parameter type</typeparam>
        /// <param name="name">The parameter name</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static PX paramX<X>(string name = "x1")
            => LX.Parameter(typeof(X), name);

        /// <summary>
        /// Creates a parameter expression array of length 2
        /// </summary>
        /// <typeparam name="X1">The first parameter type</typeparam>
        /// <typeparam name="X2">The second parameter type</typeparam>
        [MethodImpl(Inline)]
        public static PX[] paramX<X1,X2>()
            => sys.array(paramX<X1>("x1"), paramX<X2>("x2"));

        /// <summary>
        /// Creates a parameter expression array of length 3
        /// </summary>
        /// <typeparam name="X1">The first parameter type</typeparam>
        /// <typeparam name="X2">The second parameter type</typeparam>
        /// <typeparam name="X3">The third parameter type</typeparam>
        [MethodImpl(Inline)]
        public static PX[] paramX<X1,X2,X3>()
            => sys.array(paramX<X1>("x1"), paramX<X2>("x2"), paramX<X3>("x3"));

        /// <summary>
        /// Creates a parameter expression array of length 4
        /// </summary>
        /// <typeparam name="X1">The first parameter type</typeparam>
        /// <typeparam name="X2">The second parameter type</typeparam>
        /// <typeparam name="X3">The third parameter type</typeparam>
        [MethodImpl(Inline)]
        public static PX[] paramX<X1,X2,X3,X4>()
            => sys.array(paramX<X1>("x1"), paramX<X2>("x2"), paramX<X3>("x3"), paramX<X4>("x4"));

        /// <summary>
        /// Creates a parameter expression where the parameter name is predicated on an integer value
        /// </summary>
        /// <param name="i">The paremeter index</param>
        /// <typeparam name="X">The parameter type</typeparam>
        [MethodImpl(Inline)]
        public static PX paramX<X>(int i)
            => LX.Parameter(typeof(X), "x" + i.ToString());

        /// <summary>
        /// Creates a parameter expression
        /// </summary>
        /// <param name="t">The parameter type</param>
        /// <param name="name">The parameter name</param>
        [MethodImpl(Inline)]
        public static PX paramX(Type t, string name = "x1")
            => Expression.Parameter(t, name);

        /// <summary>
        /// Creates a parameter expression from a reflected parameter
        /// </summary>
        /// <param name="p">The reflected parameter</param>
        [MethodImpl(Inline), Op]
        public static PX paramX(ParameterInfo p)
            => Expression.Parameter(p.ParameterType, p.Name);

        /// <summary>
        /// Creates a parameter expression where the parameter name is predicated on an integer value
        /// </summary>
        /// <param name="i">The paremeter index</param>
        [MethodImpl(Inline), Op]
        public static PX paramX(Type paramType, int i)
            => Expression.Parameter(paramType, "x" + i.ToString());

        /// <summary>
        /// Creates a parameter expression 2-tuple
        /// </summary>
        /// <typeparam name="X1">The type of the first parameter</typeparam>
        /// <typeparam name="X2">The type of the second parameter</typeparam>
        [MethodImpl(Inline)]
        public static (PX x1, PX x2) paramXPair<X1,X2>()
            => (paramX<X1>("x1"), paramX<X2>("x2"));

        /// <summary>
        /// Creates a parameter expression 3-tuple
        /// </summary>
        /// <typeparam name="X1">The type of the first parameter</typeparam>
        /// <typeparam name="X2">The type of the second parameter</typeparam>
        /// <typeparam name="X3">The type of the third parameter</typeparam>
        [MethodImpl(Inline)]
        public static (PX x1, PX x2, PX x3) paramXTriple<X1,X2,X3>()
            => (paramX<X1>("x1"), paramX<X2>("x2"), paramX<X3>("x3"));

        /// <summary>
        /// Creates an auto-named parameter expression array from an array of parameter types
        /// </summary>
        /// <param name="paramTypes">The parameter types</param>
        public static PX[] @params(params Type[] paramTypes)
            => Enumerable.Range(0, paramTypes.Length)
                    .Select(i => LX.Parameter(paramTypes[i], "x" + (i + 1).ToString()))
                    .ToArray();
    }
}