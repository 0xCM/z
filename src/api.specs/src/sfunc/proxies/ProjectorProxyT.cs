//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ValueProjectorProxy<T> : IValueProjector<T>
        where T : struct
    {
        /// <summary>
        /// The proxy subject
        /// </summary>
        readonly Func<object,T> Delegate;

        /// <summary>
        /// Captures a projected value
        /// </summary>
        readonly T[] Target;

        [MethodImpl(Inline)]
        public ValueProjectorProxy(Func<object,T> f, T[] dst)
        {
            Delegate = f;
            Target = dst;
        }

        [MethodImpl(Inline)]
        public ref T Project(object src)
        {
            ref var dst = ref Target[0];
            dst = Delegate(src);
            return ref dst;
        }

        [MethodImpl(Inline)]
        public ref T Project(in ValueType src)
        {
            ref var dst = ref Target[0];
            dst = Delegate(src);
            return ref dst;
        }

        [MethodImpl(Inline)]
        ValueType IValueProjector.Project(ValueType src)
            => Delegate(src);

        [MethodImpl(Inline)]
        public static implicit operator BoxedValueMap<T>(ValueProjectorProxy<T> src)
            => src.Project;
    }    
}