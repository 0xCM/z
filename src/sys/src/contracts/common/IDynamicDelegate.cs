//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Reflection.Emit;

    [Free]
    public interface IDynamicDelegate
    {
        /// <summary>
        /// The method invoked by the dynamic operator that provides the substance of the operation
        /// </summary>
        MethodInfo Source {get;}

        /// <summary>
        /// The dynamically-generated method that backs the dynamic operator
        /// </summary>
        DynamicMethod Target {get;}

        /// <summary>
        /// The dynamic operation
        /// </summary>
        Delegate Operation {get;}

        /// <summary>
        /// Invokes the dynamic delegate dynamically
        /// </summary>
        /// <param name="args">The arguments to pass to the delegate</param>
        object Invoke(params object[] args)
            => Operation.DynamicInvoke(args);
    }

    [Free]
    public interface IDynamicDelegate<D> : IDynamicDelegate
        where D : Delegate
    {
        /// <summary>
        /// The dynamic operation
        /// </summary>
        new D Operation {get;}

        Delegate IDynamicDelegate.Operation
            => Operation;
    }
}