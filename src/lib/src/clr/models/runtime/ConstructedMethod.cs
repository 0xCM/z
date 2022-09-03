//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ConstructedMethod
    {
        public GenericMethod Source {get;}

        public Index<Type> Parameters {get;}

        public MethodInfo Closure {get;}

        [MethodImpl(Inline)]
        public ConstructedMethod(GenericMethod src, Index<Type> args, MethodInfo closure)
        {
            Source = src;
            Parameters = args;
            Closure = closure;
        }
    }
}