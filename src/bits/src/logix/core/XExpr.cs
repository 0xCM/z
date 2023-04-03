//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static class XExpr
    {
        /// <summary>
        /// Assigns a random value to a variable and returns that value to the caller
        /// </summary>
        /// <param name="v">The variable to set</param>
        /// <param name="source">The data source</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static T Set<T>(this ILogixVarExpr<T> v, IBoundSource source)
            where T : unmanaged
        {
            var x = source.Next<T>();
            v.Assign(x);
            return x;
        }

        /// <summary>
        /// Assigns a random value to a variable and returns that value to the caller
        /// </summary>
        /// <param name="v">The variable to set</param>
        /// <param name="source">The data source</param>
        /// <param name="min">The inclusive min value to assign</param>
        /// <param name="max">The exclusive max value to assign</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static T Set<T>(this ILogixVarExpr<T> v, IBoundSource source, T min, T max)
            where T : unmanaged
        {
            var x = source.Next<T>(min,max);
            v.Assign(x);
            return x;
        }

        [MethodImpl(Inline)]
        static ILogixVarExpr<T> Assign<T>(this ILogixVarExpr<T> v, ILogixExpr<T> value)
            where T : unmanaged
        {
            if(value != null)
                v.Set(value);
            return v;
        }

        [MethodImpl(Inline)]
        static ILogixVarExpr<T> Assign<T>(this ILogixVarExpr<T> v, T value)
            where T : unmanaged
        {
            v.Set(value);
            return v;
        }

        /// <summary>
        /// Returns the source expression variable at index 0
        /// </summary>
        /// <param name="src">The source expression</param>
        /// <param name="value">The value, if any, to assign the variable</param>
        /// <typeparam name="T">The type over which the expression is defined</typeparam>
        [MethodImpl(Inline)]
        public static ILogixVarExpr<T> Var0<T>(this VariedExpr<N1,T> src)
            where T : unmanaged
                => src.Vars[0];

        /// <summary>
        /// Returns the source expression variable at index 0, optionally assigned to supplied value
        /// </summary>
        /// <param name="src">The source expression</param>
        /// <param name="value">The value, if any, to assign the variable</param>
        /// <typeparam name="T">The type over which the expression is defined</typeparam>
        [MethodImpl(Inline)]
        public static ILogixVarExpr<T> Var0<T>(this VariedExpr<N1,T> src, ILogixExpr<T> value)
            where T : unmanaged
                => src.Var0().Assign(value);

        /// <summary>
        /// Returns the source expression variable at index 0, optionally assigned to supplied value
        /// </summary>
        /// <param name="src">The source expression</param>
        /// <param name="value">The value, if any, to assign the variable</param>
        /// <typeparam name="T">The type over which the expression is defined</typeparam>
        [MethodImpl(Inline)]
        public static ILogixVarExpr<T> Var0<T>(this VariedExpr<N1,T> src, T value)
            where T : unmanaged
                => src.Var0().Assign(value);

        /// <summary>
        /// Returns the source expression variable at index 0
        /// </summary>
        /// <param name="src">The source expression</param>
        /// <param name="value">The value, if any, to assign the variable</param>
        /// <typeparam name="T">The type over which the expression is defined</typeparam>
        [MethodImpl(Inline)]
        public static ILogixVarExpr<T> Var0<T>(this VariedExpr<N2,T> src)
            where T : unmanaged
                => src.Vars[0];

        /// <summary>
        /// Returns the source expression variable at index 0, optionally assigned to supplied value
        /// </summary>
        /// <param name="src">The source expression</param>
        /// <param name="value">The value, if any, to assign the variable</param>
        /// <typeparam name="T">The type over which the expression is defined</typeparam>
        [MethodImpl(Inline)]
        public static ILogixVarExpr<T> Var0<T>(this VariedExpr<N2,T> src, ILogixExpr<T> value)
            where T : unmanaged
                => src.Var0().Assign(value);

        /// <summary>
        /// Returns the source expression variable at index 0, optionally assigned to supplied value
        /// </summary>
        /// <param name="src">The source expression</param>
        /// <param name="value">The value, if any, to assign the variable</param>
        /// <typeparam name="T">The type over which the expression is defined</typeparam>
        [MethodImpl(Inline)]
        public static ILogixVarExpr<T> Var0<T>(this VariedExpr<N2,T> src, T value)
            where T : unmanaged
                => src.Var0().Assign(value);

        /// <summary>
        /// Returns the source expression variable at index 1
        /// </summary>
        /// <param name="src">The source expression</param>
        /// <param name="value">The value, if any, to assign the variable</param>
        /// <typeparam name="T">The type over which the expression is defined</typeparam>
        [MethodImpl(Inline)]
        public static ILogixVarExpr<T> Var1<T>(this VariedExpr<N2,T> src)
            where T : unmanaged
                => src.Vars[1];

        /// <summary>
        /// Returns the source expression variable at index 1, optionally assigned to supplied value
        /// </summary>
        /// <param name="src">The source expression</param>
        /// <param name="value">The value, if any, to assign the variable</param>
        /// <typeparam name="T">The type over which the expression is defined</typeparam>
        [MethodImpl(Inline)]
        public static ILogixVarExpr<T> Var1<T>(this VariedExpr<N2,T> src, ILogixExpr<T> value)
            where T : unmanaged
                => src.Var1().Assign(value);

        /// <summary>
        /// Returns the source expression variable at index 1, optionally assigned to supplied value
        /// </summary>
        /// <param name="src">The source expression</param>
        /// <param name="value">The value, if any, to assign the variable</param>
        /// <typeparam name="T">The type over which the expression is defined</typeparam>
        [MethodImpl(Inline)]
        public static ILogixVarExpr<T> Var1<T>(this VariedExpr<N2,T> src, T value)
            where T : unmanaged
                => src.Var1().Assign(value);

        /// <summary>
        /// Returns the source expression variable at index 0
        /// </summary>
        /// <param name="src">The source expression</param>
        /// <param name="value">The value, if any, to assign the variable</param>
        /// <typeparam name="T">The type over which the expression is defined</typeparam>
        [MethodImpl(Inline)]
        public static ILogixVarExpr<T> Var0<T>(this VariedExpr<N3,T> src)
            where T : unmanaged
                => src.Vars[0];

        /// <summary>
        /// Returns the source expression variable at index 0, optionally assigned to supplied value
        /// </summary>
        /// <param name="src">The source expression</param>
        /// <param name="value">The value, if any, to assign the variable</param>
        /// <typeparam name="T">The type over which the expression is defined</typeparam>
        [MethodImpl(Inline)]
        public static ILogixVarExpr<T> Var0<T>(this VariedExpr<N3,T> src, ILogixExpr<T> value)
            where T : unmanaged
                => src.Var0().Assign(value);

        /// <summary>
        /// Returns the source expression variable at index 0, optionally assigned to supplied value
        /// </summary>
        /// <param name="src">The source expression</param>
        /// <param name="value">The value, if any, to assign the variable</param>
        /// <typeparam name="T">The type over which the expression is defined</typeparam>
        [MethodImpl(Inline)]
        public static ILogixVarExpr<T> Var0<T>(this VariedExpr<N3,T> src, T value)
            where T : unmanaged
                => src.Var0().Assign(value);

        /// <summary>
        /// Returns the source expression variable at index 1
        /// </summary>
        /// <param name="src">The source expression</param>
        /// <param name="value">The value, if any, to assign the variable</param>
        /// <typeparam name="T">The type over which the expression is defined</typeparam>
        [MethodImpl(Inline)]
        public static ILogixVarExpr<T> Var1<T>(this VariedExpr<N3,T> src)
            where T : unmanaged
                => src.Vars[1];

        /// <summary>
        /// Returns the source expression variable at index 1, optionally assigned to supplied value
        /// </summary>
        /// <param name="src">The source expression</param>
        /// <param name="value">The value, if any, to assign the variable</param>
        /// <typeparam name="T">The type over which the expression is defined</typeparam>
        [MethodImpl(Inline)]
        public static ILogixVarExpr<T> Var1<T>(this VariedExpr<N3,T> src, ILogixExpr<T> value)
            where T : unmanaged
                => src.Var1().Assign(value);

        /// <summary>
        /// Returns the source expression variable at index 1, optionally assigned to supplied value
        /// </summary>
        /// <param name="src">The source expression</param>
        /// <param name="value">The value, if any, to assign the variable</param>
        /// <typeparam name="T">The type over which the expression is defined</typeparam>
        [MethodImpl(Inline)]
        public static ILogixVarExpr<T> Var1<T>(this VariedExpr<N3,T> src, T value)
            where T : unmanaged
                => src.Var1().Assign(value);

        /// <summary>
        /// Returns the source expression variable at index 2
        /// </summary>
        /// <param name="src">The source expression</param>
        /// <param name="value">The value, if any, to assign the variable</param>
        /// <typeparam name="T">The type over which the expression is defined</typeparam>
        [MethodImpl(Inline)]
        public static ILogixVarExpr<T> Var2<T>(this VariedExpr<N3,T> src)
            where T : unmanaged
                => src.Vars[2];

        /// <summary>
        /// Returns the source expression variable at index 2, optionally assigned to supplied value
        /// </summary>
        /// <param name="src">The source expression</param>
        /// <param name="value">The value, if any, to assign the variable</param>
        /// <typeparam name="T">The type over which the expression is defined</typeparam>
        [MethodImpl(Inline)]
        public static ILogixVarExpr<T> Var2<T>(this VariedExpr<N3,T> src, ILogixExpr<T> value)
            where T : unmanaged
                => src.Var2().Assign(value);

        /// <summary>
        /// Returns the source expression variable at index 2, optionally assigned to supplied value
        /// </summary>
        /// <param name="src">The source expression</param>
        /// <param name="value">The value, if any, to assign the variable</param>
        /// <typeparam name="T">The type over which the expression is defined</typeparam>
        [MethodImpl(Inline)]
        public static ILogixVarExpr<T> Var2<T>(this VariedExpr<N3,T> src, T value)
            where T : unmanaged
                => src.Var2().Assign(value);

        /// <summary>
        /// Obtains the next primal value from the random source, assigns the
        /// variable to this value and returns the value to the caller
        /// </summary>
        /// <param name="random"></param>
        /// <param name="current"></param>
        /// <typeparam name="T">The primal value over which the variable is defined</typeparam>
        [MethodImpl(Inline)]
        public static T SetNext<T>(this IBoundSource random, VariableExpr<T> current)
            where T : unmanaged
        {
            var a = random.Next<T>();
            current.Set(a);
            return a;
        }
    }
}