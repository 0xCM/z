//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct Dynops
    {
        public static IDynexus Dynexus
            => Z0.Dynexus.service();

        public static IImmInjectors ImmInjectors
            => ImmInjectorFactory.service();
    }
}