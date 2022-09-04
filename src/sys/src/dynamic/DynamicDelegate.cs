//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Encloses a delegate that was manufactured dynamically
    /// </summary>
    public readonly struct DynamicDelegate : IDynamicDelegate<Delegate>
    {
        /// <summary>
        /// The delegate identity
        /// </summary>
        public _OpIdentity Id {get;}

        /// <summary>
        /// The method invoked by the dynamic operator that provides the substance of the operation
        /// </summary>
        public MethodInfo Source {get;}

        /// <summary>
        /// The dynamically-generated method that backs the dynamic operator
        /// </summary>
        public DynamicMethod Target {get;}

        /// <summary>
        /// The dynamic operation
        /// </summary>
        public Delegate Operation {get;}

        [MethodImpl(Inline)]
        public DynamicDelegate(_OpIdentity id, MethodInfo src, DynamicMethod dst, Delegate op)
        {
            Id = id;
            Source = src;
            Target = dst;
            Operation = op;
        }

        /// <summary>
        /// Invokes the dynamic delegate dynamically
        /// </summary>
        /// <param name="args">The arguments to pass to the delegate</param>
        [MethodImpl(Inline)]
        public object Invoke(params object[] args)
            => Operation.DynamicInvoke(args);

        /// <summary>
        /// The existing delegate, parametrically
        /// </summary>
        /// <typeparam name="D">The target delegate type</typeparam>
        [MethodImpl(Inline)]
        public DynamicDelegate<D> As<D>()
            where D : Delegate
                => new DynamicDelegate<D>(Id, Source, Target, (D)Operation);
    }
}