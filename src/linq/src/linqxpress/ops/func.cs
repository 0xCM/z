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
    using static core;

    using LX = System.Linq.Expressions.Expression;
    using PX = System.Linq.Expressions.ParameterExpression;

    public partial class LinqXPress
    {
        /// <summary>
        /// Creates an expression from an emitter
        /// </summary>
        /// <typeparam name="T">The emission type</typeparam>
        /// <param name="f">The emitter</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Expression<Func<T>> func<T>(Func<T> f)
            => fmake(f);

        /// <summary>
        /// Creates an expression from a function delegate of arity 1
        /// </summary>
        /// <typeparam name="X">The function operand type</typeparam>
        /// <typeparam name="Y">The function return type</typeparam>
        /// <param name="f">The source delegate</param>
        public static Expression<Func<X,Y>> func<X,Y>(Func<X,Y> f)
            => fmake(f);

        /// <summary>
        /// Creates an expression from a function delegate of arity 2
        /// </summary>
        /// <typeparam name="X1">The type of the first operand</typeparam>
        /// <typeparam name="X2">The type of the second operand</typeparam>
        /// <typeparam name="Y">The function return type</typeparam>
        /// <param name="f">The source delegate</param>
        public static Expression<Func<X1,X2,Y>> func<X1,X2,Y>(Func<X1,X2,Y> f)
            => fmake(f);

        /// <summary>
        /// Creates an expression from a function delegate of arity 3
        /// </summary>
        /// <typeparam name="X1">The type of the first operand</typeparam>
        /// <typeparam name="X2">The type of the second operand</typeparam>
        /// <typeparam name="X3">The type of the third operand</typeparam>
        /// <typeparam name="Y">The function return type</typeparam>
        /// <param name="f">The source delegate</param>
        public static Expression<Func<X1,X2,X3,Y>> func<X1,X2,X3,Y>(Func<X1,X2,X3,Y> f)
            => fmake(f);

        /// <summary>
        /// Creates and caches a delegate for a method realizing an emitter
        /// </summary>
        /// <typeparam name="X">The emission type</typeparam>
        /// <param name="m">The source method</param>
        /// <param name="host">An object instance for the method, if applicable</param>
        public static Option<Func<X>> func<X>(MethodInfo m, object host = null)
            => Option.Try(() => (Func<X>)_cache.GetOrAdd(m, method =>
            {
                var result = convert<X>(call(host, m));
                return LX.Lambda<Func<X>>(result).Compile();
            }));

        /// <summary>
        /// Creates and caches a delegate for a method realizing a function f:X->Y
        /// </summary>
        /// <typeparam name="X">The operand type</typeparam>
        /// <typeparam name="Y">The return type</typeparam>
        /// <param name="m">The source method</param>
        /// <param name="host">An object instance for the method, if applicable</param>
        public static Option<Func<X,Y>> func<X,Y>(MethodInfo m, object host = null)
            => Option.Try(() => (Func<X,Y>)_cache.GetOrAdd(m, method =>
            {
                var args = array(paramX<X>());
                var f = call(host, m, args);
                return lambda<X, Y>(args, f).Compile();
            }));

        /// <summary>
        /// Creates and caches a delegate for a method realizing a function f:X->Y
        /// </summary>
        /// <typeparam name="X">The operand type</typeparam>
        /// <typeparam name="Y">The return type</typeparam>
        /// <param name="declarer">The declaring type</param>
        /// <param name="name">The name of the method</param>
        /// <param name="host">An object instance for the method, if applicable</param>
        public static Option<Func<X,Y>> func<X,Y>(Type declarer, string name, object host = null)
            => from m in declarer.MatchMethod(name, typeof(X))
                from f in func<X, Y>(m, host)
                select f;

        /// <summary>
        /// Creates a weakly-typed delegate for a function f:X->Y
        /// </summary>
        /// <param name="m">The source method</param>
        /// <param name="host">The instance of the declaring type, if method is not static</param>
        public static Func<object, object> func1(MethodInfo method, object host = null)
        {
            var paramInfo = method.GetParameters().Single();
            var typeDef = typeof(Func<,>).GetGenericTypeDefinition();
            var type = typeDef.MakeGenericType(array(paramInfo.ParameterType, method.ReturnType));
            var args = paramX(paramInfo.ParameterType, paramInfo.Name);
            var call = Expression.Call(core.coalesce(host, x => constant(x)), method, args);
            var l = Expression.Lambda(type, call, args);
            var del = l.Compile();
            return x => del.DynamicInvoke(x);
        }

        /// <summary>
        /// Creates a weakly-typed delegate for a function f:X->Y
        /// </summary>
        /// <param name="m">The source method</param>
        /// <param name="host">The instance of the declaring type, if method is not static</param>
        public static Func<object, object, object> func2(MethodInfo method, object host = null)
        {
            var parameters = method.GetParameters().ToArray();
            if(parameters.Length != 1)
                throw new ArgumentException($"There are {parameters.Length} parameters in the source method instead of the 2 required");

            var types = new Type[]{parameters[0].ParameterType, parameters[1].ParameterType, method.ReturnType};
            var typeDef = typeof(Func<,,>).GetGenericTypeDefinition();
            var type = typeDef.MakeGenericType(types);
            var args = new PX[]{
                paramX(parameters[0].ParameterType, parameters[0].Name),
                paramX(parameters[1].ParameterType, parameters[1].Name)
                };

            var call = Expression.Call(core.coalesce(host, x => constant(x)), method, args);
            var l = Expression.Lambda(type, call, args);
            var del = l.Compile();
            return (x,y) => del.DynamicInvoke(x,y);
        }

        /// <summary>
        /// Creates and caches a function delegate for a method realizing a function f:(X1,X2) -> Y
        /// </summary>
        /// <typeparam name="X1">The first operand type</typeparam>
        /// <typeparam name="X2">The second operand type</typeparam>
        /// <typeparam name="Y">The return type</typeparam>
        /// <param name="m">The source method</param>
        /// <param name="host">The instance of the declaring type, if method is not static</param>
        public static Option<Func<X1,X2,Y>> func<X1,X2,Y>(MethodInfo m, object host = null)
            => Option.Try(() => (Func<X1,X2,Y>)_cache.GetOrAdd(m, method =>
            {
                var args = paramX<X1,X2>();
                var f = call(host, m, args.ToArray());
                return lambda<X1,X2,Y>(args, f).Compile();
            }));

        /// <summary>
        /// Creates and caches a function delegate for a method realizing a function f:X1->X2->X3->Y
        /// </summary>
        /// <typeparam name="X1">The first operand type</typeparam>
        /// <typeparam name="X2">The second operand type</typeparam>
        /// <typeparam name="X3">The third operand type</typeparam>
        /// <typeparam name="Y">The return type</typeparam>
        /// <param name="m">The source method</param>
        /// <param name="host">The instance of the declaring type, if method is not static</param>
        public static Func<X1,X2,X3,Y> func<X1,X2,X3,Y>(MethodInfo m, object host = null)
            => (Func<X1,X2,X3,Y>)_cache.GetOrAdd(m, method =>
            {
                var args = paramX<X1,X2,X3>();
                var f = call(host, m, args.ToArray());
                return lambda<X1,X2,X3,Y>(args, f).Compile();
            });

        /// <summary>
        /// Creates and caches a function delegate for a method realizing a function f:X1->X2->X3->X4->Y
        /// </summary>
        /// <typeparam name="X1">The first operand type</typeparam>
        /// <typeparam name="X2">The second operand type</typeparam>
        /// <typeparam name="X3">The third operand type</typeparam>
        /// <typeparam name="Y">The return type</typeparam>
        /// <param name="m">The source method</param>
        /// <param name="host">The instance of the declaring type, if method is not static</param>
        public static Func<X1,X2,X3,X4,Y> func<X1,X2,X3,X4,Y>(MethodInfo m, object host = null)
            => (Func<X1,X2,X3,X4,Y>)_cache.GetOrAdd(m, method =>
            {
                var args = paramX<X1,X2,X3,X4>();
                var f = call(host, m, args.ToArray());
                return lambda<X1,X2,X3,X4,Y>(args, f).Compile();
            });
    }
}