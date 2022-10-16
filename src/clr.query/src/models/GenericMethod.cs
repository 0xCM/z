//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct GenericMethod
    {
        public MethodInfo Definition {get;}

        [MethodImpl(Inline)]
        public GenericMethod(MethodInfo src)
        {
            Definition = src;
        }
    }
}