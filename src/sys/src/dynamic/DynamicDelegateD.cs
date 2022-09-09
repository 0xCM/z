//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Reflection.Emit;

    /// <summary>
    /// Encloses a generic delegate that was manufactured dynamically
    /// </summary>
    public readonly struct DynamicDelegate<D> : IDynamicDelegate<D>
        where D : Delegate
    {
        /// <summary>
        /// The delegate identity
        /// </summary>
        public OpIdentity Id {get;}

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
        public D Operation {get;}

        [MethodImpl(Inline)]
        public DynamicDelegate(OpIdentity id, MethodInfo src, DynamicMethod dst, D op)
        {
            Id = id;
            Source = src;
            Target = dst;
            Operation = op;
        }

        public DynamicDelegate Untyped
        {
            [MethodImpl(Inline)]
            get => new DynamicDelegate(Id, Source, Target, Operation);
        }
    }
}