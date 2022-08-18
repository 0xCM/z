//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq;

    public class NatNumericAttribute : ClosuresAttribute
    {
        public NatNumericAttribute(NumericKind numeric, params ulong[] naturals)
            : base(numeric, NatClosureKind.Individuals, naturals)
        {

        }
    }
}