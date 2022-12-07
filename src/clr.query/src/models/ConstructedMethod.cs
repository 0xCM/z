//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ConstructedMethod
    {
        public readonly GenericMethod Source;

        public readonly Index<Type> Parameters;

        public readonly MethodInfo Closure;

        [MethodImpl(Inline)]
        public ConstructedMethod(GenericMethod src, Index<Type> args, MethodInfo closure)
        {
            Source = src;
            Parameters = args;
            Closure = closure;
        }
    }
}