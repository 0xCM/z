//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public readonly struct EqualityClaimEvaluator<C> : IClaimEvaluator<C>
        where C : IEqualityClaim, IEquatable<C>
    {
        public bool Eval(in C src, out bool dst)
        {
            dst = src.Expect.Equals(src.Actual);
            return true;
        }
    }
}