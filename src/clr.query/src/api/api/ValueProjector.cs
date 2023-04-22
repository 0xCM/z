//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ValueProjector : IValueProjector
    {
        public readonly BoxedValueMap Delegate;

        [MethodImpl(Inline)]
        public ValueProjector(BoxedValueMap f)
            => Delegate = f;

        [MethodImpl(Inline)]
        public object Project(object src)
            => Delegate((ValueType)src);

        [MethodImpl(Inline)]
        public ValueType Project(ValueType src)
            => Delegate(src);

        [MethodImpl(Inline)]
        public static implicit operator BoxedValueMap(ValueProjector src)
            => src.Delegate;
    }   
}