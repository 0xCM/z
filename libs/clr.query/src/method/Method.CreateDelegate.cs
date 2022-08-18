//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    using System.Linq.Expressions;

    partial class ClrQuery
    {
        /// <summary>
        /// Creates a delegate for a static method via the expression api
        /// </summary>
        /// <typeparam name="D">The type of the constructed delegate</typeparam>
        /// <param name="m">The method that will be invoked when delegate is activated</param>
        public static D CreateDelegate<D>(this MethodInfo m)
            where D : Delegate
        {
            var argTypes = m.ParameterTypes().ToArray();
            var dType
                = m.IsAction()
                ? Expression.GetActionType(argTypes)
                : Expression.GetFuncType(argTypes.Concat(new Type[]{m.ReturnType}).ToArray());
            return (D)Delegate.CreateDelegate(typeof(D), null, m);
        }
    }
}