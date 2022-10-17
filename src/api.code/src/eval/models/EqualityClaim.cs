//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct EqualityClaim
    {
        public static EqualityClaim<C> define<C>(C a, C b)
            where C : IEquatable<C>
                => (a,b);
    }
}