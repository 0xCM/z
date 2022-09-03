//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    using static Root;

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